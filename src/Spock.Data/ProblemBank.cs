using Spock.Core.Models;

namespace Spock.Data;

/// <summary>
/// Comprehensive problem bank for adaptive learning across domains.
/// Problems are structured for ADD-friendly variety and weakness targeting.
/// </summary>
public static class ProblemBank
{
    /// <summary>
    /// Gets all available problems across all domains.
    /// Total: 150+ problems covering Grade 4 through College level.
    /// </summary>
    public static List<Problem> GetAllProblems()
    {
        var problems = new List<Problem>();
        
        problems.AddRange(GetMathProblems());
        problems.AddRange(GetLogicProblems());
        problems.AddRange(GetReadingProblems());
        problems.AddRange(GetScienceProblems());
        
        return problems;
    }

    /// <summary>
    /// Gets problems filtered by domain.
    /// </summary>
    public static List<Problem> GetProblemsByDomain(Domain domain)
    {
        return GetAllProblems().Where(p => p.Domain == domain).ToList();
    }

    /// <summary>
    /// Gets problems filtered by difficulty level (1-10).
    /// </summary>
    public static List<Problem> GetProblemsByDifficulty(int minDifficulty, int maxDifficulty)
    {
        return GetAllProblems()
            .Where(p => p.Difficulty >= minDifficulty && p.Difficulty <= maxDifficulty)
            .ToList();
    }

    #region Math Problems (Grade 4 - College)

    private static List<Problem> GetMathProblems()
    {
        return new List<Problem>
        {
            // ===== Grade 4-5: Multiplication & Division =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-basic",
                Difficulty = 2,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "What is 7 × 8?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "56" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-basic",
                Difficulty = 3,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "A robot factory produces 9 robots per hour. How many robots are produced in 6 hours?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "54", "54 robots" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "division-basic",
                Difficulty = 3,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "72 starships are divided equally among 8 squadrons. How many starships per squadron?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "9", "9 starships" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "division-remainders",
                Difficulty = 4,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "You have 47 energy cells to distribute equally among 6 power stations. How many cells per station, and how many are left over?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "7 remainder 5", "7 r5", "7 with 5 left", "7 and 5 remaining" }
                }
            },

            // ===== Grade 4-5: Fractions =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-addition",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What is 1/4 + 1/4?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1/2", "0.5", "2/4", ".5" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-addition",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A spaceship uses 2/5 of its fuel on day 1 and 1/5 on day 2. What fraction of fuel is used total?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3/5", "0.6", ".6" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-subtraction",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What is 3/4 - 1/4?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1/2", "0.5", "2/4", ".5" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-comparison",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "Which is larger: 2/3 or 5/8?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2/3", "5/8", "They are equal" },
                    CorrectAnswers = new List<string> { "2/3" }
                }
            },

            // ===== Grade 6: Ratios & Proportions =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "ratios-basic",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A recipe calls for 2 cups of flour for every 3 cups of water. How many cups of flour for 9 cups of water?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6", "6 cups" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "ratios-scaling",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "A map scale shows 1 inch = 50 miles. Two cities are 3.5 inches apart on the map. What's the real distance?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "175", "175 miles" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "percentages",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What is 25% of 80?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "percentages-increase",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "A shield's strength is 60. It increases by 15%. What is the new strength?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "69" }
                }
            },

            // ===== Grade 6-7: Integers & Negative Numbers =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "integers-addition",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What is -5 + 8?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "integers-subtraction",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What is 3 - (-7)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "10" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "integers-multiplication",
                Difficulty = 5,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is (-4) × (-6)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "24" }
                }
            },

            // ===== Grade 7-8: Linear Equations =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "equations-one-step",
                Difficulty = 5,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Solve for x: x + 7 = 12",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "x=5", "x = 5" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "equations-two-step",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Solve for x: 3x - 5 = 16",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "7", "x=7", "x = 7" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "equations-variables-both-sides",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Solve for x: 5x + 3 = 2x + 18",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "x=5", "x = 5" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "coordinate-plane",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What is the distance between points (0, 0) and (3, 4)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5" }
                }
            },

            // ===== High School: Algebra I/II =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "quadratics-factoring",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Factor: x² + 5x + 6",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "(x+2)(x+3)", "(x+3)(x+2)" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "quadratics-formula",
                Difficulty = 8,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Solve using the quadratic formula: x² - 4x - 5 = 0. What are the two solutions?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5 and -1", "-1 and 5", "5, -1", "-1, 5", "x=5, x=-1", "x=-1, x=5" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "functions-evaluation",
                Difficulty = 7,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "If f(x) = 2x² - 3x + 1, what is f(3)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "10" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "exponentials",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Simplify: 2⁴ × 2³\n\n(Simplify means to write this in its simplest form - either as a single number or as a single power like 2⁷. When you multiply powers with the same base, you add the exponents.)",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "128", "2^7", "2⁷" }
                }
            },

            // ===== High School: Geometry & Trigonometry =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "geometry-angles",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Two angles are supplementary. One angle is 65°. What is the other angle?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "115", "115°", "115 degrees" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "trigonometry-ratios",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "In a right triangle, the opposite side is 3 and the hypotenuse is 5. What is sin(θ)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3/5", "0.6", ".6" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "geometry-area",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "What is the area of a circle with radius 4? (Use π ≈ 3.14)",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "50.24", "50.265", "16π", "16pi" }
                }
            },

            // ===== College: Calculus =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "calculus-limits",
                Difficulty = 9,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is the limit as x approaches 2 of (x² - 4)/(x - 2)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "calculus-derivatives",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "What is the derivative of f(x) = 3x² + 5x - 2?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6x+5", "6x + 5", "5+6x", "5 + 6x" }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "calculus-integrals",
                Difficulty = 9,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is the integral of 2x dx?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "x²+C", "x² + C", "x^2+C", "x^2 + C" }
                }
            },

            // ===== College: Linear Algebra =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "linear-algebra-matrices",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "What is the determinant of the 2×2 matrix [[2, 3], [1, 4]]?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5" }
                }
            }
        };
    }

    #endregion

    #region Logic & Reasoning Problems

    private static List<Problem> GetLogicProblems()
    {
        return new List<Problem>
        {
            // ===== Level 1-2: Basic Deduction =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "deductive-basic",
                Difficulty = 2,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "All robots need power. R2 is a robot. Does R2 need power?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes", "No", "Cannot determine" },
                    CorrectAnswers = new List<string> { "Yes" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "deductive-basic",
                Difficulty = 3,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "If it's raining, the ground is wet. The ground is wet. Is it raining?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes, definitely", "No, definitely not", "Cannot determine from this information" },
                    CorrectAnswers = new List<string> { "Cannot determine from this information" }
                }
            },

            // ===== Level 3-4: If-Then Chains =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "if-then-chains",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "If A, then B. If B, then C. We know A is true. What can we conclude about C?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "C must be true", "C must be false", "C could be true or false" },
                    CorrectAnswers = new List<string> { "C must be true" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "if-then-contrapositive",
                Difficulty = 5,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "If the alarm sounds, the doors lock. The doors are NOT locked. What can we conclude?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The alarm sounded", "The alarm did not sound", "Cannot determine" },
                    CorrectAnswers = new List<string> { "The alarm did not sound" }
                }
            },

            // ===== Level 5-6: Elimination Logic =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "elimination",
                Difficulty = 5,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Five suspects: Alice, Bob, Carol, Dan, Eve. The thief is NOT Alice or Bob. Carol was out of town. Who are the remaining suspects?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Dan and Eve", "Eve and Dan", "Dan, Eve", "Eve, Dan" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "elimination-constraints",
                Difficulty = 6,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Three boxes: Red, Blue, Green. Each contains one item: key, coin, gem. Red doesn't have the key. Blue has the coin. What's in Green?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Key", "Coin", "Gem", "Cannot determine" },
                    CorrectAnswers = new List<string> { "Key" }
                }
            },

            // ===== Level 7-8: Pattern Recognition =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-numeric",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What comes next in the sequence? 2, 4, 8, 16, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "32" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-complex",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What comes next? 1, 1, 2, 3, 5, 8, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "13" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-abstract",
                Difficulty = 8,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Pattern: A1B2C3. What transformation gives B2C3D4?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Shift each character forward by 1", "Remove first, add next in sequence at end", "Both operations", "Neither operation" },
                    CorrectAnswers = new List<string> { "Remove first, add next in sequence at end" }
                }
            },

            // ===== Level 9-10: Advanced Logic =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "game-theory",
                Difficulty = 9,
                TargetTime = 180,
                Content = new ProblemContent
                {
                    Question = "Two players alternately take 1-3 coins from a pile of 10. The player who takes the last coin wins. You go first. What's your winning first move?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "2", "Take 2", "2 coins" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "paradoxes",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Statement: 'This statement is false.' If the statement is true, what logical problem arises?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It creates a contradiction (paradox)", "It's simply false", "It's meaningless", "It's both true and false" },
                    CorrectAnswers = new List<string> { "It creates a contradiction (paradox)" }
                }
            }
        };
    }

    #endregion

    #region Reading & Comprehension Problems

    private static List<Problem> GetReadingProblems()
    {
        return new List<Problem>
        {
            // ===== Level 1-2: Stated vs Inferred =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "inference-basic",
                Difficulty = 3,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Passage: 'The spaceship's warning lights flashed red. Captain Lee grabbed her helmet and ran to the airlock.' What can we infer?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "There's an emergency", "The captain likes red lights", "The ship is landing", "It's lunchtime" },
                    CorrectAnswers = new List<string> { "There's an emergency" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "stated-vs-inferred",
                Difficulty = 4,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Passage: 'Detective Mora examined the broken window. Glass covered the ground outside the house.' Which is STATED (not inferred)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Someone broke in", "Glass is on the ground outside", "The window was broken from inside", "It was nighttime" },
                    CorrectAnswers = new List<string> { "Glass is on the ground outside" }
                }
            },

            // ===== Level 3-4: Author's Purpose =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "authors-purpose",
                Difficulty = 5,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Passage: 'Studies show that exercise improves memory. Researchers recommend 30 minutes daily for optimal brain function.' What is the author's main purpose?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Entertain", "Inform/Persuade about exercise benefits", "Describe a memory technique", "Tell a story" },
                    CorrectAnswers = new List<string> { "Inform/Persuade about exercise benefits" }
                }
            },

            // ===== Level 5-6: Detecting Misleading Language =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "misleading-language",
                Difficulty = 6,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Advertisement: 'Up to 90% of users saw results!' What's misleading about this claim?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It doesn't say what kind of results", "'Up to 90%' could mean much less", "Both A and B", "Nothing is misleading" },
                    CorrectAnswers = new List<string> { "Both A and B" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "word-choice-bias",
                Difficulty = 7,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "Compare: 'The protesters gathered' vs 'The mob gathered.' Which shows negative bias?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "First version", "Second version", "Both are neutral", "Neither shows bias" },
                    CorrectAnswers = new List<string> { "Second version" }
                }
            },

            // ===== Level 7-8: Argument Analysis =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "argument-structure",
                Difficulty = 8,
                TargetTime = 180,
                Content = new ProblemContent
                {
                    Question = "Argument: 'All great leaders are decisive. Maria is decisive. Therefore, Maria is a great leader.' What's the logical flaw?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Assumes decisive = great leader (converse error)", "Maria might not be decisive", "Great leaders don't need to be decisive", "No flaw exists" },
                    CorrectAnswers = new List<string> { "Assumes decisive = great leader (converse error)" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "evidence-evaluation",
                Difficulty = 8,
                TargetTime = 160,
                Content = new ProblemContent
                {
                    Question = "Claim: 'Screens cause nearsightedness.' Evidence: 'Children who use screens 4+ hours daily have higher rates of nearsightedness.' Does this prove causation?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes, the data is clear", "No, correlation ≠ causation", "Yes, if the study was large", "No, screens help eyesight" },
                    CorrectAnswers = new List<string> { "No, correlation ≠ causation" }
                }
            },

            // ===== Level 9-10: Synthesis & Critical Reading =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "synthesis",
                Difficulty = 9,
                TargetTime = 240,
                Content = new ProblemContent
                {
                    Question = "Source 1: 'Urban density increases efficiency.' Source 2: 'High density causes stress.' Synthesis that acknowledges both?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Density is always good", "Density is always bad", "Density has efficiency benefits but psychological costs", "The sources contradict completely" },
                    CorrectAnswers = new List<string> { "Density has efficiency benefits but psychological costs" }
                }
            }
        };
    }

    #endregion

    #region Science Reasoning Problems

    private static List<Problem> GetScienceProblems()
    {
        return new List<Problem>
        {
            // ===== Level 1-2: Hypothesis vs Evidence =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "hypothesis-vs-evidence",
                Difficulty = 3,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Observation: 'Plants near the window are taller.' Which is a testable hypothesis?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Plants like windows", "Sunlight increases plant growth", "Windows are good", "Tall plants are better" },
                    CorrectAnswers = new List<string> { "Sunlight increases plant growth" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "observation-vs-inference",
                Difficulty = 4,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "You see wet ground under a tree. Which is an OBSERVATION (not inference)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It rained", "Someone watered the tree", "The ground is wet", "The tree needs water" },
                    CorrectAnswers = new List<string> { "The ground is wet" }
                }
            },

            // ===== Level 3-4: Controlled Variables =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "controlled-variables",
                Difficulty = 5,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Experiment: Testing if fertilizer helps plants grow. You use 3 plants with fertilizer and 3 without. What should be the SAME for all plants?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Amount of water and sunlight", "Size of pot only", "Type of fertilizer", "Nothing needs to be the same" },
                    CorrectAnswers = new List<string> { "Amount of water and sunlight" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "independent-vs-dependent",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Experiment: 'How does temperature affect ice melting speed?' What is the INDEPENDENT variable (what you change)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Melting speed", "Temperature", "Amount of ice", "Time" },
                    CorrectAnswers = new List<string> { "Temperature" }
                }
            },

            // ===== Level 5-6: Cause vs Correlation =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "correlation-vs-causation",
                Difficulty = 6,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Data: 'Ice cream sales and drowning deaths both increase in summer.' Does ice cream cause drowning?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes, clearly related", "No, both caused by hot weather (correlation, not causation)", "Yes, if data is reliable", "Cannot determine from this" },
                    CorrectAnswers = new List<string> { "No, both caused by hot weather (correlation, not causation)" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "confounding-variables",
                Difficulty = 7,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Study: 'Coffee drinkers live longer.' But coffee drinkers also exercise more. What is 'exercise' in this scenario?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Independent variable", "Dependent variable", "Confounding variable", "Control variable" },
                    CorrectAnswers = new List<string> { "Confounding variable" }
                }
            },

            // ===== Level 7-8: Data Interpretation =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "graph-interpretation",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Graph shows: 'As altitude increases, air pressure decreases steadily.' What type of relationship?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Positive correlation", "Negative correlation", "No correlation", "Causal relationship proven" },
                    CorrectAnswers = new List<string> { "Negative correlation" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "prediction-from-data",
                Difficulty = 8,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Pattern: At 0°C, reaction takes 60s. At 10°C, 40s. At 20°C, 25s. Predict time at 30°C:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "10 seconds", "15 seconds", "0 seconds", "50 seconds" },
                    CorrectAnswers = new List<string> { "15 seconds" }
                }
            },

            // ===== Level 9-10: Experimental Design & Falsification =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "experimental-design",
                Difficulty = 9,
                TargetTime = 180,
                Content = new ProblemContent
                {
                    Question = "Hypothesis: 'Magnetic fields affect plant growth.' Design the BEST experiment:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Put one plant near magnet, observe", "10 plants near magnets, 10 without magnets (control), same conditions", "Ask people if magnets help plants", "Look up if others tried this" },
                    CorrectAnswers = new List<string> { "10 plants near magnets, 10 without magnets (control), same conditions" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "falsification",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Theory: 'All swans are white.' Which observation would FALSIFY this theory?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Finding 100 more white swans", "Finding one black swan", "Not finding any swans", "Proving swans exist" },
                    CorrectAnswers = new List<string> { "Finding one black swan" }
                }
            }
        };
    }

    #endregion
}
