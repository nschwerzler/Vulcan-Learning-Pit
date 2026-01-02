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

    public abstract void Generate();
}

public class MathProblem : Problem
{
    public MathProblem()
    {
        Subject = SubjectType.Math;
    }

    public override void Generate()
    {
        // Math problem generation will be implemented by the problem generator service
    }
}

public class LogicProblem : Problem
{
    public LogicProblem()
    {
        Subject = SubjectType.Logic;
    }

    public override void Generate()
    {
        // Logic problem generation will be implemented by the problem generator service
    }
}

public class ReadingProblem : Problem
{
    public string Passage { get; set; } = string.Empty;

    public ReadingProblem()
    {
        Subject = SubjectType.Reading;
    }

    public override void Generate()
    {
        // Reading problem generation will be implemented by the problem generator service
    }
}

public class ScienceProblem : Problem
{
    public ScienceProblem()
    {
        Subject = SubjectType.Science;
    }

    public override void Generate()
    {
        // Science problem generation will be implemented by the problem generator service
    }
}
