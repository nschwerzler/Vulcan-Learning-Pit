using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// Coordinates all adaptive engines to manage a complete learning session.
/// Integrates: ApprovalEngine, WeaknessTracker, TopicScheduler, BayesianKnowledgeTracer, SpockDialogueEngine.
/// Implements the session state machine and ADD-aware topic switching.
/// </summary>
public class SessionCoordinator
{
    private readonly ApprovalEngine _approvalEngine;
    private readonly WeaknessTracker _weaknessTracker;
    private readonly TopicScheduler _topicScheduler;
    private readonly BayesianKnowledgeTracer _knowledgeTracer;
    private readonly SpockDialogueEngine _dialogueEngine;
    private readonly object _lock = new();
    
    private Session _currentSession;
    private StudentProfile _studentProfile;
    private DateTime _sessionStartTime;
    private DateTime _lastProblemTime;
    private int _problemsInCurrentDomain = 0;
    private Domain _currentDomain;

    public SessionCoordinator(StudentProfile studentProfile)
    {
        _studentProfile = studentProfile ?? throw new ArgumentNullException(nameof(studentProfile));
        _approvalEngine = new ApprovalEngine();
        _weaknessTracker = new WeaknessTracker();
        _topicScheduler = new TopicScheduler();
        _knowledgeTracer = new BayesianKnowledgeTracer();
        _dialogueEngine = new SpockDialogueEngine();
        
        _currentSession = new Session
        {
            StudentId = studentProfile.Id,
            StartTime = DateTime.UtcNow
        };
        _sessionStartTime = DateTime.UtcNow;
        _lastProblemTime = DateTime.UtcNow;
    }

    /// <summary>
    /// Gets the next problem using ADD-aware topic scheduling and weakness targeting.
    /// </summary>
    public async Task<Problem> GetNextProblemAsync(
        List<Problem> availableProblems,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var sessionDuration = DateTime.UtcNow - _lastProblemTime;
            _problemsInCurrentDomain++;

            // Check if we should switch domains (ADD-aware)
            var shouldSwitchTask = _topicScheduler.ShouldSwitchDomainAsync(
                _currentDomain,
                _problemsInCurrentDomain,
                sessionDuration.TotalMinutes,
                cancellationToken);
            
            var shouldSwitch = shouldSwitchTask.Result;

            if (shouldSwitch)
            {
                // Get next domain with weakness prioritization
                var nextDomainTask = _topicScheduler.SelectNextDomainAsync(
                    _studentProfile,
                    _currentDomain,
                    cancellationToken);
                
                _currentDomain = nextDomainTask.Result;
                _problemsInCurrentDomain = 0;
                _lastProblemTime = DateTime.UtcNow;
            }

            // Filter problems by current domain
            var domainProblems = availableProblems
                .Where(p => p.Domain == _currentDomain)
                .ToList();

            if (!domainProblems.Any())
            {
                // Fallback to any domain if current domain exhausted
                domainProblems = availableProblems;
            }

            // Get weaknesses and try to disguise them
            var weaknesses = _weaknessTracker.GetActiveWeaknesses();
            
            if (weaknesses.Any())
            {
                var targetWeakness = weaknesses.First();
                var disguise = _weaknessTracker.GetDisguiseContext(
                    targetWeakness.SkillId,
                    domainProblems.Select(p => p.MicroTopic).Distinct().ToList());

                if (disguise != null)
                {
                    var disguisedProblem = domainProblems
                        .FirstOrDefault(p => p.MicroTopic == disguise);
                    
                    if (disguisedProblem != null)
                    {
                        disguisedProblem.Metadata.DisguisedWeakness = targetWeakness.SkillId;
                        return disguisedProblem;
                    }
                }
            }

            // Use BKT to select appropriate difficulty
            var skills = _knowledgeTracer.GetAllSkills();
            var selectedProblem = SelectProblemByKnowledgeState(domainProblems, skills);
            
            return selectedProblem ?? domainProblems.First();
        }
    }

    /// <summary>
    /// Processes a student's problem attempt and returns dialogue response.
    /// Updates all adaptive engines and triggers approvals when earned.
    /// </summary>
    public async Task<SessionFeedback> ProcessAttemptAsync(
        ProblemAttempt attempt,
        Problem problem,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            // Record attempt in session
            _currentSession.Problems.Add(attempt);

            // Update weakness tracker
            var metrics = new WeaknessMetrics
            {
                Accuracy = attempt.IsCorrect ? 1.0 : 0.0,
                AvgTime = attempt.TimeSpentSeconds,
                Confidence = 1.0 - (attempt.AnswerChanges / Math.Max(1.0, attempt.AnswerChanges + 1)),
                LastAttempt = DateTime.UtcNow
            };
            
            var updateTask = _weaknessTracker.UpdateMetricsAsync(
                problem.MicroTopic,
                metrics,
                cancellationToken);
            updateTask.Wait(cancellationToken);

            // Update BKT knowledge state
            var bktTask = _knowledgeTracer.UpdateSkillAsync(
                problem.MicroTopic,
                attempt.IsCorrect,
                cancellationToken);
            bktTask.Wait(cancellationToken);

            // Check if weakness was mastered
            if (!string.IsNullOrEmpty(problem.Metadata.DisguisedWeakness))
            {
                var masteryTask = _knowledgeTracer.IsMasteredAsync(
                    problem.Metadata.DisguisedWeakness,
                    cancellationToken);
                
                if (masteryTask.Result)
                {
                    attempt.WasWeakness = true;
                    attempt.NowMastered = true;
                }
            }

            // Process through approval engine
            var approvalsTask = _approvalEngine.ProcessProblemAsync(attempt, cancellationToken);
            var approvals = approvalsTask.Result;

            // Generate Spock dialogue
            var dialogueTask = GenerateDialogueAsync(attempt, approvals, problem, cancellationToken);
            var dialogue = dialogueTask.Result;

            // Update session metrics
            UpdateSessionMetrics(attempt, problem);

            // Record approvals
            foreach (var approval in approvals)
            {
                _currentSession.Approvals.Add(approval);
            }

            return new SessionFeedback
            {
                IsCorrect = attempt.IsCorrect,
                Approvals = approvals,
                Dialogue = dialogue,
                CurrentStreak = _approvalEngine.GetCurrentStreak(),
                SessionMetrics = _currentSession.Metrics,
                WeaknessConquered = attempt.NowMastered,
                ShouldSwitchTopic = false // Determined by next GetNextProblem call
            };
        }
    }

    /// <summary>
    /// Ends the current session and returns final metrics.
    /// </summary>
    public Session EndSession(SessionEndReason reason)
    {
        lock (_lock)
        {
            _currentSession.EndTime = DateTime.UtcNow;
            _currentSession.EndReason = reason;
            
            return _currentSession;
        }
    }

    /// <summary>
    /// Gets current session progress and metrics.
    /// </summary>
    public SessionMetrics GetCurrentMetrics()
    {
        lock (_lock)
        {
            return _currentSession.Metrics;
        }
    }

    private async Task<SpockDialogueEngine.DialogueResponse> GenerateDialogueAsync(
        ProblemAttempt attempt,
        List<ApprovalEvent> approvals,
        Problem problem,
        CancellationToken cancellationToken)
    {
        // Strong approval for mastered weakness
        if (attempt.NowMastered)
        {
            return await _dialogueEngine.GetStrongApprovalAsync(
                problem.MicroTopic,
                1, // sessions ago - would track this properly
                cancellationToken);
        }

        // Subtle approval if triggered
        if (approvals.Any())
        {
            var latestApproval = approvals.Last();
            
            var response = await _dialogueEngine.GetSubtleApprovalAsync(
                _approvalEngine.GetCurrentStreak(),
                problem.MicroTopic,
                cancellationToken);

            // 20% chance of narrative echo
            if (latestApproval != null && new Random().NextDouble() < 0.2)
            {
                var echo = await _dialogueEngine.GetNarrativeEchoAsync(
                    latestApproval,
                    cancellationToken);
                
                if (echo != null && !string.IsNullOrEmpty(echo.Message))
                {
                    response.Message += "\n\n" + echo.Message;
                }
            }

            return response;
        }

        // Corrective feedback if incorrect
        if (!attempt.IsCorrect)
        {
            return await _dialogueEngine.GetCorrectiveFeedbackAsync(
                problem.MicroTopic,
                "Review the fundamentals",
                cancellationToken);
        }

        // Neutral dialogue (default)
        return await _dialogueEngine.GetNeutralDialogueAsync(cancellationToken);
    }

    private Problem? SelectProblemByKnowledgeState(List<Problem> problems, List<BayesianKnowledgeTracer.SkillState> skills)
    {
        // Select problems near the edge of current knowledge (Zone of Proximal Development)
        // Target skills with P(L) between 0.4 and 0.8 for optimal challenge
        
        foreach (var problem in problems.OrderBy(_ => Guid.NewGuid())) // Shuffle
        {
            var skill = skills.FirstOrDefault(s => s.SkillId == problem.MicroTopic);
            
            if (skill != null && skill.ProbabilityKnown >= 0.4 && skill.ProbabilityKnown <= 0.8)
            {
                return problem;
            }
        }

        // Fallback: return any problem
        return problems.FirstOrDefault();
    }

    private void UpdateSessionMetrics(ProblemAttempt attempt, Problem problem)
    {
        var metrics = _currentSession.Metrics;
        
        if (attempt.IsCorrect)
        {
            metrics.TotalCorrect++;
        }

        // Update average time
        var totalTime = metrics.AverageTime * (_currentSession.Problems.Count - 1) + attempt.TimeSpentSeconds;
        metrics.AverageTime = totalTime / _currentSession.Problems.Count;

        // Track domains visited
        if (!metrics.DomainsVisited.Contains(problem.Domain.ToString()))
        {
            metrics.DomainsVisited.Add(problem.Domain.ToString());
        }

        // Track weaknesses
        if (!string.IsNullOrEmpty(problem.Metadata.DisguisedWeakness))
        {
            if (!metrics.WeaknessesAddressed.Contains(problem.Metadata.DisguisedWeakness))
            {
                metrics.WeaknessesAddressed.Add(problem.Metadata.DisguisedWeakness);
            }

            if (attempt.NowMastered && !metrics.WeaknessesResolved.Contains(problem.Metadata.DisguisedWeakness))
            {
                metrics.WeaknessesResolved.Add(problem.Metadata.DisguisedWeakness);
            }
        }

        // Calculate focus score (consistency of response times)
        CalculateFocusScore();
    }

    private void CalculateFocusScore()
    {
        if (_currentSession.Problems.Count < 3)
        {
            _currentSession.Metrics.FocusScore = 1.0;
            return;
        }

        var times = _currentSession.Problems.Select(p => (double)p.TimeSpentSeconds).ToList();
        var mean = times.Average();
        var variance = times.Select(t => Math.Pow(t - mean, 2)).Average();
        var stdDev = Math.Sqrt(variance);
        
        // Lower coefficient of variation = higher focus (more consistent timing)
        var coefficientOfVariation = stdDev / mean;
        
        // Convert to 0-1 score (lower CV is better, capped at reasonable values)
        _currentSession.Metrics.FocusScore = Math.Max(0, Math.Min(1, 1 - (coefficientOfVariation / 2)));
    }
}

/// <summary>
/// Feedback returned after processing a problem attempt.
/// Contains dialogue, approval status, and session state.
/// </summary>
public class SessionFeedback
{
    public bool IsCorrect { get; set; }
    public List<ApprovalEvent> Approvals { get; set; } = new();
    public SpockDialogueEngine.DialogueResponse Dialogue { get; set; } = new();
    public int CurrentStreak { get; set; }
    public SessionMetrics SessionMetrics { get; set; } = new();
    public bool WeaknessConquered { get; set; }
    public bool ShouldSwitchTopic { get; set; }
}
