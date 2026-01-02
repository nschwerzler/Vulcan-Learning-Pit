namespace VulcanLearningPit.Models;

public class ProblemSession
{
    public string SessionId { get; set; } = Guid.NewGuid().ToString();
    public StudentProfile Student { get; set; } = new();
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public List<ProblemAttempt> Attempts { get; set; } = new();
    public int TokensEarned { get; set; }
    public int TotalScore { get; set; }
    public SubjectType CurrentSubject { get; set; }
}

public class ProblemAttempt
{
    public Problem Problem { get; set; } = null!;
    public string StudentAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public TimeSpan ResponseTime => EndTime - StartTime;
    public int PointsEarned { get; set; }
    public int TokensEarned { get; set; }
}
