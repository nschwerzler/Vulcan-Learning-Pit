namespace VulcanLearningPit.Models;

public abstract class Problem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public SubjectType Subject { get; set; }
    public DifficultyLevel Difficulty { get; set; }
    public GradeLevel Grade { get; set; }
    public string Question { get; set; } = string.Empty;
    public string CorrectAnswer { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new();
    public int TimeLimit { get; set; } // in seconds
    public string Explanation { get; set; } = string.Empty;
    public int PointValue { get; set; }
}

public class MathProblem : Problem
{
    public MathProblem()
    {
        Subject = SubjectType.Math;
    }
}

public class LogicProblem : Problem
{
    public LogicProblem()
    {
        Subject = SubjectType.Logic;
    }
}

public class ReadingProblem : Problem
{
    public string Passage { get; set; } = string.Empty;

    public ReadingProblem()
    {
        Subject = SubjectType.Reading;
    }
}

public class ScienceProblem : Problem
{
    public ScienceProblem()
    {
        Subject = SubjectType.Science;
    }
}
