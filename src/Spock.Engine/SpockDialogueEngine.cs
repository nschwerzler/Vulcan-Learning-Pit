using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// Spock mentor dialogue system for psychological motivation through earned approval.
/// Uses data-based feedback, variable-ratio reinforcement, and narrative echoes.
/// Psychological principle: Rare, meaningful approval is more motivating than frequent praise.
/// </summary>
public class SpockDialogueEngine
{
    private readonly object _lock = new();
    private readonly Random _random = new();
    private readonly List<ApprovalEvent> _approvalHistory = new();
    private readonly List<VulcanInsight> _insightFragments = new();

    /// <summary>
    /// Dialogue response containing message and metadata.
    /// </summary>
    public class DialogueResponse
    {
        public string Message { get; set; } = string.Empty;
        public ApprovalType? ApprovalType { get; set; }
        public ApprovalIntensity? Intensity { get; set; }
        public bool IsNarrativeEcho { get; set; }
        public string? LinkedApprovalId { get; set; }
        public bool IsInsightFragment { get; set; }
    }

    /// <summary>
    /// Vulcan insight fragment - collectible wisdom from rare achievements.
    /// </summary>
    public class VulcanInsight
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Quote { get; set; } = string.Empty;
        public DateTime UnlockedAt { get; set; }
        public string UnlockedBy { get; set; } = string.Empty; // Skill or achievement
    }

    /// <summary>
    /// Gets neutral dialogue (90% of time).
    /// Spock remains observant but non-committal most of the time.
    /// </summary>
    public Task<DialogueResponse> GetNeutralDialogueAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var neutralMessages = new[]
            {
                "Proceed.",
                "Next problem.",
                "Continue.",
                "" // Silent observation
            };

            var message = neutralMessages[_random.Next(neutralMessages.Length)];
            return Task.FromResult(new DialogueResponse { Message = message });
        }
    }

    /// <summary>
    /// Gets subtle approval dialogue for streak-based achievements.
    /// Psychological principle: Data-based recognition without emotional manipulation.
    /// </summary>
    public Task<DialogueResponse> GetSubtleApprovalAsync(
        int streakLength,
        string? skillContext = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var approvalMessages = new[]
            {
                "Your accuracy has improved.",
                "You are maintaining efficiency.",
                "Logical consistency noted.",
                "Pattern recognition is strengthening."
            };

            var message = approvalMessages[_random.Next(approvalMessages.Length)];
            
            // Record approval event for narrative echoes
            var approval = new ApprovalEvent
            {
                Id = Guid.NewGuid().ToString(),
                Type = Core.Models.ApprovalType.Streak,
                Intensity = Core.Models.ApprovalIntensity.Subtle,
                Message = message,
                Timestamp = DateTime.UtcNow,
                Context = skillContext ?? "general"
            };
            _approvalHistory.Add(approval);

            // 20% chance of narrative echo if prior approvals exist
            if (_approvalHistory.Count > 1 && _random.NextDouble() < 0.2)
            {
                return GetNarrativeEchoAsync(approval, cancellationToken);
            }

            return Task.FromResult(new DialogueResponse
            {
                Message = message,
                ApprovalType = Core.Models.ApprovalType.Streak,
                Intensity = Core.Models.ApprovalIntensity.Subtle
            });
        }
    }

    /// <summary>
    /// Gets strong approval for conquered weaknesses.
    /// This is the most motivating moment - weakness identified and resolved.
    /// </summary>
    public Task<DialogueResponse> GetStrongApprovalAsync(
        string skillName,
        int sessionsAgo,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var approvalMessages = new[]
            {
                $"This skill was inefficient. It is no longer so.",
                $"You have eliminated a recurring error pattern.",
                $"Your performance in {skillName} now meets standards.",
                $"Weakness identified {sessionsAgo} sessions ago. Weakness resolved."
            };

            var message = approvalMessages[_random.Next(approvalMessages.Length)];
            
            var approval = new ApprovalEvent
            {
                Id = Guid.NewGuid().ToString(),
                Type = Core.Models.ApprovalType.Mastery,
                Intensity = Core.Models.ApprovalIntensity.Strong,
                Message = message,
                Timestamp = DateTime.UtcNow,
                Context = skillName
            };
            _approvalHistory.Add(approval);

            return Task.FromResult(new DialogueResponse
            {
                Message = message,
                ApprovalType = Core.Models.ApprovalType.Mastery,
                Intensity = Core.Models.ApprovalIntensity.Strong
            });
        }
    }

    /// <summary>
    /// Gets corrective feedback with instructive solution guidance.
    /// Progressive hint system: minimal → detailed steps → worked example.
    /// Psychological principle: Teaching HOW to solve, not just identifying errors.
    /// </summary>
    public Task<DialogueResponse> GetCorrectiveFeedbackAsync(
        string concept,
        string? specificGuidance = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var feedbackMessages = specificGuidance != null
                ? new[] { $"Incorrect. {specificGuidance}" }
                : new[]
                {
                    $"Incorrect. Review the relationship between {concept}.",
                    $"Your assumption about {concept} requires revision.",
                    $"This error pattern recurs. Focus on fundamental principles.",
                    $"Time inefficiency detected. Optimize your approach."
                };

            var message = feedbackMessages[_random.Next(feedbackMessages.Length)];
            
            return Task.FromResult(new DialogueResponse
            {
                Message = message,
                ApprovalType = null,
                Intensity = null
            });
        }
    }

    /// <summary>
    /// Gets corrective feedback with progressive instructive hints based on problem's solution guidance.
    /// First attempt: minimal hint, Second: detailed steps, Third+: worked example.
    /// </summary>
    public Task<DialogueResponse> GetCorrectiveFeedbackWithGuidanceAsync(
        Problem problem,
        int attemptNumber,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var guidance = problem.Content.Guidance;
            string message;

            // Progressive hint system based on attempt count
            if (attemptNumber == 1 && !string.IsNullOrEmpty(guidance.HintMinimal))
            {
                // First attempt: Minimal hint
                message = $"Incorrect. {guidance.HintMinimal}";
                
                if (!string.IsNullOrEmpty(guidance.KeyPrinciple))
                {
                    message += $" Remember: {guidance.KeyPrinciple}";
                }
            }
            else if (attemptNumber == 2 && guidance.StepsDetailed.Any())
            {
                // Second attempt: Detailed step-by-step
                message = "Incorrect. The systematic approach:\n";
                for (int i = 0; i < guidance.StepsDetailed.Count; i++)
                {
                    message += $"\n{i + 1}. {guidance.StepsDetailed[i]}";
                }
            }
            else if (attemptNumber >= 3 && !string.IsNullOrEmpty(guidance.WorkedExample))
            {
                // Third+ attempt: Full worked example
                message = $"Incorrect. Here is how to solve this:\n\n{guidance.WorkedExample}";
                
                if (!string.IsNullOrEmpty(guidance.CommonMistake))
                {
                    message += $"\n\nCommon mistake to avoid: {guidance.CommonMistake}";
                }
            }
            else
            {
                // Fallback if no guidance provided
                message = "Incorrect. Review the problem carefully.";
            }

            return Task.FromResult(new DialogueResponse
            {
                Message = message,
                ApprovalType = null,
                Intensity = null
            });
        }
    }

    /// <summary>
    /// Gets narrative echo - links current success to prior breakthrough.
    /// Psychological principle: Creates story continuity and reinforces long-term progress.
    /// </summary>
    public Task<DialogueResponse> GetNarrativeEchoAsync(
        ApprovalEvent currentApproval,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            // Find a prior approval to link to (not too recent, prefer 5+ approvals ago)
            var eligiblePriors = _approvalHistory
                .Where(a => a.Id != currentApproval.Id && a.Type == Core.Models.ApprovalType.Mastery)
                .OrderByDescending(a => a.Timestamp)
                .Skip(3) // Skip very recent
                .Take(10) // Look within last 10 masteries
                .ToList();

            if (!eligiblePriors.Any())
            {
                // No suitable prior, return current approval without echo
                return Task.FromResult(new DialogueResponse
                {
                    Message = currentApproval.Message,
                    ApprovalType = currentApproval.Type,
                    Intensity = currentApproval.Intensity
                });
            }

            var priorApproval = eligiblePriors[_random.Next(eligiblePriors.Count)];
            var timeSince = DateTime.UtcNow - priorApproval.Timestamp;
            var timeDescription = timeSince.TotalDays switch
            {
                < 1 => "earlier today",
                < 7 => $"{(int)timeSince.TotalDays} days ago",
                < 30 => $"{(int)(timeSince.TotalDays / 7)} weeks ago",
                _ => "previously"
            };

            var echoMessages = new[]
            {
                $"{currentApproval.Message} Your mastery of {priorApproval.Context} {timeDescription} enabled this progress.",
                $"{currentApproval.Message} This builds upon your breakthrough in {priorApproval.Context}.",
                $"{currentApproval.Message} The discipline you demonstrated in {priorApproval.Context} is evident here."
            };

            return Task.FromResult(new DialogueResponse
            {
                Message = echoMessages[_random.Next(echoMessages.Length)],
                ApprovalType = currentApproval.Type,
                Intensity = currentApproval.Intensity,
                IsNarrativeEcho = true,
                LinkedApprovalId = priorApproval.Id
            });
        }
    }

    /// <summary>
    /// Gets advanced level approval for high school/college concepts.
    /// </summary>
    public Task<DialogueResponse> GetAdvancedApprovalAsync(
        string achievement,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var advancedMessages = new[]
            {
                "Your proof structure is now rigorous.",
                "You have generalized beyond initial parameters.",
                "This synthesis integrates multiple domains effectively.",
                "Your model predicts unobserved outcomes."
            };

            var message = advancedMessages[_random.Next(advancedMessages.Length)];
            
            return Task.FromResult(new DialogueResponse
            {
                Message = message,
                ApprovalType = Core.Models.ApprovalType.Mastery,
                Intensity = Core.Models.ApprovalIntensity.Strong
            });
        }
    }

    /// <summary>
    /// Unlocks Vulcan insight fragment for major breakthroughs.
    /// Collectible wisdom that creates achievement drive without gamification pressure.
    /// </summary>
    public Task<DialogueResponse> UnlockVulcanInsightAsync(
        string unlockedBy,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var insights = new[]
            {
                "The capacity to learn is not intelligence. The capacity to act on learning is.",
                "Mastery is achieved when efficiency becomes instinct.",
                "Pattern recognition accelerates all subsequent learning.",
                "Logic is the beginning of wisdom, not the end.",
                "The needs of growth outweigh the comfort of familiarity.",
                "Change is the essential process of all existence."
            };

            var quote = insights[_random.Next(insights.Length)];
            
            var insight = new VulcanInsight
            {
                Quote = quote,
                UnlockedAt = DateTime.UtcNow,
                UnlockedBy = unlockedBy
            };
            _insightFragments.Add(insight);

            return Task.FromResult(new DialogueResponse
            {
                Message = $"*{quote}*",
                ApprovalType = Core.Models.ApprovalType.RapidMastery,
                Intensity = Core.Models.ApprovalIntensity.Strong,
                IsInsightFragment = true
            });
        }
    }

    /// <summary>
    /// Gets approval history for parent dashboard and analytics.
    /// </summary>
    public Task<List<ApprovalEvent>> GetApprovalHistoryAsync(
        int? maxCount = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var history = maxCount.HasValue
                ? _approvalHistory.OrderByDescending(a => a.Timestamp).Take(maxCount.Value).ToList()
                : new List<ApprovalEvent>(_approvalHistory);
            
            return Task.FromResult(history);
        }
    }

    /// <summary>
    /// Gets collected Vulcan insights.
    /// </summary>
    public Task<List<VulcanInsight>> GetVulcanInsightsAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            return Task.FromResult(new List<VulcanInsight>(_insightFragments));
        }
    }

    /// <summary>
    /// Calculates approval frequency metrics for psychological health monitoring.
    /// Target: 1 approval per 15-20 problems to maintain motivation without pressure.
    /// </summary>
    public Task<double> GetApprovalFrequencyAsync(
        int totalProblems,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (totalProblems == 0) return Task.FromResult(0.0);
            
            var frequency = _approvalHistory.Count / (double)totalProblems;
            return Task.FromResult(frequency);
        }
    }

    /// <summary>
    /// Resets approval history for new session or student.
    /// Preserves insight fragments as they're collectible across sessions.
    /// </summary>
    public Task ResetApprovalHistoryAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            _approvalHistory.Clear();
        }

        return Task.CompletedTask;
    }
}
