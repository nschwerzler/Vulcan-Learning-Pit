using VulcanLearningPit.Models;

namespace VulcanLearningPit.Services;

public class ProblemGeneratorService
{
    private readonly Random _random = new();

    public Problem GenerateProblem(SubjectType subject, DifficultyLevel difficulty, GradeLevel grade)
    {
        return subject switch
        {
            SubjectType.Math => GenerateMathProblem(difficulty, grade),
            SubjectType.Logic => GenerateLogicProblem(difficulty, grade),
            SubjectType.Reading => GenerateReadingProblem(difficulty, grade),
            SubjectType.Science => GenerateScienceProblem(difficulty, grade),
            _ => throw new ArgumentException($"Unknown subject type: {subject}")
        };
    }

    private MathProblem GenerateMathProblem(DifficultyLevel difficulty, GradeLevel grade)
    {
        var problem = new MathProblem
        {
            Difficulty = difficulty,
            Grade = grade,
            TimeLimit = GetTimeLimit(difficulty)
        };

        int maxNumber = GetMaxNumber(difficulty, grade);
        
        switch (_random.Next(4))
        {
            case 0: // Addition
                GenerateAdditionProblem(problem, maxNumber);
                break;
            case 1: // Subtraction
                GenerateSubtractionProblem(problem, maxNumber);
                break;
            case 2: // Multiplication
                GenerateMultiplicationProblem(problem, maxNumber, difficulty);
                break;
            case 3: // Division
                GenerateDivisionProblem(problem, maxNumber, difficulty);
                break;
        }

        problem.PointValue = CalculatePointValue(difficulty);
        return problem;
    }

    private void GenerateAdditionProblem(MathProblem problem, int maxNumber)
    {
        int a = _random.Next(1, maxNumber);
        int b = _random.Next(1, maxNumber);
        int answer = a + b;

        problem.Question = $"What is {a} + {b}?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, maxNumber * 2);
        problem.Explanation = $"{a} + {b} = {answer}";
    }

    private void GenerateSubtractionProblem(MathProblem problem, int maxNumber)
    {
        int a = _random.Next(1, maxNumber);
        int b = _random.Next(1, a + 1);
        int answer = a - b;

        problem.Question = $"What is {a} - {b}?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, maxNumber);
        problem.Explanation = $"{a} - {b} = {answer}";
    }

    private void GenerateMultiplicationProblem(MathProblem problem, int maxNumber, DifficultyLevel difficulty)
    {
        int range = difficulty <= DifficultyLevel.Medium ? 12 : 20;
        int a = _random.Next(1, range);
        int b = _random.Next(1, range);
        int answer = a * b;

        problem.Question = $"What is {a} × {b}?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, answer + 50);
        problem.Explanation = $"{a} × {b} = {answer}";
    }

    private void GenerateDivisionProblem(MathProblem problem, int maxNumber, DifficultyLevel difficulty)
    {
        int answer = _random.Next(1, difficulty <= DifficultyLevel.Medium ? 12 : 20);
        int divisor = _random.Next(2, difficulty <= DifficultyLevel.Medium ? 12 : 20);
        int dividend = answer * divisor;

        problem.Question = $"What is {dividend} ÷ {divisor}?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, Math.Max(answer + 10, 20));
        problem.Explanation = $"{dividend} ÷ {divisor} = {answer}";
    }

    private LogicProblem GenerateLogicProblem(DifficultyLevel difficulty, GradeLevel grade)
    {
        var problem = new LogicProblem
        {
            Difficulty = difficulty,
            Grade = grade,
            TimeLimit = GetTimeLimit(difficulty),
            PointValue = CalculatePointValue(difficulty)
        };

        switch (_random.Next(3))
        {
            case 0: // Pattern recognition
                GeneratePatternProblem(problem, difficulty);
                break;
            case 1: // Number sequence
                GenerateSequenceProblem(problem, difficulty);
                break;
            case 2: // Logic puzzle
                GenerateLogicPuzzle(problem, difficulty);
                break;
        }

        return problem;
    }

    private void GeneratePatternProblem(LogicProblem problem, DifficultyLevel difficulty)
    {
        int start = _random.Next(1, 10);
        int step = difficulty <= DifficultyLevel.Medium ? _random.Next(2, 5) : _random.Next(3, 8);
        int[] sequence = new int[4];
        
        for (int i = 0; i < 4; i++)
        {
            sequence[i] = start + (i * step);
        }

        int answer = start + (4 * step);
        problem.Question = $"What number comes next in the sequence? {string.Join(", ", sequence)}, ?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, answer + 20);
        problem.Explanation = $"The pattern adds {step} each time. {sequence[3]} + {step} = {answer}";
    }

    private void GenerateSequenceProblem(LogicProblem problem, DifficultyLevel difficulty)
    {
        int[] fibonacci = { 1, 1, 2, 3, 5, 8, 13, 21, 34, 55 };
        int startIndex = _random.Next(0, difficulty <= DifficultyLevel.Medium ? 5 : 3);
        
        problem.Question = $"What number comes next? {fibonacci[startIndex]}, {fibonacci[startIndex + 1]}, {fibonacci[startIndex + 2]}, {fibonacci[startIndex + 3]}, ?";
        problem.CorrectAnswer = fibonacci[startIndex + 4].ToString();
        problem.Options = GenerateMultipleChoice(fibonacci[startIndex + 4], fibonacci[startIndex + 4] + 30);
        problem.Explanation = $"This is a Fibonacci sequence where each number is the sum of the previous two.";
    }

    private void GenerateLogicPuzzle(LogicProblem problem, DifficultyLevel difficulty)
    {
        int apples = _random.Next(2, 10);
        int oranges = _random.Next(2, 10);
        int answer = apples + oranges;

        problem.Question = $"If you have {apples} apples and {oranges} oranges, how many pieces of fruit do you have in total?";
        problem.CorrectAnswer = answer.ToString();
        problem.Options = GenerateMultipleChoice(answer, 25);
        problem.Explanation = $"{apples} apples + {oranges} oranges = {answer} pieces of fruit";
    }

    private ReadingProblem GenerateReadingProblem(DifficultyLevel difficulty, GradeLevel grade)
    {
        var problem = new ReadingProblem
        {
            Difficulty = difficulty,
            Grade = grade,
            TimeLimit = GetTimeLimit(difficulty) + 30, // Extra time for reading
            PointValue = CalculatePointValue(difficulty)
        };

        GenerateComprehensionProblem(problem, difficulty, grade);
        return problem;
    }

    private void GenerateComprehensionProblem(ReadingProblem problem, DifficultyLevel difficulty, GradeLevel grade)
    {
        var passages = new[]
        {
            new { Text = "The sun is a star at the center of our solar system. It provides light and heat to Earth. Without the sun, life on Earth would not be possible. The sun is about 93 million miles away from Earth.", Question = "Why is the sun important to Earth?", Answer = "It provides light and heat", Options = new[] { "It provides light and heat", "It is very far away", "It is a planet", "It is made of rock" } },
            new { Text = "Bees are important insects that help plants grow. They collect nectar from flowers and spread pollen. This process is called pollination. Many fruits and vegetables depend on bees for pollination.", Question = "What is pollination?", Answer = "When bees spread pollen between flowers", Options = new[] { "When bees spread pollen between flowers", "When bees make honey", "When flowers open", "When plants grow tall" } },
            new { Text = "Water exists in three states: solid (ice), liquid (water), and gas (water vapor). When water freezes, it becomes ice. When it boils, it becomes water vapor. These changes are called phase changes.", Question = "What happens when water boils?", Answer = "It becomes water vapor", Options = new[] { "It becomes water vapor", "It becomes ice", "It stays the same", "It becomes solid" } }
        };

        var selected = passages[_random.Next(passages.Length)];
        problem.Passage = selected.Text;
        problem.Question = selected.Question;
        problem.CorrectAnswer = selected.Answer;
        problem.Options = selected.Options.ToList();
        problem.Explanation = $"The passage states: {selected.Answer}";
    }

    private ScienceProblem GenerateScienceProblem(DifficultyLevel difficulty, GradeLevel grade)
    {
        var problem = new ScienceProblem
        {
            Difficulty = difficulty,
            Grade = grade,
            TimeLimit = GetTimeLimit(difficulty),
            PointValue = CalculatePointValue(difficulty)
        };

        switch (_random.Next(3))
        {
            case 0: // Biology
                GenerateBiologyProblem(problem, difficulty);
                break;
            case 1: // Physics
                GeneratePhysicsProblem(problem, difficulty);
                break;
            case 2: // Earth Science
                GenerateEarthScienceProblem(problem, difficulty);
                break;
        }

        return problem;
    }

    private void GenerateBiologyProblem(ScienceProblem problem, DifficultyLevel difficulty)
    {
        var questions = new[]
        {
            new { Q = "What do plants need to make their own food?", A = "Sunlight, water, and carbon dioxide", Opts = new[] { "Sunlight, water, and carbon dioxide", "Only water", "Only sunlight", "Oxygen and soil" } },
            new { Q = "What is the largest organ in the human body?", A = "Skin", Opts = new[] { "Skin", "Heart", "Brain", "Liver" } },
            new { Q = "What gas do plants produce during photosynthesis?", A = "Oxygen", Opts = new[] { "Oxygen", "Carbon dioxide", "Nitrogen", "Hydrogen" } }
        };

        var selected = questions[_random.Next(questions.Length)];
        problem.Question = selected.Q;
        problem.CorrectAnswer = selected.A;
        problem.Options = selected.Opts.ToList();
        problem.Explanation = $"The correct answer is: {selected.A}";
    }

    private void GeneratePhysicsProblem(ScienceProblem problem, DifficultyLevel difficulty)
    {
        var questions = new[]
        {
            new { Q = "What force pulls objects toward Earth?", A = "Gravity", Opts = new[] { "Gravity", "Magnetism", "Friction", "Wind" } },
            new { Q = "What happens to water at 100°C (212°F)?", A = "It boils", Opts = new[] { "It boils", "It freezes", "It melts", "Nothing" } },
            new { Q = "What type of energy does a moving car have?", A = "Kinetic energy", Opts = new[] { "Kinetic energy", "Potential energy", "Chemical energy", "No energy" } }
        };

        var selected = questions[_random.Next(questions.Length)];
        problem.Question = selected.Q;
        problem.CorrectAnswer = selected.A;
        problem.Options = selected.Opts.ToList();
        problem.Explanation = $"The correct answer is: {selected.A}";
    }

    private void GenerateEarthScienceProblem(ScienceProblem problem, DifficultyLevel difficulty)
    {
        var questions = new[]
        {
            new { Q = "What is the center of our solar system?", A = "The Sun", Opts = new[] { "The Sun", "Earth", "The Moon", "Mars" } },
            new { Q = "What causes day and night on Earth?", A = "Earth's rotation", Opts = new[] { "Earth's rotation", "The Moon", "The Sun moving", "Clouds" } },
            new { Q = "What is the closest planet to the Sun?", A = "Mercury", Opts = new[] { "Mercury", "Venus", "Earth", "Mars" } }
        };

        var selected = questions[_random.Next(questions.Length)];
        problem.Question = selected.Q;
        problem.CorrectAnswer = selected.A;
        problem.Options = selected.Opts.ToList();
        problem.Explanation = $"The correct answer is: {selected.A}";
    }

    private List<string> GenerateMultipleChoice(int correctAnswer, int maxRange)
    {
        var options = new HashSet<int> { correctAnswer };
        
        while (options.Count < 4)
        {
            int option;
            if (_random.Next(2) == 0)
            {
                option = correctAnswer + _random.Next(1, Math.Max(2, maxRange / 10));
            }
            else
            {
                option = correctAnswer - _random.Next(1, Math.Max(2, maxRange / 10));
            }
            
            if (option > 0 && option != correctAnswer)
            {
                options.Add(option);
            }
        }

        return options.OrderBy(x => _random.Next()).Select(x => x.ToString()).ToList();
    }

    private int GetMaxNumber(DifficultyLevel difficulty, GradeLevel grade)
    {
        return difficulty switch
        {
            DifficultyLevel.Easy => (int)grade * 10,
            DifficultyLevel.Medium => (int)grade * 15,
            DifficultyLevel.Hard => (int)grade * 20,
            DifficultyLevel.Expert => (int)grade * 25,
            _ => 50
        };
    }

    private int GetTimeLimit(DifficultyLevel difficulty)
    {
        return difficulty switch
        {
            DifficultyLevel.Easy => 60,
            DifficultyLevel.Medium => 45,
            DifficultyLevel.Hard => 30,
            DifficultyLevel.Expert => 20,
            _ => 45
        };
    }

    private int CalculatePointValue(DifficultyLevel difficulty)
    {
        return difficulty switch
        {
            DifficultyLevel.Easy => 10,
            DifficultyLevel.Medium => 20,
            DifficultyLevel.Hard => 30,
            DifficultyLevel.Expert => 50,
            _ => 10
        };
    }
}
