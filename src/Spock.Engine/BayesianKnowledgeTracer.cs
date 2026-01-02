using Spock.Core.Models;

namespace Spock.Engine;

/// <summary>
/// Bayesian Knowledge Tracing (BKT) for skill mastery estimation.
/// Tracks probability that student has mastered each skill based on performance history.
/// Uses four core parameters: P(L0), P(T), P(S), P(G) for adaptive learning.
/// </summary>
public class BayesianKnowledgeTracer
{
    private readonly object _lock = new();
    private readonly Dictionary<string, SkillState> _skillStates = new();

    // BKT Parameters (can be tuned based on domain/difficulty)
    private const double DefaultPL0 = 0.1;     // Prior probability of knowing skill initially
    private const double DefaultPT = 0.2;      // Probability of learning (transition) per attempt
    private const double DefaultPS = 0.15;     // Probability of slip (correct answer despite not knowing)
    private const double DefaultPG = 0.25;     // Probability of guess (correct answer by guessing)

    /// <summary>
    /// Represents current knowledge state for a skill using BKT model.
    /// Psychological principle: Continuous probability estimation rather than binary mastery.
    /// </summary>
    public class SkillState
    {
        public string SkillId { get; set; } = string.Empty;
        public double ProbabilityKnown { get; set; }    // P(Ln) - current mastery estimate
        public double PL0 { get; set; }                 // Prior probability
        public double PT { get; set; }                  // Learning rate
        public double PS { get; set; }                  // Slip probability
        public double PG { get; set; }                  // Guess probability
        public int TotalAttempts { get; set; }
        public int CorrectAttempts { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    /// <summary>
    /// Updates skill mastery estimate using BKT formula based on problem attempt.
    /// Pedagogical principle: Each observation refines our belief about student knowledge.
    /// </summary>
    /// <param name="skillId">Unique skill identifier</param>
    /// <param name="wasCorrect">Whether the attempt was correct</param>
    /// <param name="cancellationToken">Cancellation token for async operations</param>
    /// <returns>Updated probability that student knows the skill</returns>
    public Task<double> UpdateSkillAsync(
        string skillId,
        bool wasCorrect,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (!_skillStates.TryGetValue(skillId, out var state))
            {
                // Initialize new skill with default BKT parameters
                state = new SkillState
                {
                    SkillId = skillId,
                    ProbabilityKnown = DefaultPL0,
                    PL0 = DefaultPL0,
                    PT = DefaultPT,
                    PS = DefaultPS,
                    PG = DefaultPG,
                    TotalAttempts = 0,
                    CorrectAttempts = 0,
                    LastUpdated = DateTime.UtcNow
                };
                _skillStates[skillId] = state;
            }

            // Update attempt counts
            state.TotalAttempts++;
            if (wasCorrect) state.CorrectAttempts++;

            // BKT Update Formula
            // P(Ln|correct) = P(Ln-1) * (1 - PS) / [P(Ln-1) * (1 - PS) + (1 - P(Ln-1)) * PG]
            // P(Ln|incorrect) = P(Ln-1) * PS / [P(Ln-1) * PS + (1 - P(Ln-1)) * (1 - PG)]
            double prevP = state.ProbabilityKnown;
            double newP;

            if (wasCorrect)
            {
                // Correct answer increases mastery probability
                double numerator = prevP * (1 - state.PS);
                double denominator = numerator + (1 - prevP) * state.PG;
                newP = denominator > 0 ? numerator / denominator : prevP;
            }
            else
            {
                // Incorrect answer decreases mastery probability
                double numerator = prevP * state.PS;
                double denominator = numerator + (1 - prevP) * (1 - state.PG);
                newP = denominator > 0 ? numerator / denominator : prevP;
            }

            // Apply learning transition: P(Ln+1) = P(Ln) + (1 - P(Ln)) * PT
            // Pedagogical principle: Even incorrect attempts contribute to learning
            newP = newP + (1 - newP) * state.PT;

            // Clamp to [0, 1] to handle numerical precision
            state.ProbabilityKnown = Math.Clamp(newP, 0.0, 1.0);
            state.LastUpdated = DateTime.UtcNow;

            return Task.FromResult(state.ProbabilityKnown);
        }
    }

    /// <summary>
    /// Gets current mastery probability for a skill.
    /// </summary>
    public Task<double> GetMasteryProbabilityAsync(
        string skillId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (_skillStates.TryGetValue(skillId, out var state))
            {
                return Task.FromResult(state.ProbabilityKnown);
            }
            return Task.FromResult(DefaultPL0); // Unknown skill uses prior
        }
    }

    /// <summary>
    /// Determines if skill is mastered based on BKT threshold.
    /// Uses 0.95 threshold as per research literature (very high confidence).
    /// </summary>
    public Task<bool> IsMasteredAsync(
        string skillId,
        double threshold = 0.95,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (_skillStates.TryGetValue(skillId, out var state))
            {
                return Task.FromResult(state.ProbabilityKnown >= threshold);
            }
            return Task.FromResult(false);
        }
    }

    /// <summary>
    /// Gets all skills with their current mastery estimates.
    /// Used for parent dashboard and adaptive decision making.
    /// </summary>
    public Task<Dictionary<string, double>> GetAllMasteryEstimatesAsync(
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var estimates = _skillStates.ToDictionary(
                kvp => kvp.Key,
                kvp => kvp.Value.ProbabilityKnown
            );
            return Task.FromResult(estimates);
        }
    }

    /// <summary>
    /// Gets detailed skill state for advanced analytics.
    /// </summary>
    public Task<SkillState?> GetSkillStateAsync(
        string skillId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (_skillStates.TryGetValue(skillId, out var state))
            {
                // Return copy to prevent external modification
                return Task.FromResult<SkillState?>(new SkillState
                {
                    SkillId = state.SkillId,
                    ProbabilityKnown = state.ProbabilityKnown,
                    PL0 = state.PL0,
                    PT = state.PT,
                    PS = state.PS,
                    PG = state.PG,
                    TotalAttempts = state.TotalAttempts,
                    CorrectAttempts = state.CorrectAttempts,
                    LastUpdated = state.LastUpdated
                });
            }
            return Task.FromResult<SkillState?>(null);
        }
    }

    /// <summary>
    /// Adjusts BKT parameters for a skill (for tuning based on domain characteristics).
    /// </summary>
    public Task SetParametersAsync(
        string skillId,
        double? pl0 = null,
        double? pt = null,
        double? ps = null,
        double? pg = null,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (!_skillStates.TryGetValue(skillId, out var state))
            {
                state = new SkillState
                {
                    SkillId = skillId,
                    ProbabilityKnown = DefaultPL0,
                    PL0 = DefaultPL0,
                    PT = DefaultPT,
                    PS = DefaultPS,
                    PG = DefaultPG,
                    LastUpdated = DateTime.UtcNow
                };
                _skillStates[skillId] = state;
            }

            if (pl0.HasValue) state.PL0 = Math.Clamp(pl0.Value, 0.0, 1.0);
            if (pt.HasValue) state.PT = Math.Clamp(pt.Value, 0.0, 1.0);
            if (ps.HasValue) state.PS = Math.Clamp(ps.Value, 0.0, 1.0);
            if (pg.HasValue) state.PG = Math.Clamp(pg.Value, 0.0, 1.0);

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Resets a skill's mastery estimate (useful for re-teaching or major gaps).
    /// </summary>
    public Task ResetSkillAsync(
        string skillId,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            if (_skillStates.ContainsKey(skillId))
            {
                _skillStates[skillId].ProbabilityKnown = _skillStates[skillId].PL0;
                _skillStates[skillId].TotalAttempts = 0;
                _skillStates[skillId].CorrectAttempts = 0;
                _skillStates[skillId].LastUpdated = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Gets skills that need reinforcement (low mastery probability).
    /// Used for adaptive problem selection and weakness targeting.
    /// </summary>
    public Task<List<string>> GetSkillsNeedingReinforcementAsync(
        double threshold = 0.7,
        CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        lock (_lock)
        {
            var needsWork = _skillStates
                .Where(kvp => kvp.Value.ProbabilityKnown < threshold && kvp.Value.TotalAttempts > 0)
                .OrderBy(kvp => kvp.Value.ProbabilityKnown)
                .Select(kvp => kvp.Key)
                .ToList();

            return Task.FromResult(needsWork);
        }
    }
}
