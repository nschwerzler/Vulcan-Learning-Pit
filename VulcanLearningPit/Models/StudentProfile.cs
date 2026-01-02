namespace VulcanLearningPit.Models;

public class StudentProfile
{
    public string Name { get; set; } = string.Empty;
    public GradeLevel Grade { get; set; }
    public int TotalTokens { get; set; }
    public int TotalScore { get; set; }
    public Dictionary<SubjectType, SubjectStats> SubjectStatistics { get; set; } = new();
    public List<Achievement> Achievements { get; set; } = new();
    public DateTime LastSessionDate { get; set; }

    public StudentProfile()
    {
        foreach (SubjectType subject in Enum.GetValues(typeof(SubjectType)))
        {
            SubjectStatistics[subject] = new SubjectStats(subject);
        }
    }
}

public class SubjectStats
{
    public SubjectType Subject { get; set; }
    public int CorrectAnswers { get; set; }
    public int TotalAttempts { get; set; }
    public DifficultyLevel CurrentDifficulty { get; set; } = DifficultyLevel.Easy;
    public double AverageResponseTime { get; set; }
    public int ConsecutiveCorrect { get; set; }
    public int ConsecutiveIncorrect { get; set; }

    public SubjectStats(SubjectType subject)
    {
        Subject = subject;
    }

    public double SuccessRate => TotalAttempts > 0 ? (double)CorrectAnswers / TotalAttempts : 0;
}

public class Achievement
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime EarnedDate { get; set; }
    public int TokenReward { get; set; }
}
