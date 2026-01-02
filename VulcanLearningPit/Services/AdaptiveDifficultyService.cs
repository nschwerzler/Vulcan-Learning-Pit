using VulcanLearningPit.Models;

namespace VulcanLearningPit.Services;

public class AdaptiveDifficultyService
{
    private const int ConsecutiveThresholdIncrease = 3; // Correct answers to increase difficulty
    private const int ConsecutiveThresholdDecrease = 3; // Incorrect answers to decrease difficulty
    private const double SuccessRateThresholdHigh = 0.80; // 80% success rate
    private const double SuccessRateThresholdLow = 0.50; // 50% success rate

    public DifficultyLevel AdjustDifficulty(SubjectStats stats)
    {
        var currentDifficulty = stats.CurrentDifficulty;

        // Check consecutive correct answers
        if (stats.ConsecutiveCorrect >= ConsecutiveThresholdIncrease)
        {
            return IncreaseDifficulty(currentDifficulty);
        }

        // Check consecutive incorrect answers
        if (stats.ConsecutiveIncorrect >= ConsecutiveThresholdDecrease)
        {
            return DecreaseDifficulty(currentDifficulty);
        }

        // Check overall success rate if we have enough data
        if (stats.TotalAttempts >= 10)
        {
            if (stats.SuccessRate >= SuccessRateThresholdHigh && stats.ConsecutiveCorrect >= 2)
            {
                return IncreaseDifficulty(currentDifficulty);
            }
            else if (stats.SuccessRate < SuccessRateThresholdLow)
            {
                return DecreaseDifficulty(currentDifficulty);
            }
        }

        return currentDifficulty;
    }

    public SubjectType IdentifyWeakestSubject(Dictionary<SubjectType, SubjectStats> subjectStats)
    {
        // Filter subjects with enough attempts
        var subjectsWithData = subjectStats
            .Where(s => s.Value.TotalAttempts >= 5)
            .ToList();

        if (subjectsWithData.Count == 0)
        {
            // No data yet, return a random subject
            var subjects = Enum.GetValues(typeof(SubjectType)).Cast<SubjectType>().ToList();
            return subjects[Random.Shared.Next(subjects.Count)];
        }

        // Find subject with lowest success rate
        return subjectsWithData
            .OrderBy(s => s.Value.SuccessRate)
            .ThenByDescending(s => s.Value.TotalAttempts)
            .First()
            .Key;
    }

    public SubjectType SelectNextSubject(Dictionary<SubjectType, SubjectStats> subjectStats, SubjectType currentSubject)
    {
        // 70% chance to target weakness, 30% chance to switch for ADD support
        if (Random.Shared.NextDouble() < 0.7)
        {
            return IdentifyWeakestSubject(subjectStats);
        }
        else
        {
            // Switch to a different subject for ADD support
            var subjects = Enum.GetValues(typeof(SubjectType)).Cast<SubjectType>()
                .Where(s => s != currentSubject)
                .ToList();
            return subjects[Random.Shared.Next(subjects.Count)];
        }
    }

    private DifficultyLevel IncreaseDifficulty(DifficultyLevel current)
    {
        return current switch
        {
            DifficultyLevel.Easy => DifficultyLevel.Medium,
            DifficultyLevel.Medium => DifficultyLevel.Hard,
            DifficultyLevel.Hard => DifficultyLevel.Expert,
            DifficultyLevel.Expert => DifficultyLevel.Expert, // Max difficulty
            _ => DifficultyLevel.Medium
        };
    }

    private DifficultyLevel DecreaseDifficulty(DifficultyLevel current)
    {
        return current switch
        {
            DifficultyLevel.Expert => DifficultyLevel.Hard,
            DifficultyLevel.Hard => DifficultyLevel.Medium,
            DifficultyLevel.Medium => DifficultyLevel.Easy,
            DifficultyLevel.Easy => DifficultyLevel.Easy, // Min difficulty
            _ => DifficultyLevel.Easy
        };
    }
}
