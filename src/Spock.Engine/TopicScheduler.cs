using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// ADD-optimized scheduler that manages domain switches to prevent fatigue.
/// Uses topic fatigue tracking to ensure variety while maintaining learning flow.
/// Implements 10-15 minute domain rotation for optimal engagement without overwhelming.
/// </summary>
public class TopicScheduler
{
    private readonly object _lock = new();
    private readonly Dictionary<Domain, DateTime> _lastUsed = new();
    private readonly Dictionary<Domain, int> _sessionCount = new();
    private readonly Random _random = new();

    /// <summary>
    /// Determines if it's time to switch domains based on psychological engagement principles.
    /// Uses time-based fatigue (10-15 min) and problem count (avoid too much sameness).
    /// </summary>
    /// <param name="currentDomain">Current active domain</param>
    /// <param name="problemsSolved">Problems solved in current domain this session</param>
    /// <param name="timeInDomain">Time spent in current domain (seconds)</param>
    /// <param name="cancellationToken">Cancellation token for async operations</param>
    /// <returns>True if domain switch recommended for optimal engagement</returns>
    public Task<bool> ShouldSwitchDomainAsync(
        Domain currentDomain,
        int problemsSolved,
        double timeInDomain,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            // Psychological principle: 10-15 minutes is optimal focus period for ADD-friendly learning
            if (timeInDomain > 600) // 10 minutes minimum
            {
                // After 10 minutes, gradually increase switch probability
                // At 15 minutes (900s), switch probability is 100%
                var switchProbability = (timeInDomain - 600) / 300.0; // Linear from 0 to 1
                if (_random.NextDouble() < switchProbability)
                {
                    return Task.FromResult(true);
                }
            }

            // Pedagogical principle: Even with good time management, too many similar problems cause fatigue
            // Switch after 8-12 problems to maintain engagement
            if (problemsSolved >= 8)
            {
                var switchProbability = (problemsSolved - 8) / 4.0; // 8=0%, 12=100%
                if (_random.NextDouble() < switchProbability)
                {
                    return Task.FromResult(true);
                }
            }

            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Selects next domain using interleaving and fatigue tracking.
    /// Prefers domains not recently used, respects mastery levels.
    /// </summary>
    /// <param name="currentDomain">Current domain to switch from</param>
    /// <param name="profile">Student profile with unlocked domains and levels</param>
    /// <param name="weaknessDomains">Domains with tracked weaknesses (priority for spiral-back)</param>
    /// <param name="cancellationToken">Cancellation token for async operations</param>
    /// <returns>Next domain to switch to, null if no valid options</returns>
    public Task<Domain?> SelectNextDomainAsync(
        Domain currentDomain,
        StudentProfile profile,
        List<Domain> weaknessDomains,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            // Get all available domains (unlocked and not current)
            var availableDomains = profile.Level.UnlockedDomains
                .Where(d => d != currentDomain)
                .ToList();

            if (!availableDomains.Any())
            {
                return Task.FromResult<Domain?>(null);
            }

            // Psychological principle: Spiral-back to weaknesses for remediation
            // 40% chance to switch to a weakness domain if available
            var weaknessOptions = availableDomains.Intersect(weaknessDomains).ToList();
            if (weaknessOptions.Any() && _random.NextDouble() < 0.4)
            {
                return Task.FromResult<Domain?>(SelectLeastRecentDomain(weaknessOptions));
            }

            // Otherwise use interleaving - pick least recently used domain
            return Task.FromResult<Domain?>(SelectLeastRecentDomain(availableDomains));
        }
    }

    /// <summary>
    /// Records domain usage for fatigue tracking.
    /// </summary>
    public Task RecordDomainUsedAsync(Domain domain, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            _lastUsed[domain] = DateTime.UtcNow;
            _sessionCount[domain] = _sessionCount.GetValueOrDefault(domain) + 1;
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Gets domain usage statistics for parent dashboard.
    /// </summary>
    public Task<Dictionary<Domain, int>> GetDomainUsageAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            return Task.FromResult(new Dictionary<Domain, int>(_sessionCount));
        }
    }

    /// <summary>
    /// Resets session counters (called at session end).
    /// Keeps lastUsed for cross-session interleaving.
    /// </summary>
    public Task ResetSessionCountersAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            _sessionCount.Clear();
        }

        return Task.CompletedTask;
    }

    /// <summary>
    /// Selects the domain that was used least recently.
    /// Implements interleaving principle for optimal retention.
    /// </summary>
    private Domain SelectLeastRecentDomain(List<Domain> domains)
    {
        // Find domain with oldest last-used timestamp (or never used)
        var oldest = domains
            .OrderBy(d => _lastUsed.GetValueOrDefault(d, DateTime.MinValue))
            .First();

        return oldest;
    }

    /// <summary>
    /// Calculates time since domain was last used (for testing/diagnostics).
    /// </summary>
    public Task<TimeSpan?> GetTimeSinceLastUsedAsync(Domain domain, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (_lastUsed.TryGetValue(domain, out var lastTime))
            {
                return Task.FromResult<TimeSpan?>(DateTime.UtcNow - lastTime);
            }
            return Task.FromResult<TimeSpan?>(null);
        }
    }
}
