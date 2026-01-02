using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// Implements Spock's variable-ratio reinforcement approval system.
/// Approvals are rare and data-based, earned only through genuine improvement.
/// Uses 3-7 correct sequence threshold (randomized) to maintain unpredictability.
/// </summary>
public class ApprovalEngine
{
    private int _correctStreak = 0;
    private int _approvalThreshold;
    private bool _recentWeaknessConquered = false;
    private readonly Random _random = new();
    private readonly List<ApprovalEvent> _pendingApprovals = new();

    /// <summary>
    /// Event fired when approval is triggered for UI display
    /// </summary>
    public event EventHandler<ApprovalEvent>? ApprovalTriggered;

    public ApprovalEngine()
    {
        _approvalThreshold = _random.Next(3, 8); // 3-7 inclusive
    }

    /// <summary>
    /// Processes a problem attempt and determines if approval should be triggered.
    /// Implements psychological variable-ratio reinforcement pattern.
    /// </summary>
    /// <param name="problem">The problem attempt to process</param>
    /// <param name="cancellationToken">Cancellation token for timeout support</param>
    /// <returns>List of approval events generated (if any)</returns>
    public async Task<List<ApprovalEvent>> ProcessProblemAsync(
        ProblemAttempt problem,
        CancellationToken cancellationToken = default)
    {
        _pendingApprovals.Clear();

        // Simulate brief processing delay (in real implementation, this would be approval selection logic)
        await Task.Delay(10, cancellationToken);

        if (problem.IsCorrect)
        {
            _correctStreak++;
            
            // Check for weakness mastery (highest priority approval)
            if (problem.WasWeakness && problem.NowMastered)
            {
                _recentWeaknessConquered = true;
            }
        }
        else
        {
            // Reset streak on incorrect answer
            _correctStreak = 0;
            _approvalThreshold = _random.Next(3, 8);
        }

        // Approval condition 1: Streak-based (variable ratio)
        if (_correctStreak >= _approvalThreshold)
        {
            var approval = TriggerApproval(ApprovalType.Streak, ApprovalIntensity.Subtle);
            _pendingApprovals.Add(approval);
            _correctStreak = 0;
            _approvalThreshold = _random.Next(3, 8);
        }

        // Approval condition 2: Weakness conquered (always triggers, overrides streak)
        if (_recentWeaknessConquered)
        {
            var approval = TriggerApproval(ApprovalType.Mastery, ApprovalIntensity.Strong);
            _pendingApprovals.Add(approval);
            _recentWeaknessConquered = false;
        }

        return _pendingApprovals.ToList();
    }

    /// <summary>
    /// Creates an approval event and raises the event for UI handling.
    /// Approval messages are data-based and never use generic praise.
    /// </summary>
    private ApprovalEvent TriggerApproval(ApprovalType type, ApprovalIntensity intensity)
    {
        var approval = new ApprovalEvent
        {
            Type = type,
            Intensity = intensity,
            Message = GetApprovalMessage(type, intensity),
            Timestamp = DateTime.UtcNow
        };

        ApprovalTriggered?.Invoke(this, approval);
        return approval;
    }

    /// <summary>
    /// Selects appropriate Spock dialogue for the approval type.
    /// Messages are factual and data-based, never emotionally manipulative.
    /// </summary>
    private string GetApprovalMessage(ApprovalType type, ApprovalIntensity intensity)
    {
        return type switch
        {
            ApprovalType.Streak when intensity == ApprovalIntensity.Subtle => 
                GetSubtleStreakMessage(),
            ApprovalType.Mastery when intensity == ApprovalIntensity.Strong => 
                GetMasteryMessage(),
            _ => "Proceed."
        };
    }

    private string GetSubtleStreakMessage()
    {
        var messages = new[]
        {
            "Your accuracy has improved.",
            "You are maintaining efficiency.",
            "Logical consistency noted.",
            "Pattern recognition is strengthening."
        };
        return messages[_random.Next(messages.Length)];
    }

    private string GetMasteryMessage()
    {
        var messages = new[]
        {
            "This skill was inefficient. It is no longer so.",
            "You have eliminated a recurring error pattern.",
            "Weakness identified. Weakness resolved.",
            "Your performance now meets standards."
        };
        return messages[_random.Next(messages.Length)];
    }

    /// <summary>
    /// Gets current streak count (for testing/debugging)
    /// </summary>
    public int CurrentStreak => _correctStreak;

    /// <summary>
    /// Gets current approval threshold (for testing/debugging)
    /// </summary>
    public int CurrentThreshold => _approvalThreshold;

    /// <summary>
    /// Resets the engine state (for new sessions)
    /// </summary>
    public void Reset()
    {
        _correctStreak = 0;
        _approvalThreshold = _random.Next(3, 8);
        _recentWeaknessConquered = false;
        _pendingApprovals.Clear();
    }
}
