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
                    CorrectAnswers = new List<string> { "56" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Break it into smaller parts you know, like 7 × 5 plus 7 × 3",
                        StepsDetailed = new List<string>
                        {
                            "7 × 8 means 'add 7 to itself 8 times'",
                            "You can break 8 into 5 + 3",
                            "7 × 5 = 35 (you might know this one)",
                            "7 × 3 = 21",
                            "35 + 21 = 56"
                        },
                        WorkedExample = "7 × 8 = 7 × (5 + 3) = (7 × 5) + (7 × 3) = 35 + 21 = 56",
                        KeyPrinciple = "Multiplication is repeated addition. Break large problems into smaller known facts.",
                        CommonMistake = "Students often confuse 7 × 8 with 7 + 8. Multiplication means '7 groups of 8' not '7 plus 8'."
                    }
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
                    CorrectAnswers = new List<string> { "54", "54 robots" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "How many robots per hour? Multiply by the number of hours",
                        StepsDetailed = new List<string>
                        {
                            "Identify what you know: 9 robots per hour, 6 hours total",
                            "This is a multiplication problem: rate × time = total",
                            "Multiply: 9 × 6",
                            "You can use skip counting: 9, 18, 27, 36, 45, 54",
                            "Or break it down: (9 × 5) + (9 × 1) = 45 + 9 = 54"
                        },
                        WorkedExample = "9 robots/hour × 6 hours = 9 × 6 = 54 robots total",
                        KeyPrinciple = "Word problems use multiplication when finding a total from a rate (amount per unit) times a quantity. Look for 'per' language.",
                        CommonMistake = "Students sometimes add instead of multiply (9 + 6 = 15). Remember: 'per hour for 6 hours' means multiply, not add."
                    }
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
                    CorrectAnswers = new List<string> { "9", "9 starships" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Divide the total by the number of groups",
                        StepsDetailed = new List<string>
                        {
                            "You have 72 total starships to share equally",
                            "You need to divide them into 8 equal groups",
                            "Set up the division: 72 ÷ 8",
                            "Think: 8 × ? = 72",
                            "Since 8 × 9 = 72, the answer is 9"
                        },
                        WorkedExample = "72 ÷ 8 = 9 starships per squadron (Check: 8 × 9 = 72 ✓)",
                        KeyPrinciple = "Division splits a total into equal groups. 'Divided equally among' signals division. Check your answer by multiplying.",
                        CommonMistake = "Confusing which number to divide by. Remember: total ÷ number of groups = amount per group, not the other way around."
                    }
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
                    CorrectAnswers = new List<string> { "7 remainder 5", "7 r5", "7 with 5 left", "7 and 5 remaining" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Find how many 6s fit into 47, then see what's left",
                        StepsDetailed = new List<string>
                        {
                            "Think: How many times does 6 fit into 47?",
                            "6 × 7 = 42 (this fits)",
                            "6 × 8 = 48 (too big!)",
                            "So each station gets 7 cells",
                            "Subtract to find remainder: 47 - 42 = 5 cells left over"
                        },
                        WorkedExample = "47 ÷ 6 = 7 remainder 5 (Check: 6 × 7 + 5 = 42 + 5 = 47 ✓)",
                        KeyPrinciple = "When division doesn't come out even, express the answer as quotient and remainder. The remainder is always smaller than the divisor.",
                        CommonMistake = "Forgetting to include the remainder, or writing just '7'. Always state both parts when items don't divide evenly."
                    }
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
                    CorrectAnswers = new List<string> { "1/2", "0.5", "2/4", ".5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "The denominators are already the same - just add the numerators",
                        StepsDetailed = new List<string>
                        {
                            "Check if denominators match: both are 4 ✓",
                            "Keep the denominator: 4",
                            "Add the numerators: 1 + 1 = 2",
                            "Write the answer: 2/4",
                            "Simplify by dividing both parts by 2: 2/4 = 1/2"
                        },
                        WorkedExample = "1/4 + 1/4 = (1+1)/4 = 2/4 = 1/2",
                        KeyPrinciple = "When adding fractions with the same denominator, keep the denominator and add the numerators. Then simplify if possible.",
                        CommonMistake = "Students often add both numerators AND denominators (1/4 + 1/4 = 2/8). Only add the numerators when denominators match!"
                    }
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
                    CorrectAnswers = new List<string> { "3/5", "0.6", ".6" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Same denominator - just add the top numbers",
                        StepsDetailed = new List<string>
                        {
                            "Check denominators: both fractions have 5 (fifths)",
                            "Keep the denominator: 5",
                            "Add the numerators: 2 + 1 = 3",
                            "Write the answer: 3/5",
                            "This fraction is already simplified"
                        },
                        WorkedExample = "2/5 + 1/5 = (2+1)/5 = 3/5 of fuel used",
                        KeyPrinciple = "When adding fractions with the same denominator, keep the denominator and add only the numerators. Think of it as adding pieces of the same size.",
                        CommonMistake = "Adding both tops AND bottoms (2/5 + 1/5 = 3/10 is wrong). Only add numerators when denominators match!"
                    }
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
                    CorrectAnswers = new List<string> { "1/2", "0.5", "2/4", ".5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Same denominator - subtract the top numbers only",
                        StepsDetailed = new List<string>
                        {
                            "Check denominators: both are 4 ✓",
                            "Keep the denominator: 4",
                            "Subtract the numerators: 3 - 1 = 2",
                            "Write the answer: 2/4",
                            "Simplify: 2/4 = 1/2 (divide both by 2)"
                        },
                        WorkedExample = "3/4 - 1/4 = (3-1)/4 = 2/4 = 1/2",
                        KeyPrinciple = "Subtracting fractions with the same denominator works like addition: keep the denominator, subtract the numerators. Always simplify your final answer.",
                        CommonMistake = "Subtracting denominators too (3/4 - 1/4 = 2/0 is wrong). Never subtract the bottom numbers when denominators match!"
                    }
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
                    CorrectAnswers = new List<string> { "2/3" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Convert both to the same denominator, or use decimals",
                        StepsDetailed = new List<string>
                        {
                            "Find a common denominator: 3 × 8 = 24",
                            "Convert 2/3: (2×8)/(3×8) = 16/24",
                            "Convert 5/8: (5×3)/(8×3) = 15/24",
                            "Compare: 16/24 vs 15/24",
                            "16/24 is larger, so 2/3 > 5/8"
                        },
                        WorkedExample = "2/3 = 16/24 and 5/8 = 15/24. Since 16 > 15, then 2/3 > 5/8",
                        KeyPrinciple = "To compare fractions with different denominators, convert to a common denominator. Then compare numerators. Or convert to decimals (2/3 ≈ 0.67, 5/8 = 0.625).",
                        CommonMistake = "Comparing numerators directly (2 vs 5) or denominators (3 vs 8) without converting. Fractions need the same denominator to compare!"
                    }
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
                    CorrectAnswers = new List<string> { "6", "6 cups" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "The ratio stays the same - how many times 3 fits into 9?",
                        StepsDetailed = new List<string>
                        {
                            "Identify the ratio: 2 cups flour per 3 cups water",
                            "Find the multiplier: 9 ÷ 3 = 3 (water tripled)",
                            "Apply same multiplier to flour: 2 × 3 = 6",
                            "Or set up proportion: 2/3 = x/9",
                            "Cross multiply: 3x = 18, so x = 6"
                        },
                        WorkedExample = "2:3 = x:9. Since 3 × 3 = 9, then 2 × 3 = 6 cups of flour",
                        KeyPrinciple = "Ratios maintain the same relationship. When one quantity is multiplied, multiply the other by the same factor to keep the ratio equivalent.",
                        CommonMistake = "Adding instead of multiplying (2 + 3 = 5, so 5 + 9 = 14). Ratios require multiplication, not addition!"
                    }
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
                    CorrectAnswers = new List<string> { "175", "175 miles" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Multiply the map distance by the scale factor",
                        StepsDetailed = new List<string>
                        {
                            "Understand the scale: 1 inch on map = 50 miles in reality",
                            "Map distance: 3.5 inches",
                            "Multiply: 3.5 × 50",
                            "Calculate: 3.5 × 50 = 175",
                            "Answer: 175 miles"
                        },
                        WorkedExample = "1 inch = 50 miles, so 3.5 inches = 3.5 × 50 = 175 miles",
                        KeyPrinciple = "Scale ratios show how measurements on a model relate to real life. Multiply the model measurement by the scale factor to find the actual distance.",
                        CommonMistake = "Dividing instead of multiplying (3.5 ÷ 50 = 0.07). When converting from small (map) to large (reality), multiply!"
                    }
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
                    CorrectAnswers = new List<string> { "20" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Convert 25% to a decimal (0.25) and multiply",
                        StepsDetailed = new List<string>
                        {
                            "Understand: 'of' means multiply in math",
                            "Convert 25% to decimal: 25% = 25/100 = 0.25",
                            "Multiply: 0.25 × 80",
                            "Calculate: 0.25 × 80 = 20",
                            "Or use shortcut: 25% = 1/4, so 80 ÷ 4 = 20"
                        },
                        WorkedExample = "25% of 80 = 0.25 × 80 = 20",
                        KeyPrinciple = "Percent means 'per hundred.' To find a percentage of a number, convert the percent to a decimal and multiply. 'Of' always means multiply.",
                        CommonMistake = "Forgetting to convert to decimal (25 × 80 = 2000). Always divide the percent by 100 first, or move decimal two places left!"
                    }
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
                    CorrectAnswers = new List<string> { "69" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Find 15% of 60, then add it to the original 60",
                        StepsDetailed = new List<string>
                        {
                            "Original strength: 60",
                            "Find the increase: 15% of 60 = 0.15 × 60 = 9",
                            "Add increase to original: 60 + 9 = 69",
                            "Shortcut: Multiply by 1.15 (which is 100% + 15%)",
                            "60 × 1.15 = 69"
                        },
                        WorkedExample = "15% of 60 = 0.15 × 60 = 9. New strength = 60 + 9 = 69. Or: 60 × 1.15 = 69",
                        KeyPrinciple = "Percent increase: find the increase amount, then add to the original. Shortcut: multiply by (1 + percent as decimal).",
                        CommonMistake = "Forgetting to add back the original (just saying 9 instead of 69). The shield doesn't become 9, it gains 9!"
                    }
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
                    CorrectAnswers = new List<string> { "3" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Think of it as owing 5, then receiving 8",
                        StepsDetailed = new List<string>
                        {
                            "You start at -5 on a number line",
                            "Adding positive 8 means moving 8 steps right",
                            "From -5, count up: -4, -3, -2, -1, 0, 1, 2, 3",
                            "Or think: subtract the smaller from larger: 8 - 5 = 3",
                            "Since 8 is larger and positive, answer is positive 3"
                        },
                        WorkedExample = "-5 + 8 = 8 - 5 = 3 (the sign of the larger number wins)",
                        KeyPrinciple = "Adding integers with different signs: subtract the smaller absolute value from the larger, and use the sign of the number with larger absolute value.",
                        CommonMistake = "Getting -13 by adding the numbers (5 + 8 = 13, then making it negative). Different signs mean subtract, not add!"
                    }
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
                    CorrectAnswers = new List<string> { "10" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Subtracting a negative is the same as adding a positive",
                        StepsDetailed = new List<string>
                        {
                            "Original problem: 3 - (-7)",
                            "Rule: Two negatives make a positive",
                            "Rewrite as: 3 + 7",
                            "Calculate: 3 + 7 = 10",
                            "Remember: Minus a negative equals plus"
                        },
                        WorkedExample = "3 - (-7) = 3 + 7 = 10",
                        KeyPrinciple = "Subtracting a negative number is the same as adding its opposite. The two negative signs cancel to become positive.",
                        CommonMistake = "Treating it as 3 - 7 = -4. The double negative is crucial! Subtracting negative 7 means adding 7."
                    }
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
                    CorrectAnswers = new List<string> { "24" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Negative times negative equals positive",
                        StepsDetailed = new List<string>
                        {
                            "Multiply the numbers: 4 × 6 = 24",
                            "Determine the sign: negative × negative = positive",
                            "Answer: +24 or just 24",
                            "Remember the rule: same signs = positive result",
                            "Different signs would give negative"
                        },
                        WorkedExample = "(-4) × (-6) = 24 (two negatives make a positive)",
                        KeyPrinciple = "When multiplying integers: same signs give positive, different signs give negative. Negative × Negative = Positive.",
                        CommonMistake = "Getting -24 because there are negatives in the problem. Two negatives cancel out to make a positive!"
                    }
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
                    CorrectAnswers = new List<string> { "5", "x=5", "x = 5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Undo the addition by subtracting 7 from both sides",
                        StepsDetailed = new List<string>
                        {
                            "Goal: Get x alone on one side",
                            "x + 7 = 12",
                            "Subtract 7 from both sides: x + 7 - 7 = 12 - 7",
                            "Simplify: x = 5",
                            "Check: 5 + 7 = 12 ✓"
                        },
                        WorkedExample = "x + 7 = 12 → x + 7 - 7 = 12 - 7 → x = 5",
                        KeyPrinciple = "To solve equations, isolate the variable by performing inverse operations on both sides. Addition is undone by subtraction.",
                        CommonMistake = "Subtracting 7 from only one side (x = 12 - 7 = 5 works but doesn't show the balance principle). Always do the same to both sides!"
                    }
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
                    CorrectAnswers = new List<string> { "7", "x=7", "x = 7" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "First add 5, then divide by 3",
                        StepsDetailed = new List<string>
                        {
                            "Start: 3x - 5 = 16",
                            "Add 5 to both sides: 3x - 5 + 5 = 16 + 5",
                            "Simplify: 3x = 21",
                            "Divide both sides by 3: 3x/3 = 21/3",
                            "Result: x = 7. Check: 3(7) - 5 = 21 - 5 = 16 ✓"
                        },
                        WorkedExample = "3x - 5 = 16 → 3x = 21 → x = 7",
                        KeyPrinciple = "Two-step equations: Undo addition/subtraction first, then undo multiplication/division. Work backwards from the order of operations.",
                        CommonMistake = "Dividing first (trying to do 3x/3 while -5 is still there). Always handle addition/subtraction before multiplication/division!"
                    }
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
                    CorrectAnswers = new List<string> { "5", "x=5", "x = 5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Get all x terms on one side, all numbers on the other",
                        StepsDetailed = new List<string>
                        {
                            "Start: 5x + 3 = 2x + 18",
                            "Subtract 2x from both sides: 5x - 2x + 3 = 2x - 2x + 18",
                            "Simplify: 3x + 3 = 18",
                            "Subtract 3 from both sides: 3x = 15",
                            "Divide by 3: x = 5. Check: 5(5) + 3 = 28, 2(5) + 18 = 28 ✓"
                        },
                        WorkedExample = "5x + 3 = 2x + 18 → 3x + 3 = 18 → 3x = 15 → x = 5",
                        KeyPrinciple = "Variables on both sides: Move all variable terms to one side and constants to the other. Combine like terms, then solve as a two-step equation.",
                        CommonMistake = "Adding 2x instead of subtracting (getting 7x = 18). To move a term to the other side, use its opposite operation!"
                    }
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
                    CorrectAnswers = new List<string> { "5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use the Pythagorean theorem: distance = √(x² + y²)",
                        StepsDetailed = new List<string>
                        {
                            "Points: (0, 0) and (3, 4)",
                            "Horizontal distance: 3 - 0 = 3",
                            "Vertical distance: 4 - 0 = 4",
                            "Use Pythagorean theorem: d = √(3² + 4²)",
                            "Calculate: d = √(9 + 16) = √25 = 5"
                        },
                        WorkedExample = "d = √((3-0)² + (4-0)²) = √(9 + 16) = √25 = 5",
                        KeyPrinciple = "The distance formula comes from the Pythagorean theorem. The straight-line distance forms the hypotenuse of a right triangle.",
                        CommonMistake = "Just adding 3 + 4 = 7. That's the perimeter of the triangle, not the straight-line distance. You need to use √(x² + y²)!"
                    }
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
                    CorrectAnswers = new List<string> { "(x+2)(x+3)", "(x+3)(x+2)" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Find two numbers that multiply to 6 and add to 5",
                        StepsDetailed = new List<string>
                        {
                            "Need two numbers that multiply to 6 (constant term)",
                            "And add to 5 (coefficient of x)",
                            "Factors of 6: 1×6, 2×3",
                            "Check: 2 + 3 = 5 ✓",
                            "Answer: (x + 2)(x + 3)"
                        },
                        WorkedExample = "x² + 5x + 6 = (x + 2)(x + 3). Check: (x+2)(x+3) = x² + 3x + 2x + 6 = x² + 5x + 6 ✓",
                        KeyPrinciple = "To factor x² + bx + c, find two numbers that multiply to c and add to b. These become the constants in the binomial factors.",
                        CommonMistake = "Using numbers that multiply correctly but add incorrectly (like 1 and 6: 1×6=6 but 1+6=7, not 5). Both conditions must be met!"
                    }
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
                    CorrectAnswers = new List<string> { "5 and -1", "-1 and 5", "5, -1", "-1, 5", "x=5, x=-1", "x=-1, x=5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use x = (-b ± √(b² - 4ac)) / (2a) with a=1, b=-4, c=-5",
                        StepsDetailed = new List<string>
                        {
                            "Identify: a=1, b=-4, c=-5",
                            "Calculate discriminant: b² - 4ac = (-4)² - 4(1)(-5) = 16 + 20 = 36",
                            "Apply formula: x = (-(-4) ± √36) / (2×1) = (4 ± 6) / 2",
                            "First solution: x = (4 + 6) / 2 = 10 / 2 = 5",
                            "Second solution: x = (4 - 6) / 2 = -2 / 2 = -1"
                        },
                        WorkedExample = "x = (4 ± √36) / 2 = (4 ± 6) / 2 → x = 5 or x = -1",
                        KeyPrinciple = "The quadratic formula x = (-b ± √(b² - 4ac)) / (2a) solves any quadratic equation ax² + bx + c = 0. The ± gives two solutions.",
                        CommonMistake = "Sign errors with b: formula is -b, not b. With b=-4, you get -(-4)=+4, not -4. Also forgetting to divide both terms by 2a!"
                    }
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
                    CorrectAnswers = new List<string> { "10" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Replace every x with 3, then calculate",
                        StepsDetailed = new List<string>
                        {
                            "Start with f(x) = 2x² - 3x + 1",
                            "Replace x with 3: f(3) = 2(3)² - 3(3) + 1",
                            "Calculate exponent: 3² = 9",
                            "Multiply: 2(9) - 3(3) + 1 = 18 - 9 + 1",
                            "Add/subtract left to right: 18 - 9 + 1 = 10"
                        },
                        WorkedExample = "f(3) = 2(3)² - 3(3) + 1 = 2(9) - 9 + 1 = 18 - 9 + 1 = 10",
                        KeyPrinciple = "Function evaluation: substitute the given value for every instance of the variable, then simplify using order of operations (PEMDAS).",
                        CommonMistake = "Forgetting to square first before multiplying (calculating 2×3²=36 instead of 2×9=18). Always follow order of operations: exponents before multiplication!"
                    }
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
                    CorrectAnswers = new List<string> { "128", "2^7", "2⁷" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Same base? Add the exponents: 4 + 3",
                        StepsDetailed = new List<string>
                        {
                            "Identify: same base (2) with different exponents",
                            "Apply product rule: aⁿ × aᵐ = aⁿ⁺ᵐ",
                            "Add exponents: 2⁴ × 2³ = 2⁴⁺³ = 2⁷",
                            "Optional: Calculate value: 2⁷ = 128",
                            "Either answer (2⁷ or 128) is correct"
                        },
                        WorkedExample = "2⁴ × 2³ = 2⁴⁺³ = 2⁷ = 128",
                        KeyPrinciple = "Product of Powers Rule: When multiplying with the same base, keep the base and add the exponents. aⁿ × aᵐ = aⁿ⁺ᵐ",
                        CommonMistake = "Multiplying the exponents (2⁴×³ = 2¹²) or multiplying the bases (4² × 4³). Keep the base the same and ADD the exponents!"
                    }
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
                    CorrectAnswers = new List<string> { "115", "115°", "115 degrees" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Supplementary angles add up to 180°",
                        StepsDetailed = new List<string>
                        {
                            "Recall: supplementary angles sum to 180°",
                            "Set up equation: 65° + x = 180°",
                            "Subtract 65° from both sides: x = 180° - 65°",
                            "Calculate: x = 115°"
                        },
                        WorkedExample = "65° + x = 180° → x = 180° - 65° = 115°",
                        KeyPrinciple = "Supplementary angles are two angles that add up to 180°. To find the unknown angle, subtract the known angle from 180°.",
                        CommonMistake = "Confusing supplementary (180°) with complementary (90°). Complementary angles sum to 90°, supplementary angles sum to 180°!"
                    }
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
                    CorrectAnswers = new List<string> { "3/5", "0.6", ".6" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "SOH-CAH-TOA: sine is opposite over hypotenuse",
                        StepsDetailed = new List<string>
                        {
                            "Recall SOH-CAH-TOA: sin = Opposite/Hypotenuse",
                            "Identify given values: opposite = 3, hypotenuse = 5",
                            "Apply formula: sin(θ) = opposite/hypotenuse",
                            "Substitute: sin(θ) = 3/5",
                            "Optional: convert to decimal: 3 ÷ 5 = 0.6"
                        },
                        WorkedExample = "sin(θ) = opposite/hypotenuse = 3/5 = 0.6",
                        KeyPrinciple = "SOH-CAH-TOA: Sine equals Opposite over Hypotenuse. In any right triangle, sin(θ) = (side opposite to angle θ) / (hypotenuse).",
                        CommonMistake = "Confusing which ratio goes with which function. Sine uses opposite/hypotenuse, NOT adjacent/hypotenuse (that's cosine). Remember SOH for sine!"
                    }
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
                    CorrectAnswers = new List<string> { "50.24", "50.265", "16π", "16pi" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Area of circle = πr² where r is radius",
                        StepsDetailed = new List<string>
                        {
                            "Recall formula: Area = πr²",
                            "Identify radius: r = 4",
                            "Square the radius: r² = 4² = 16",
                            "Multiply by π: Area = π × 16 = 16π",
                            "Calculate numerical value: 16 × 3.14 = 50.24"
                        },
                        WorkedExample = "Area = πr² = π(4)² = π(16) = 16π ≈ 16 × 3.14 = 50.24",
                        KeyPrinciple = "The area of a circle is πr², where r is the radius. Always square the radius first, then multiply by π.",
                        CommonMistake = "Using diameter instead of radius, or forgetting to square (calculating π×4=12.56 instead of π×4²=50.24). The formula needs r², not just r!"
                    }
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
                    CorrectAnswers = new List<string> { "4" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Factor the numerator: x² - 4 = (x-2)(x+2)",
                        StepsDetailed = new List<string>
                        {
                            "Direct substitution gives 0/0 (indeterminate form)",
                            "Factor numerator: x² - 4 = (x - 2)(x + 2)",
                            "Rewrite: (x² - 4)/(x - 2) = (x - 2)(x + 2)/(x - 2)",
                            "Cancel (x - 2): expression simplifies to (x + 2)",
                            "Take limit: lim(x→2) (x + 2) = 2 + 2 = 4"
                        },
                        WorkedExample = "lim(x→2) (x² - 4)/(x - 2) = lim(x→2) (x - 2)(x + 2)/(x - 2) = lim(x→2) (x + 2) = 4",
                        KeyPrinciple = "When direct substitution yields 0/0, factor and simplify first. The (x - 2) terms cancel, revealing the limit. This indeterminate form requires algebraic manipulation before evaluation.",
                        CommonMistake = "Trying to substitute x=2 directly and concluding the limit doesn't exist because of 0/0. The 0/0 form means simplify first! Also, saying the answer is 0 or undefined."
                    }
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
                    CorrectAnswers = new List<string> { "6x+5", "6x + 5", "5+6x", "5 + 6x" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Power rule: derivative of xⁿ is n·xⁿ⁻¹",
                        StepsDetailed = new List<string>
                        {
                            "Apply power rule to each term separately",
                            "First term: d/dx(3x²) = 3·2·x²⁻¹ = 6x",
                            "Second term: d/dx(5x) = 5·1·x⁰ = 5",
                            "Third term: d/dx(-2) = 0 (derivative of constant is 0)",
                            "Combine: f'(x) = 6x + 5"
                        },
                        WorkedExample = "f'(x) = d/dx(3x²) + d/dx(5x) + d/dx(-2) = 6x + 5 + 0 = 6x + 5",
                        KeyPrinciple = "Power Rule: The derivative of axⁿ is a·n·xⁿ⁻¹. Multiply by the exponent and reduce the exponent by 1. Constants differentiate to 0.",
                        CommonMistake = "Forgetting to multiply by the coefficient (writing 2x instead of 6x) or forgetting the constant term becomes 0 (writing 6x + 5 - 2 instead of 6x + 5)."
                    }
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
                    CorrectAnswers = new List<string> { "x²+C", "x² + C", "x^2+C", "x^2 + C" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Power rule: ∫xⁿ dx = xⁿ⁺¹/(n+1) + C",
                        StepsDetailed = new List<string>
                        {
                            "Identify: integrating 2x = 2x¹",
                            "Apply power rule: ∫xⁿ dx = xⁿ⁺¹/(n+1) + C",
                            "Increase exponent: 1 + 1 = 2",
                            "Divide by new exponent: ∫2x dx = 2·(x²/2) + C",
                            "Simplify: 2·x²/2 = x² + C"
                        },
                        WorkedExample = "∫2x dx = 2∫x¹ dx = 2·(x²/2) + C = x² + C",
                        KeyPrinciple = "Power Rule for Integration: ∫xⁿ dx = xⁿ⁺¹/(n+1) + C. Increase the exponent by 1 and divide by the new exponent. Always add the constant of integration +C for indefinite integrals.",
                        CommonMistake = "Forgetting the +C constant of integration, or incorrectly applying the rule (getting 2x²/2 = x² but forgetting to check coefficient cancellation). Also confusing with derivative rules."
                    }
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
                    CorrectAnswers = new List<string> { "5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "For 2×2 matrix: det = ad - bc",
                        StepsDetailed = new List<string>
                        {
                            "Identify matrix elements: a=2, b=3, c=1, d=4",
                            "Apply 2×2 determinant formula: det = ad - bc",
                            "Calculate ad: 2 × 4 = 8",
                            "Calculate bc: 3 × 1 = 3",
                            "Subtract: det = 8 - 3 = 5"
                        },
                        WorkedExample = "det([[2,3],[1,4]]) = (2×4) - (3×1) = 8 - 3 = 5",
                        KeyPrinciple = "The determinant of a 2×2 matrix [[a,b],[c,d]] is calculated as ad - bc. This represents the signed area of the parallelogram formed by the column vectors.",
                        CommonMistake = "Using the wrong formula (adding instead of subtracting, or calculating ac - bd). Remember: main diagonal product MINUS off-diagonal product!"
                    }
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
                    CorrectAnswers = new List<string> { "Yes" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Apply the rule about ALL robots to this specific robot",
                        StepsDetailed = new List<string>
                        {
                            "Identify the general rule: All robots need power",
                            "Identify the specific case: R2 is a robot",
                            "Apply universal quantifier: If ALL members of a group have property X, and Y is in that group, then Y has property X",
                            "Conclusion: R2 needs power"
                        },
                        WorkedExample = "Premise 1: All robots → need power. Premise 2: R2 is a robot. By universal instantiation (modus ponens), R2 → needs power. Therefore: Yes.",
                        KeyPrinciple = "Universal Instantiation: When a rule applies to ALL members of a category, it applies to ANY specific member. This is the foundation of deductive reasoning (syllogism).",
                        CommonMistake = "Students sometimes overthink basic logic. The word 'all' creates a universal rule with no exceptions - if R2 is in the category, the rule applies."
                    }
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
                    CorrectAnswers = new List<string> { "Cannot determine from this information" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Wet ground has multiple causes - rain is only one",
                        StepsDetailed = new List<string>
                        {
                            "Given rule: If raining → ground is wet",
                            "Observation: Ground IS wet",
                            "Question: Does this prove it's raining?",
                            "Consider: Sprinklers, hoses, dew, or flooding could also wet the ground",
                            "Conclusion: We cannot determine if it's raining from this information alone"
                        },
                        WorkedExample = "If A→B is true, and B is observed, we CANNOT conclude A is true. This is the 'affirming the consequent' fallacy. Rain causes wet ground, but wet ground doesn't prove rain.",
                        KeyPrinciple = "Affirming the Consequent Fallacy: 'If A then B' does NOT mean 'if B then A'. The consequent (B) can be true for other reasons. Valid logic only flows forward, not backward.",
                        CommonMistake = "Students incorrectly reverse the implication, thinking 'if A→B' automatically means 'if B→A'. This is one of the most common logical errors. Multiple causes can lead to the same effect."
                    }
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
                    CorrectAnswers = new List<string> { "C must be true" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Follow the chain: A leads to B, B leads to C",
                        StepsDetailed = new List<string>
                        {
                            "Given: If A → B, and If B → C",
                            "Known fact: A is true",
                            "Apply first rule: Since A is true, B must be true (modus ponens)",
                            "Apply second rule: Since B is true, C must be true (modus ponens again)",
                            "Conclusion: C must be true"
                        },
                        WorkedExample = "Chain: A→B, B→C, A is true. Step 1: A→B + A = B (by modus ponens). Step 2: B→C + B = C (by modus ponens). Result: C is true. This is called hypothetical syllogism or transitive reasoning.",
                        KeyPrinciple = "Hypothetical Syllogism (Chain Reasoning): When you have connected conditionals (A→B and B→C), you can chain them together (A→C). If the first condition is satisfied, all consequences follow.",
                        CommonMistake = "Students sometimes lose track of the chain or think each step needs independent verification. Each 'if-then' is a domino - once A falls, it triggers B, which triggers C automatically."
                    }
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
                    CorrectAnswers = new List<string> { "The alarm did not sound" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Remember: 'if A then B' does NOT mean 'if B then A'",
                        StepsDetailed = new List<string>
                        {
                            "Write the rule: If alarm sounds → doors lock",
                            "Observe: Doors are NOT locked",
                            "Use contrapositive logic: If NOT locked → alarm NOT sounded",
                            "Conclusion: The alarm did not sound"
                        },
                        WorkedExample = "If A→B, and ¬B is true, then by modus tollens (contrapositive) ¬A must be true. Here: alarm→locked, ¬locked observed, therefore ¬alarm.",
                        KeyPrinciple = "Contrapositive logic (Modus Tollens): If 'A implies B' is true, then 'not-B implies not-A' is also true. When the consequence is false, the condition must be false.",
                        CommonMistake = "Students think 'if A then B' means the reverse is also true (affirming the consequent fallacy). Just because B is false doesn't tell us about A unless we use contrapositive logic."
                    }
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
                    CorrectAnswers = new List<string> { "Dan and Eve", "Eve and Dan", "Dan, Eve", "Eve, Dan" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Cross off each person who cannot be the thief",
                        StepsDetailed = new List<string>
                        {
                            "Start with all suspects: Alice, Bob, Carol, Dan, Eve",
                            "Eliminate Alice (stated NOT the thief)",
                            "Eliminate Bob (stated NOT the thief)",
                            "Eliminate Carol (alibi: was out of town)",
                            "Remaining suspects: Dan and Eve"
                        },
                        WorkedExample = "Total set: {Alice, Bob, Carol, Dan, Eve}. Constraint 1: ¬Alice ∧ ¬Bob. Constraint 2: ¬Carol. Remaining set: {Alice, Bob, Carol, Dan, Eve} - {Alice, Bob, Carol} = {Dan, Eve}.",
                        KeyPrinciple = "Process of Elimination: Start with all possibilities, then systematically remove options that violate constraints. What remains must contain the solution. This is also called disjunctive syllogism.",
                        CommonMistake = "Students sometimes miss applying all constraints or accidentally eliminate the same person twice. Always check that you've applied every piece of evidence and track which suspects remain after each elimination."
                    }
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
                    CorrectAnswers = new List<string> { "Key" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use what you know to eliminate impossible combinations",
                        StepsDetailed = new List<string>
                        {
                            "Create grid: Red/Blue/Green vs key/coin/gem",
                            "Constraint 1: Blue has coin → Mark Blue=coin, eliminate coin from Red and Green",
                            "Constraint 2: Red doesn't have key → Eliminate key from Red",
                            "Red's only option left: gem (since coin and key eliminated)",
                            "Green's only option left: key (since coin is in Blue, gem is in Red)"
                        },
                        WorkedExample = "Items: {key, coin, gem}. Blue=coin (given). Red≠key (given), Red≠coin (Blue has it), so Red=gem. Green≠coin (Blue has it), Green≠gem (Red has it), so Green=key.",
                        KeyPrinciple = "Constraint Satisfaction: Each entity must have exactly one property, and each property belongs to exactly one entity (one-to-one mapping). Use definite assignments to eliminate possibilities for other entities.",
                        CommonMistake = "Students forget that assigning an item to one box eliminates it from all other boxes. They also sometimes only use explicit constraints and miss the implicit deductions (if Red can't have key or coin, it MUST have gem)."
                    }
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
                    CorrectAnswers = new List<string> { "32" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Each number is double the previous number",
                        StepsDetailed = new List<string>
                        {
                            "Examine relationships: 4÷2=2, 8÷4=2, 16÷8=2",
                            "Pattern detected: Each term is 2× the previous term",
                            "Apply pattern: 16 × 2 = 32",
                            "Verify: The sequence is powers of 2 (2¹, 2², 2³, 2⁴, 2⁵)",
                            "Answer: 32"
                        },
                        WorkedExample = "Sequence: 2, 4, 8, 16, ?. Ratio test: 4/2=2, 8/4=2, 16/8=2. This is a geometric sequence with ratio r=2. Next term: 16×2=32. Alternative: 2¹=2, 2²=4, 2³=8, 2⁴=16, 2⁵=32.",
                        KeyPrinciple = "Geometric Sequences: When each term is a constant multiple of the previous term, it's a geometric sequence. Identify the pattern by checking ratios (division) or differences (subtraction) between consecutive terms.",
                        CommonMistake = "Students sometimes see 2→4 (+2) and guess it's addition, leading to wrong answer 18. Always check if the pattern holds across ALL terms. Here, 4→8 is +4, not +2, so it's not addition—it's multiplication by 2."
                    }
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
                    CorrectAnswers = new List<string> { "13" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Each number is the sum of the two before it",
                        StepsDetailed = new List<string>
                        {
                            "Check if each term relates to previous terms",
                            "Test: 1+1=2 ✓, 1+2=3 ✓, 2+3=5 ✓, 3+5=8 ✓",
                            "Pattern found: Each number = sum of previous two numbers",
                            "Apply pattern: 5 + 8 = 13",
                            "Answer: 13"
                        },
                        WorkedExample = "Fibonacci sequence: F(n) = F(n-1) + F(n-2). Terms: 1, 1, 2, 3, 5, 8, ?. Calculation: F(7) = F(6) + F(5) = 8 + 5 = 13. This recursive pattern appears in nature (spirals, branches, etc.).",
                        KeyPrinciple = "Recursive Patterns: Some sequences are defined by their previous terms, not by position alone. To find the pattern, look for relationships between consecutive terms (addition, multiplication, or combinations).",
                        CommonMistake = "Students look for simple addition/multiplication patterns and miss recursive relationships. They might see 1→2 (+1) and incorrectly guess the pattern is +1, +2, +3... The key is testing if the pattern applies to ALL transitions."
                    }
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
                    CorrectAnswers = new List<string> { "Remove first, add next in sequence at end" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Compare what stayed, what left, and what was added",
                        StepsDetailed = new List<string>
                        {
                            "Original: A1B2C3",
                            "Result: B2C3D4",
                            "What disappeared? A1 (the first pair)",
                            "What appeared? D4 (the next pair in sequence)",
                            "What stayed the same? B2C3 (middle portion shifted left)",
                            "Transformation: Remove first pair, add next sequential pair at end"
                        },
                        WorkedExample = "A1B2C3 → B2C3D4. Test 'shift forward': B→C? No, B stayed B. Test 'remove first + add next': A1B2C3 - A1 = B2C3, then + D4 = B2C3D4 ✓. This is a sliding window pattern.",
                        KeyPrinciple = "Transformation Analysis: Break complex patterns into parts (letters vs numbers, position vs value). Compare what's preserved, what's removed, and what's added. Look for sliding windows or queue operations (FIFO).",
                        CommonMistake = "Students see 'A→B→C→D' and think everything shifted forward by one letter. But B stayed B, and 2 stayed 2. The operation is structural (remove/add), not character-based (shift). Always verify your hypothesis against all elements."
                    }
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
                    CorrectAnswers = new List<string> { "2", "Take 2", "2 coins" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Work backward from the winning position (taking the last coin)",
                        StepsDetailed = new List<string>
                        {
                            "Winning position: Take the last coin (from 1, 2, or 3 coins left)",
                            "Force opponent into losing position: Leave them with 4 coins (no matter what they take, you can finish)",
                            "To leave 4 after opponent's turn: You need to leave 8 before they move (8→5/6/7→4)",
                            "Work backward: Win at 1-3, force opponent to 4, you need 8 before their move",
                            "From 10: Take 2 to leave 8. Then match opponent: they take X, you take (4-X)"
                        },
                        WorkedExample = "Losing positions: 4, 8 (multiples of 4). If you leave 8, opponent takes 1-3, leaving 7-5. You take enough to reach 4. Then they take 1-3, you finish. Strategy: 10→8 (take 2), maintain 4k pattern by complementary moves.",
                        KeyPrinciple = "Backward Induction in Game Theory: Work backward from winning states. Identify 'cold' positions (where the player whose turn it is will lose with perfect play) and force your opponent into them. Here, multiples of 4 are cold positions.",
                        CommonMistake = "Students guess randomly or try to take the maximum (3 coins). The key insight is the modulo-4 pattern: positions that are multiples of 4 are losing positions. Calculate 10 mod 4 = 2, so take 2 to reach a multiple of 4."
                    }
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
                    CorrectAnswers = new List<string> { "It creates a contradiction (paradox)" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "If the statement is true, what does it claim about itself?",
                        StepsDetailed = new List<string>
                        {
                            "Assume the statement 'This statement is false' is TRUE",
                            "If it's true, then what it says must be correct",
                            "What it says: 'This statement is false'",
                            "So if true, it's false - CONTRADICTION",
                            "Now assume it's FALSE: then it's NOT false, meaning it's true - CONTRADICTION again",
                            "Conclusion: This creates an infinite logical loop, a paradox"
                        },
                        WorkedExample = "Let S = 'This statement is false'. Case 1: If S is true → S says it's false → S is false (contradiction). Case 2: If S is false → S's claim is wrong → S is not false → S is true (contradiction). This is the Liar Paradox.",
                        KeyPrinciple = "Self-Reference Paradox: Statements that refer to their own truth value can create logical contradictions. This exposes limits of formal logic systems and was central to Gödel's Incompleteness Theorems. Not all statements can be consistently assigned true/false.",
                        CommonMistake = "Students sometimes think it's 'just false' or 'meaningless' and dismiss it. But the paradox is profound: it shows that self-referential statements can break classical logic's law of excluded middle (everything is either true or false, not both, not neither)."
                    }
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
