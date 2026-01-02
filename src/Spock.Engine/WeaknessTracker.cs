using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// Tracks student weaknesses across multiple skills and domains.
/// Implements intelligent weakness disguising to avoid pattern recognition fatigue.
/// Uses accuracy, time, and confidence metrics to identify persistent struggles.
/// </summary>
public class WeaknessTracker
{
    private readonly Dictionary<string, WeaknessMetrics> _skills = new();
    private readonly Random _random = new();
    private readonly object _lock = new();

    /// <summary>
    /// Determines if a skill qualifies as a weakness based on multiple criteria.
    /// Psychological reasoning: Multiple indicators prevent false positives.
    /// </summary>
    /// <param name="skillId">Unique skill identifier (e.g., "fractions-addition")</param>
    /// <param name="targetTime">Expected completion time in seconds</param>
    /// <returns>True if skill meets weakness criteria</returns>
    public bool IsWeakness(string skillId, double targetTime)
    {
        lock (_lock)
        {
            if (!_skills.TryGetValue(skillId, out var metrics))
                return false;

            // Weakness criteria from plan specification:
            // - Accuracy < 75%
            // - Average time > 130% of target
            // - Confidence < 70% (frequent answer changes)
            return metrics.Accuracy < 0.75 ||
                   metrics.AvgTime > 1.3 * targetTime ||
                   metrics.Confidence < 0.7;
        }
    }

    /// <summary>
    /// Gets a new context/domain to disguise weakness practice.
    /// ADD-aware reasoning: Varies presentation to maintain engagement.
    /// </summary>
    /// <param name="skillId">The skill to find a disguise for</param>
    /// <param name="allContexts">All available contexts for this skill</param>
    /// <returns>Unused context, or null if all exhausted</returns>
    public string? GetDisguiseContext(string skillId, List<string> allContexts)
    {
        lock (_lock)
        {
            if (!_skills.TryGetValue(skillId, out var baseSkill))
                return null;

            var usedContexts = baseSkill.PresentedAs;
            var available = allContexts.Except(usedContexts).ToList();

            return available.Count > 0
                ? available[_random.Next(available.Count)]
                : null;
        }
    }

    /// <summary>
    /// Updates or adds metrics for a skill based on problem attempts.
    /// Calculates accuracy, average time, and confidence from attempt history.
    /// </summary>
    /// <param name="skillId">Unique skill identifier</param>
    /// <param name="attempts">List of attempts for this skill</param>
    /// <param name="targetTime">Expected completion time</param>
    /// <param name="cancellationToken">Cancellation token for timeout support</param>
    public async Task UpdateMetricsAsync(
        string skillId,
        List<ProblemAttempt> attempts,
        double targetTime,
        CancellationToken cancellationToken = default)
    {
        await Task.Run(() =>
        {
            lock (_lock)
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (attempts.Count == 0)
                    return;

                var correctCount = attempts.Count(a => a.IsCorrect);
                var accuracy = (double)correctCount / attempts.Count;
                var avgTime = attempts.Average(a => a.TimeSpentSeconds);
                var totalChanges = attempts.Sum(a => a.AnswerChanges);
                var confidence = 1.0 - ((double)totalChanges / attempts.Count);

                // Determine error pattern (conceptual, procedural, or speed)
                var errorPattern = DetermineErrorPattern(attempts, targetTime);

                var metrics = new WeaknessMetrics
                {
                    Accuracy = accuracy,
                    AvgTime = avgTime,
                    Confidence = Math.Max(0, Math.Min(1, confidence)),
                    ErrorPattern = errorPattern,
                    LastAttempt = attempts.Max(a => a.AttemptTime),
                    TotalAttempts = attempts.Count
                };

                if (_skills.ContainsKey(skillId))
                {
                    // Preserve disguise history
                    metrics.PresentedAs = _skills[skillId].PresentedAs;
                    metrics.DisguiseCount = _skills[skillId].DisguiseCount;
                }

                _skills[skillId] = metrics;
            }
        }, cancellationToken);
    }

    /// <summary>
    /// Records that a weakness was presented in a specific context (for disguise tracking).
    /// </summary>
    public void RecordDisguiseUsed(string skillId, string context)
    {
        lock (_lock)
        {
            if (!_skills.ContainsKey(skillId))
            {
                _skills[skillId] = new WeaknessMetrics();
            }

            var metrics = _skills[skillId];
            if (!metrics.PresentedAs.Contains(context))
            {
                metrics.PresentedAs.Add(context);
                metrics.DisguiseCount++;
            }
        }
    }

    /// <summary>
    /// Gets all active weaknesses for a student.
    /// </summary>
    /// <param name="targetTimes">Dictionary of skill IDs to target times</param>
    /// <returns>List of skill IDs that are weaknesses</returns>
    public List<string> GetActiveWeaknesses(Dictionary<string, double> targetTimes)
    {
        lock (_lock)
        {
            var weaknesses = new List<string>();
            foreach (var skillId in _skills.Keys)
            {
                if (targetTimes.TryGetValue(skillId, out var targetTime))
                {
                    if (IsWeakness(skillId, targetTime))
                    {
                        weaknesses.Add(skillId);
                    }
                }
            }
            return weaknesses;
        }
    }

    /// <summary>
    /// Gets metrics for a specific skill.
    /// </summary>
    public WeaknessMetrics? GetMetrics(string skillId)
    {
        lock (_lock)
        {
            return _skills.TryGetValue(skillId, out var metrics) ? metrics : null;
        }
    }

    /// <summary>
    /// Determines the error pattern type from attempt history.
    /// Pedagogical reasoning: Different error types require different interventions.
    /// </summary>
    private string DetermineErrorPattern(List<ProblemAttempt> attempts, double targetTime)
    {
        if (attempts.Count == 0)
            return "unknown";

        var incorrectAttempts = attempts.Where(a => !a.IsCorrect).ToList();
        if (incorrectAttempts.Count == 0)
            return "none";

        // Speed error: Correct answers but taking too long
        var avgTime = attempts.Average(a => a.TimeSpentSeconds);
        if (attempts.Count(a => a.IsCorrect) > attempts.Count / 2 && avgTime > targetTime * 1.5)
            return "speed";

        // Conceptual error: Low accuracy, many answer changes (uncertainty)
        var avgChanges = attempts.Average(a => a.AnswerChanges);
        if (avgChanges > 2)
            return "conceptual";

        // Procedural error: Low accuracy, few changes (confident but wrong)
        return "procedural";
    }

    /// <summary>
    /// Checks if a weakness has been resolved (crossed mastery threshold).
    /// </summary>
    public bool IsWeaknessResolved(string skillId, double targetTime)
    {
        lock (_lock)
        {
            if (!_skills.TryGetValue(skillId, out var metrics))
                return false;

            // Mastery criteria: >90% accuracy, <80% target time, >80% confidence
            return metrics.Accuracy >= 0.90 &&
                   metrics.AvgTime < 0.80 * targetTime &&
                   metrics.Confidence >= 0.80;
        }
    }

    /// <summary>
    /// Gets total number of tracked skills.
    /// </summary>
    public int TrackedSkillCount
    {
        get
        {
            lock (_lock)
            {
                return _skills.Count;
            }
        }
    }

    /// <summary>
    /// Clears all tracked weaknesses (for testing or session reset).
    /// </summary>
    public void Clear()
    {
        lock (_lock)
        {
            _skills.Clear();
        }
    }
}
