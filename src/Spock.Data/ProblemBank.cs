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
    /// Total: 180+ problems covering Grade 2 through College level.
    /// Includes: Math, Logic, Reading, Science, Washington History, Minecraft, Health, and Bitcoin.
    /// </summary>
    public static List<Problem> GetAllProblems()
    {
        var problems = new List<Problem>();
        
        problems.AddRange(GetMathProblems());
        problems.AddRange(GetLogicProblems());
        problems.AddRange(GetReadingProblems());
        problems.AddRange(GetScienceProblems());
        problems.AddRange(GetWashingtonHistoryProblems());
        problems.AddRange(GetBitcoinProblems());
        problems.AddRange(GetMinecraftProblems());
        problems.AddRange(GetHealthProblems());
        
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

    #region Washington History Problems (Grades 4-12)

    private static List<Problem> GetWashingtonHistoryProblems()
    {
        return new List<Problem>
        {
            // ===== Elementary (Grades 4-5): Basic Events and Geography =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "native-peoples",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Before European settlers arrived, who lived in the Pacific Northwest for thousands of years?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Vikings", "Native American tribes", "Spanish conquistadors", "British colonists" },
                    CorrectAnswers = new List<string> { "Native American tribes" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "geography",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is the capital city of Washington State?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Olympia", "olympia" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "geography",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Which mountain range divides Washington State into eastern and western regions?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Rocky Mountains", "Sierra Nevada", "Cascade Range", "Appalachian Mountains" },
                    CorrectAnswers = new List<string> { "Cascade Range" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "statehood",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "In what year did Washington become a state?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1776", "1853", "1889", "1912" },
                    CorrectAnswers = new List<string> { "1889" }
                }
            },
            
            // ===== Middle School (Grades 6-8): Exploration and Settlement =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "exploration",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Which explorers led an expedition across the continent and reached the Pacific Northwest in 1805?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Christopher Columbus and Amerigo Vespucci", "Lewis and Clark", "Francisco Pizarro and Hernán Cortés", "Marco Polo and Ibn Battuta" },
                    CorrectAnswers = new List<string> { "Lewis and Clark" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "native-tribes",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "The Coastal Salish peoples traditionally relied on which resource for food, tools, and cultural practices?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Salmon and other fish", "Buffalo herds", "Corn and wheat farming", "Gold mining" },
                    CorrectAnswers = new List<string> { "Salmon and other fish" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "territorial-period",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Before becoming a state, Washington was part of what larger territory?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "California Territory", "Oregon Territory", "Louisiana Territory", "Texas Territory" },
                    CorrectAnswers = new List<string> { "Oregon Territory" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "treaties",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "The Medicine Creek Treaty (1854) was significant because it:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ended all conflicts in Washington", "Established the first Native American reservations in the region", "Granted women the right to vote", "Created the state boundary" },
                    CorrectAnswers = new List<string> { "Established the first Native American reservations in the region" }
                }
            },
            
            // ===== High School (Grades 9-12): Economic Development and Modern Era =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "gold-rush",
                Difficulty = 7,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "The Klondike Gold Rush (1897-1899) significantly impacted which Washington city as a supply center?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Seattle", "seattle" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "industry",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Which industry historically dominated Washington's economy in the early 20th century?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cotton farming", "Timber/logging", "Automobile manufacturing", "Oil drilling" },
                    CorrectAnswers = new List<string> { "Timber/logging" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "world-war-ii",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "During World War II, the Hanford Site in Washington played a crucial role in:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Aircraft manufacturing", "Submarine construction", "The Manhattan Project (nuclear weapons development)", "Training military pilots" },
                    CorrectAnswers = new List<string> { "The Manhattan Project (nuclear weapons development)" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "civil-rights",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "The internment of Japanese Americans during WWII affected Washington significantly. What was the primary justification given by the government?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Economic competition", "Military security concerns", "Religious differences", "Language barriers" },
                    CorrectAnswers = new List<string> { "Military security concerns" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "modern-economy",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Which major corporation, founded in the Seattle area, revolutionized aviation manufacturing?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Boeing", "boeing" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "tech-industry",
                Difficulty = 9,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Washington became a tech hub partly due to companies like Microsoft and Amazon. What economic advantage did Washington offer these companies?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Free land from the government", "No state income tax", "Warm year-round climate", "Direct access to Silicon Valley" },
                    CorrectAnswers = new List<string> { "No state income tax" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "environmental-policy",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "The removal of dams on the Elwha River (2011-2014) was significant because it:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Increased hydroelectric power", "Was the largest dam removal project in U.S. history for ecosystem restoration", "Created new reservoirs", "Prevented all flooding" },
                    CorrectAnswers = new List<string> { "Was the largest dam removal project in U.S. history for ecosystem restoration" }
                }
            },
            
            // ===== Advanced (Grade 10-12): Analysis and Critical Thinking =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "historical-analysis",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Analyze the cause-and-effect relationship: How did the Cascade Mountain Range influence the political and economic differences between Eastern and Western Washington?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "The mountains created different climates, leading to different economies (logging/tech in west vs agriculture in east), which created political divisions", "Climate differences caused by mountains led to economic specialization and political divergence" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "treaty-analysis",
                Difficulty = 10,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "The Boldt Decision (1974) affirmed Native American treaty rights to fish. What broader principle did this establish?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Treaties are temporary agreements", "Native tribes have no legal authority", "Treaty rights persist even after statehood and remain legally binding", "Only federal law matters" },
                    CorrectAnswers = new List<string> { "Treaty rights persist even after statehood and remain legally binding" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "volcanic-history",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "The eruption of Mount St. Helens in 1980 was significant for scientific study because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It was the first volcanic eruption ever recorded", "Scientists could study ecosystem recovery in real-time", "It destroyed all life in Washington", "It created Puget Sound" },
                    CorrectAnswers = new List<string> { "Scientists could study ecosystem recovery in real-time" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "suffrage",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Washington granted women the right to vote in 1910, ten years before the national amendment. What does this tell us about state vs federal power?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "States have no independent power", "States can extend rights before federal law requires it", "Federal law always comes first", "Women couldn't actually vote until 1920" },
                    CorrectAnswers = new List<string> { "States can extend rights before federal law requires it" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "labor-history",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "The Seattle General Strike of 1919 was one of the first general strikes in U.S. history. Workers shut down the city for 5 days. What principle were they demonstrating?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Individual workers are powerless", "Collective labor action can exert significant economic pressure", "Strikes never work", "Only government can change working conditions" },
                    CorrectAnswers = new List<string> { "Collective labor action can exert significant economic pressure" }
                }
            }
        };
    }

    #endregion

    #region Bitcoin Problems (History & Fundamentals)

    private static List<Problem> GetBitcoinProblems()
    {
        return new List<Problem>
        {
            // ===== Elementary: Bitcoin Basics =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-creation",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "In what year was Bitcoin created?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2005", "2007", "2009", "2011" },
                    CorrectAnswers = new List<string> { "2009" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-creator",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Who is credited with creating Bitcoin (though their real identity remains unknown)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Elon Musk", "Satoshi Nakamoto", "Vitalik Buterin", "Steve Jobs" },
                    CorrectAnswers = new List<string> { "Satoshi Nakamoto" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-whitepaper",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What was the title of the original Bitcoin whitepaper published in 2008?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Digital Gold: The Future of Money", "Bitcoin: A Peer-to-Peer Electronic Cash System", "Cryptocurrency Revolution", "The Blockchain Manifesto" },
                    CorrectAnswers = new List<string> { "Bitcoin: A Peer-to-Peer Electronic Cash System" }
                }
            },

            // ===== Middle School: Key Concepts =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "blockchain-definition",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "What is a blockchain in the context of Bitcoin?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A type of chain worn as jewelry", "A distributed ledger of all transactions", "A single computer that stores all data", "A password encryption method" },
                    CorrectAnswers = new List<string> { "A distributed ledger of all transactions" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-supply",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What is the maximum number of bitcoins that will ever exist?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "21 million", "21000000", "21,000,000" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "mining-concept",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "What is Bitcoin mining?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Digging for physical bitcoins underground", "Using computers to verify transactions and secure the network", "Trading bitcoins on exchanges", "Printing new bitcoins" },
                    CorrectAnswers = new List<string> { "Using computers to verify transactions and secure the network" }
                }
            },

            // ===== High School: Historical Events =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "first-transaction",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "On May 22, 2010, programmer Laszlo Hanyecz made the first real-world Bitcoin purchase. What did he buy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A Tesla car", "Two pizzas", "A house", "A laptop" },
                    CorrectAnswers = new List<string> { "Two pizzas" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "halving-events",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What happens during a Bitcoin 'halving' event?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The price of Bitcoin is cut in half", "The mining reward is reduced by 50%", "Half of all bitcoins are destroyed", "Transaction fees are halved" },
                    CorrectAnswers = new List<string> { "The mining reward is reduced by 50%" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "decentralization",
                Difficulty = 8,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Why is decentralization important to Bitcoin's design?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It makes Bitcoin faster", "No single entity can control or censor transactions", "It reduces electricity costs", "It makes Bitcoin easier to use" },
                    CorrectAnswers = new List<string> { "No single entity can control or censor transactions" }
                }
            },

            // ===== College: Advanced Concepts =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "proof-of-work",
                Difficulty = 9,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is Proof-of-Work (PoW) in Bitcoin?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A receipt showing you completed work", "A consensus mechanism requiring computational effort to validate transactions", "A certificate from miners", "A type of Bitcoin wallet" },
                    CorrectAnswers = new List<string> { "A consensus mechanism requiring computational effort to validate transactions" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "byzantine-generals",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Bitcoin solves the 'Byzantine Generals Problem.' What does this mean?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It prevents military attacks", "It allows agreement in a trustless network with potential bad actors", "It encrypts military communications", "It names transactions after generals" },
                    CorrectAnswers = new List<string> { "It allows agreement in a trustless network with potential bad actors" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "economic-theory",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's fixed supply of 21 million is designed to combat which economic phenomenon?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Deflation", "Inflation", "Recession", "Monopoly" },
                    CorrectAnswers = new List<string> { "Inflation" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "cryptographic-security",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Bitcoin uses which cryptographic hash function to secure its blockchain?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "MD5", "SHA-1", "SHA-256", "AES-128" },
                    CorrectAnswers = new List<string> { "SHA-256" }
                }
            }
        };
    }

    #endregion

    #region Minecraft Problems (Grades 1-12)

    private static List<Problem> GetMinecraftProblems()
    {
        return new List<Problem>
        {
            // ===== Elementary (Grades 1-3): Basic Blocks & Mechanics =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "block-identification",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "Which block do you get when you mine stone with a pickaxe?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Stone", "Cobblestone", "Gravel", "Dirt" },
                    CorrectAnswers = new List<string> { "Cobblestone" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "crafting-basic",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "How many wooden planks do you need to craft a crafting table?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4", "four" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "mob-recognition",
                Difficulty = 2,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "Which mob is friendly and gives you wool?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Zombie", "Sheep", "Creeper", "Spider" },
                    CorrectAnswers = new List<string> { "Sheep" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "biome-basics",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "In which biome would you find lots of sand and cacti?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Forest", "Desert", "Plains", "Swamp" },
                    CorrectAnswers = new List<string> { "Desert" }
                }
            },

            // ===== Upper Elementary (Grades 4-5): Advanced Crafting & Resources =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "crafting-advanced",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "You need full iron armor and an iron sword. How many iron ingots total?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "26", "twenty-six" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "enchantment-basics",
                Difficulty = 4,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What material do you need to make an enchanting table?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Iron and gold", "Diamonds and obsidian", "Emeralds and lapis", "Redstone and glowstone" },
                    CorrectAnswers = new List<string> { "Diamonds and obsidian" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "redstone-fundamentals",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What does a redstone torch do when the block it's attached to receives power?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It turns on", "It turns off", "It explodes", "Nothing changes" },
                    CorrectAnswers = new List<string> { "It turns off" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "farming-mechanics",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What happens when you breed two cows with wheat?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "They give milk", "They spawn a baby cow", "They drop leather", "They become faster" },
                    CorrectAnswers = new List<string> { "They spawn a baby cow" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "dimensions-intro",
                Difficulty = 5,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What material do you need to build a Nether portal frame?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Obsidian", "obsidian" }
                }
            },

            // ===== Middle School (Grades 6-8): Redstone Logic & Advanced Mechanics =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "redstone-logic-gates",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "To create an AND gate in Minecraft redstone, both inputs must be active to produce output. How many redstone torches are needed for a basic 2-input AND gate?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3", "three" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "redstone-circuits",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "A redstone repeater has a maximum delay setting of how many ticks?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2 ticks", "4 ticks", "8 ticks", "16 ticks" },
                    CorrectAnswers = new List<string> { "4 ticks" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "potion-brewing",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "To brew a Potion of Healing, you start with an Awkward Potion. What ingredient do you add?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Glistering Melon", "Golden Carrot", "Magma Cream", "Spider Eye" },
                    CorrectAnswers = new List<string> { "Glistering Melon" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "game-mechanics-optimization",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "A mob spawner can spawn mobs up to how many blocks away horizontally?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4", "four" }
                }
            },

            // ===== High School (Grades 9-12): Advanced Redstone & Game Engine =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "redstone-computers",
                Difficulty = 8,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "A basic redstone calculator that adds two 2-bit numbers needs how many AND gates?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2", "4", "6", "8" },
                    CorrectAnswers = new List<string> { "4" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "command-blocks",
                Difficulty = 9,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "In a command block, what selector targets the nearest player?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "@p", "@p", "@ p" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "game-engine-mechanics",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Minecraft's game loop runs at how many ticks per second (TPS) under normal conditions?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20", "twenty" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "chunk-loading",
                Difficulty = 10,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "A Minecraft chunk is how many blocks wide (X) by how many blocks deep (Z)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "16x16", "16 x 16", "16 by 16" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "optimization-strategies",
                Difficulty = 10,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "For maximum efficiency, automatic farms should operate within how many chunks of a player?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2 chunks", "4 chunks", "8 chunks", "12 chunks" },
                    CorrectAnswers = new List<string> { "8 chunks" }
                }
            }
        };
    }

    #endregion

    #region Health Problems (Grades 1-12)

    private static List<Problem> GetHealthProblems()
    {
        return new List<Problem>
        {
            // ===== Elementary (Grades 1-3): Basic Health & Hygiene =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "hygiene-basics",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "How long should you wash your hands with soap?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "5 seconds", "20 seconds", "1 minute", "5 minutes" },
                    CorrectAnswers = new List<string> { "20 seconds" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "body-basics",
                Difficulty = 1,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "Which organ pumps blood throughout your body?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Brain", "Heart", "Lungs", "Stomach" },
                    CorrectAnswers = new List<string> { "Heart" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "nutrition-recognition",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "Which food is the healthiest snack?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Candy bar", "Apple", "Chips", "Soda" },
                    CorrectAnswers = new List<string> { "Apple" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "sleep-importance",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "How many hours of sleep should a 7-year-old get each night?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "6-7 hours", "9-11 hours", "12-14 hours", "15-16 hours" },
                    CorrectAnswers = new List<string> { "9-11 hours" }
                }
            },

            // ===== Upper Elementary (Grades 4-5): Nutrition & Exercise =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "nutrition-food-groups",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "A balanced meal should include foods from how many different food groups?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1-2 groups", "3-4 groups", "5-6 groups", "Only protein" },
                    CorrectAnswers = new List<string> { "3-4 groups" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "exercise-benefits",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Regular exercise helps your body by doing what?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only building muscles", "Only losing weight", "Strengthening heart, muscles, and improving mood", "Making you tired" },
                    CorrectAnswers = new List<string> { "Strengthening heart, muscles, and improving mood" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "first-aid-basics",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What's the first thing you should do if you get a small cut?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cover it immediately", "Wash it with clean water", "Apply a bandage", "Ignore it" },
                    CorrectAnswers = new List<string> { "Wash it with clean water" }
                }
            },

            // ===== Middle School (Grades 6-8): Nutrition Science & Mental Health =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "nutrition-labels",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "On a nutrition label, a food with 20% Daily Value of a nutrient is considered what?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Low in that nutrient", "High in that nutrient", "Medium in that nutrient", "Unhealthy" },
                    CorrectAnswers = new List<string> { "High in that nutrient" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "mental-health-awareness",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Feeling stressed or anxious sometimes is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always a sign of mental illness", "Normal and happens to everyone", "Something to ignore", "Only happens to adults" },
                    CorrectAnswers = new List<string> { "Normal and happens to everyone" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "physical-fitness",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Which type of exercise strengthens your cardiovascular system?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Weightlifting only", "Aerobic exercise like running or swimming", "Stretching only", "Standing still" },
                    CorrectAnswers = new List<string> { "Aerobic exercise like running or swimming" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "sleep-science",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Blue light from screens before bed can affect sleep by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Making you fall asleep faster", "Disrupting melatonin production", "Improving dream quality", "Having no effect" },
                    CorrectAnswers = new List<string> { "Disrupting melatonin production" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "peer-pressure",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Your friend pressures you to try vaping. The best response is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Try it to fit in", "Firmly decline and explain health risks", "Make fun of them", "Ignore them but feel guilty" },
                    CorrectAnswers = new List<string> { "Firmly decline and explain health risks" }
                }
            },

            // ===== High School (Grades 9-12): Advanced Health Science =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "macronutrients",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Carbohydrates provide how many calories per gram?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4", "four" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "exercise-physiology",
                Difficulty = 8,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "During intense exercise, muscles can produce energy anaerobically, creating what byproduct?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Oxygen", "Carbon dioxide", "Lactic acid", "Glucose" },
                    CorrectAnswers = new List<string> { "Lactic acid" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "mental-health-conditions",
                Difficulty = 8,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Clinical depression differs from normal sadness because it:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only lasts a day", "Persists for weeks/months and impacts daily functioning", "Is less severe", "Only affects mood" },
                    CorrectAnswers = new List<string> { "Persists for weeks/months and impacts daily functioning" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "substance-awareness",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Nicotine addiction works by affecting which neurotransmitter in the brain?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Serotonin", "Dopamine", "GABA", "Glutamate" },
                    CorrectAnswers = new List<string> { "Dopamine" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "chronic-disease-prevention",
                Difficulty = 9,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Type 2 diabetes is primarily caused by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Genetic factors only", "Viral infection", "Insulin resistance often linked to obesity and lifestyle", "Lack of vitamins" },
                    CorrectAnswers = new List<string> { "Insulin resistance often linked to obesity and lifestyle" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "healthcare-navigation",
                Difficulty = 10,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "When researching health information online, the most reliable sources include:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Social media influencers", "Random blogs", "CDC, WHO, peer-reviewed medical journals", "Product advertisements" },
                    CorrectAnswers = new List<string> { "CDC, WHO, peer-reviewed medical journals" }
                }
            }
        };
    }

    #endregion
}
