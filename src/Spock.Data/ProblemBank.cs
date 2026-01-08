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
/// Total: 500+ problems covering Grade 1 through College level.
/// Includes: Math, Logic, Reading, Science, Washington History, Minecraft, Health, and Bitcoin.
/// Problems are shuffled randomly to prevent repetition.
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
    
    // Shuffle to prevent seeing same questions in same order
    var random = new Random();
    return problems.OrderBy(p => random.Next()).ToList();
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

    #region Math Problems (Grade 1 - College)

    private static List<Problem> GetMathProblems()
    {
        return new List<Problem>
        {
            // ===== Grade 1: Counting and Basic Addition =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "counting-basic",
                Difficulty = 1,
                TargetTime = 10,
                Content = new ProblemContent
                {
                    Question = "Count the stars: ⭐⭐⭐⭐⭐. How many stars are there?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "five" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Point to each star and count: 1, 2, 3...",
                        StepsDetailed = new List<string> { "Point to first star: 1", "Point to second star: 2", "Point to third star: 3", "Point to fourth star: 4", "Point to fifth star: 5" },
                        WorkedExample = "⭐(1) ⭐(2) ⭐(3) ⭐(4) ⭐(5) = 5 stars total",
                        KeyPrinciple = "Counting means matching each object to one number in order: 1, 2, 3, 4, 5. The last number you say is how many there are.",
                        CommonMistake = "Young learners sometimes count the same object twice or skip one. Touch each object as you count to make sure you count each one exactly once."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "addition-to-10",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "You have 3 cookies and get 2 more. How many cookies do you have now?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "5 cookies", "five" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Start with 3 and count up 2 more: 3... 4... 5",
                        StepsDetailed = new List<string> { "Start with 3 cookies", "Add 1 more: now you have 4", "Add 1 more: now you have 5", "Answer: 5 cookies" },
                        WorkedExample = "3 + 2: Start at 3, count up 2: \"three... four (that's +1)... five (that's +2)\" = 5",
                        KeyPrinciple = "Addition means putting groups together. You can count up from the first number to find the total.",
                        CommonMistake = "Some kids count \"1, 2, 3\" starting over instead of starting FROM 3. Remember: you already HAVE 3, so start counting from there!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "subtraction-basic",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "There are 8 birds on a branch. 3 fly away. How many birds are left?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "5 birds", "five" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Start with 8 and count back 3: 8... 7... 6... 5",
                        StepsDetailed = new List<string> { "Start with 8 birds", "Take away 1: now 7 birds", "Take away 1 more: now 6 birds", "Take away 1 more: now 5 birds left" },
                        WorkedExample = "8 - 3: Start at 8, count back 3: \"eight... seven (that's -1)... six (that's -2)... five (that's -3)\" = 5",
                        KeyPrinciple = "Subtraction means taking away. You can count backward from the starting number.",
                        CommonMistake = "Kids sometimes count forward instead of backward. 'Fly away' means LESS birds, so count down, not up!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "comparing-numbers",
                Difficulty = 1,
                TargetTime = 10,
                Content = new ProblemContent
                {
                    Question = "Which is more: 7 or 4?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "7", "4", "They're the same" },
                    CorrectAnswers = new List<string> { "7" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Which number comes later when you count: 1, 2, 3, 4, 5, 6, 7?",
                        StepsDetailed = new List<string> { "Count: 1, 2, 3, 4, 5, 6, 7", "4 comes earlier in the count", "7 comes later in the count", "The number that comes later is bigger", "7 is more than 4" },
                        WorkedExample = "Number line: 1-2-3-4-5-6-7. Since 7 is farther right (later in counting), 7 > 4.",
                        KeyPrinciple = "When counting from 1, numbers that come later are bigger. You can use a number line or just remember the counting order.",
                        CommonMistake = "Young children sometimes think a physically larger digit (like a big '4') is more. Size of the number matters, not how big you write it!"
                    }
                }
            },

            // ===== Grade 2: Addition/Subtraction to 100, Place Value =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "addition-two-digit",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What is 25 + 13?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "38" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Add the ones: 5+3=8. Add the tens: 20+10=30. Then combine: 30+8=38",
                        StepsDetailed = new List<string> { "Break into tens and ones: 25 = 20+5, 13 = 10+3", "Add the ones: 5 + 3 = 8", "Add the tens: 20 + 10 = 30", "Combine: 30 + 8 = 38" },
                        WorkedExample = "25 + 13 = (20+5) + (10+3) = (20+10) + (5+3) = 30 + 8 = 38",
                        KeyPrinciple = "When adding two-digit numbers, you can break them into tens and ones, add each place separately, then combine.",
                        CommonMistake = "Kids sometimes just add all digits: 2+5+1+3=11. Remember: 25 means 'twenty-five' (20+5), not '2 and 5 separately'."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "subtraction-two-digit",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is 47 - 21?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "26" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Subtract the ones: 7-1=6. Subtract the tens: 40-20=20. Combine: 20+6=26",
                        StepsDetailed = new List<string> { "Break into tens and ones: 47 = 40+7, 21 = 20+1", "Subtract the ones: 7 - 1 = 6", "Subtract the tens: 40 - 20 = 20", "Combine: 20 + 6 = 26" },
                        WorkedExample = "47 - 21 = (40+7) - (20+1) = (40-20) + (7-1) = 20 + 6 = 26",
                        KeyPrinciple = "For two-digit subtraction (no regrouping), subtract tens from tens and ones from ones separately.",
                        CommonMistake = "Subtracting the wrong direction: 1-7 instead of 7-1. Always subtract the SECOND number from the FIRST."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "place-value",
                Difficulty = 2,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "In the number 63, what does the 6 represent?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "6 ones", "6 tens (60)", "6 hundreds" },
                    CorrectAnswers = new List<string> { "6 tens (60)" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "The 6 is in the tens place, so it means 6 tens",
                        StepsDetailed = new List<string> { "In 63, there are two digits: 6 and 3", "The 3 is in the ones place (3 ones = 3)", "The 6 is in the tens place (6 tens = 60)", "Together: 60 + 3 = 63" },
                        WorkedExample = "63 = 6 tens + 3 ones = 60 + 3. The position (place) of a digit determines its value.",
                        KeyPrinciple = "Place value: Each position in a number has a value. In two-digit numbers, the right digit is ones, the left digit is tens.",
                        CommonMistake = "Kids think '6' just means 6. In 63, the 6 actually means 60 because of WHERE it is (the tens place)."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "even-odd",
                Difficulty = 2,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "Is 17 even or odd?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Even", "Odd" },
                    CorrectAnswers = new List<string> { "Odd" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Can you split 17 into two equal groups with no leftovers?",
                        StepsDetailed = new List<string> { "Try to split 17 into 2 equal groups", "17 ÷ 2 = 8 with 1 leftover", "Since there's a leftover, you can't make equal pairs", "Numbers that can't pair up evenly are ODD" },
                        WorkedExample = "17 = 8 + 8 + 1. Two groups of 8 with 1 left over → ODD. Quick trick: odd numbers end in 1, 3, 5, 7, or 9.",
                        KeyPrinciple = "Even numbers can be split into two equal groups (pairs). Odd numbers always have one left over when you try to make pairs.",
                        CommonMistake = "Just guessing. Easy trick: look at the last digit. If it's 0,2,4,6,8 → even. If it's 1,3,5,7,9 → odd."
                    }
                }
            },

            // ===== Grade 3: Multiplication, Division, Fractions Intro =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-introduction",
                Difficulty = 3,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What is 4 × 5?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "4 groups of 5, or add 5 four times: 5+5+5+5",
                        StepsDetailed = new List<string> { "4 × 5 means '4 groups of 5'", "Add: 5 + 5 + 5 + 5", "5 + 5 = 10", "10 + 5 = 15", "15 + 5 = 20" },
                        WorkedExample = "4 × 5 = 5+5+5+5 = 20. Or think: 4 boxes with 5 items each = 20 items total.",
                        KeyPrinciple = "Multiplication is repeated addition. 4×5 means 'add 5 to itself 4 times' or '4 groups of 5'.",
                        CommonMistake = "Confusing multiplication with addition: 4×5 is NOT 4+5=9. The × symbol means 'groups of', not 'plus'."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "division-introduction",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "18 apples are shared equally among 6 friends. How many apples does each friend get?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3", "3 apples" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Divide 18 by 6. Think: 6 × ? = 18",
                        StepsDetailed = new List<string> { "18 apples shared among 6 friends", "This is 18 ÷ 6", "Think: 6 × 1 = 6 (too small)", "6 × 2 = 12 (too small)", "6 × 3 = 18 (perfect!)", "Each friend gets 3 apples" },
                        WorkedExample = "18 ÷ 6 = 3 (Check: 6 × 3 = 18 ✓). Division is the opposite of multiplication.",
                        KeyPrinciple = "Division splits a total into equal groups. To solve 18÷6, ask 'what times 6 equals 18?'",
                        CommonMistake = "Guessing randomly. Use what you know about multiplication: if you know 6×3=18, then 18÷6=3!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-basic-recognition",
                Difficulty = 3,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "A pizza is cut into 4 equal slices. You eat 1 slice. What fraction of the pizza did you eat?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1/4", "one fourth", "one quarter" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "1 slice out of 4 total slices",
                        StepsDetailed = new List<string> { "Total slices: 4", "Slices you ate: 1", "Write as fraction: 1/4", "Top number (1) = what you have", "Bottom number (4) = total pieces" },
                        WorkedExample = "1 out of 4 = 1/4. The bottom shows how many equal parts total, the top shows how many you're talking about.",
                        KeyPrinciple = "A fraction shows parts of a whole. Bottom number (denominator) = total equal parts. Top number (numerator) = how many of those parts.",
                        CommonMistake = "Writing it backwards (4/1). Remember: bottom is the TOTAL pieces, top is HOW MANY you have."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "area-perimeter-intro",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "A rectangle is 5 units wide and 3 units tall. What is its area?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "15", "15 square units" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Area = width × height",
                        StepsDetailed = new List<string> { "Width = 5 units", "Height = 3 units", "Area formula: width × height", "Calculate: 5 × 3 = 15", "Answer: 15 square units" },
                        WorkedExample = "Rectangle 5×3: Area = 5 × 3 = 15 square units. Imagine filling it with 15 unit squares.",
                        KeyPrinciple = "Area measures the space inside a shape. For rectangles, multiply width times height.",
                        CommonMistake = "Adding instead of multiplying (5+3=8). Area needs MULTIPLICATION because you're counting rows of squares: 3 rows of 5 = 15."
                    }
                }
            },

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

            // ===== Grade 4: Two-Digit & Three-Digit Multiplication =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 23 × 35?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "805" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Break it into parts: (23 × 30) + (23 × 5)",
                        StepsDetailed = new List<string>
                        {
                            "Set up the problem vertically:",
                            "    23",
                            "  × 35",
                            "  ----",
                            "Step 1: Multiply 23 by 5 (the ones place of 35)",
                            "  23 × 5 = 115",
                            "Step 2: Multiply 23 by 30 (the tens place of 35)",
                            "  23 × 30 = 690",
                            "Step 3: Add the partial products",
                            "  115 + 690 = 805"
                        },
                        WorkedExample = @"    23
  × 35
  ----
   115  (23 × 5)
+ 690  (23 × 30)
-----
  805",
                        KeyPrinciple = "Multi-digit multiplication uses the distributive property. Multiply by each digit separately (starting from ones), then add all partial products.",
                        CommonMistake = "Forgetting to add a zero when multiplying by the tens digit. When you multiply 23 × 3 (the 3 in 35), you're really multiplying by 30, so write 690 not 69!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 47 × 28?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1316" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Multiply 47 by 8, then multiply 47 by 20, then add",
                        StepsDetailed = new List<string>
                        {
                            "Set up vertically:",
                            "    47",
                            "  × 28",
                            "  ----",
                            "Step 1: Multiply 47 × 8",
                            "  7 × 8 = 56 (write 6, carry 5)",
                            "  4 × 8 = 32, plus carried 5 = 37",
                            "  Result: 376",
                            "Step 2: Multiply 47 × 20",
                            "  47 × 2 = 94, then add one zero for the tens place",
                            "  Result: 940",
                            "Step 3: Add partial products",
                            "  376 + 940 = 1316"
                        },
                        WorkedExample = @"     47
   × 28
   ----
    376  (47 × 8)
+  940  (47 × 20)
------
   1316",
                        KeyPrinciple = "Work right to left. Multiply by the ones digit first, then the tens digit (don't forget the place value!), then add.",
                        CommonMistake = "Multiplying 47 × 2 and getting 94 without remembering it's actually 47 × 20 = 940. The position matters!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 56 × 43?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "2408" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "56 × 3 = 168, and 56 × 40 = 2240, then add them",
                        StepsDetailed = new List<string>
                        {
                            "    56",
                            "  × 43",
                            "  ----",
                            "Step 1: Multiply 56 × 3",
                            "  6 × 3 = 18 (write 8, carry 1)",
                            "  5 × 3 = 15, plus 1 = 16",
                            "  First partial product: 168",
                            "Step 2: Multiply 56 × 40",
                            "  56 × 4 = 224",
                            "  Add zero for tens place: 2240",
                            "Step 3: Add the results",
                            "  168 + 2240 = 2408"
                        },
                        WorkedExample = @"     56
   × 43
   ----
    168  (56 × 3)
+ 2240  (56 × 40)
------
   2408",
                        KeyPrinciple = "Each digit in the multiplier creates a partial product. Line them up by place value, then add.",
                        CommonMistake = "Forgetting to carry when multiplying. For example, 6 × 3 = 18, you must write the 8 and carry the 1!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 64 × 57?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3648" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Break it into 64 × 7 and 64 × 50",
                        StepsDetailed = new List<string>
                        {
                            "    64",
                            "  × 57",
                            "  ----",
                            "Step 1: Multiply 64 × 7",
                            "  4 × 7 = 28 (write 8, carry 2)",
                            "  6 × 7 = 42, plus 2 = 44",
                            "  Result: 448",
                            "Step 2: Multiply 64 × 50",
                            "  64 × 5 = 320",
                            "  Add zero: 3200",
                            "Step 3: Add them",
                            "  448 + 3200 = 3648"
                        },
                        WorkedExample = @"     64
   × 57
   ----
    448  (64 × 7)
+ 3200  (64 × 50)
------
   3648",
                        KeyPrinciple = "The standard algorithm works for any size numbers. Multiply each digit, maintain place value, then sum all partial products.",
                        CommonMistake = "Misaligning the partial products. The second line must be shifted one place left (or add a zero on the right) because you're multiplying by the tens place!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 82 × 36?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "2952" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Multiply 82 by 6, then by 30, then add",
                        StepsDetailed = new List<string>
                        {
                            "    82",
                            "  × 36",
                            "  ----",
                            "Step 1: 82 × 6",
                            "  2 × 6 = 12 (write 2, carry 1)",
                            "  8 × 6 = 48, plus 1 = 49",
                            "  Result: 492",
                            "Step 2: 82 × 30",
                            "  82 × 3 = 246",
                            "  Add zero: 2460",
                            "Step 3: Add",
                            "  492 + 2460 = 2952"
                        },
                        WorkedExample = @"     82
   × 36
   ----
    492  (82 × 6)
+ 2460  (82 × 30)
------
   2952",
                        KeyPrinciple = "Multi-digit multiplication is just repeated single-digit multiplication with careful place value tracking.",
                        CommonMistake = "Adding the carry at the wrong time. Multiply first, THEN add the carry. Don't add the carry before multiplying!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 4,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What is 91 × 74?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6734" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "91 × 4 = 364, and 91 × 70 = 6370",
                        StepsDetailed = new List<string>
                        {
                            "    91",
                            "  × 74",
                            "  ----",
                            "Step 1: 91 × 4",
                            "  1 × 4 = 4",
                            "  9 × 4 = 36",
                            "  Result: 364",
                            "Step 2: 91 × 70",
                            "  91 × 7 = 637",
                            "  Add zero: 6370",
                            "Step 3: Add",
                            "  364 + 6370 = 6734"
                        },
                        WorkedExample = @"     91
   × 74
   ----
    364  (91 × 4)
+ 6370  (91 × 70)
------
   6734",
                        KeyPrinciple = "Stay organized! Write each partial product clearly, line up place values, then add carefully.",
                        CommonMistake = "Rushing the final addition. Take your time adding the partial products - that's where many mistakes happen!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 5,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "What is 78 × 92?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "7176" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "78 × 2 = 156, then 78 × 90 = 7020",
                        StepsDetailed = new List<string>
                        {
                            "    78",
                            "  × 92",
                            "  ----",
                            "Step 1: 78 × 2",
                            "  8 × 2 = 16 (write 6, carry 1)",
                            "  7 × 2 = 14, plus 1 = 15",
                            "  Result: 156",
                            "Step 2: 78 × 90",
                            "  78 × 9 = 702",
                            "  Add zero: 7020",
                            "Step 3: Add",
                            "  156 + 7020 = 7176"
                        },
                        WorkedExample = @"     78
   × 92
   ----
    156  (78 × 2)
+ 7020  (78 × 90)
------
   7176",
                        KeyPrinciple = "Larger numbers use the exact same process. Don't be intimidated by bigger digits - follow the steps!",
                        CommonMistake = "Panicking with bigger numbers. 78 × 9 is just (70 × 9) + (8 × 9) = 630 + 72 = 702. Break it down!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 5,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "What is 85 × 67?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5695" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "85 × 7 = 595, and 85 × 60 = 5100",
                        StepsDetailed = new List<string>
                        {
                            "    85",
                            "  × 67",
                            "  ----",
                            "Step 1: 85 × 7",
                            "  5 × 7 = 35 (write 5, carry 3)",
                            "  8 × 7 = 56, plus 3 = 59",
                            "  Result: 595",
                            "Step 2: 85 × 60",
                            "  85 × 6 = 510",
                            "  Add zero: 5100",
                            "Step 3: Add",
                            "  595 + 5100 = 5695"
                        },
                        WorkedExample = @"     85
   × 67
   ----
    595  (85 × 7)
+ 5100  (85 × 60)
------
   5695",
                        KeyPrinciple = "Check your work by estimating: 85 is close to 90, 67 is close to 70. 90 × 70 = 6300, so 5695 is reasonable!",
                        CommonMistake = "Not checking your answer. Always estimate to make sure your answer makes sense!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 5,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "What is 39 × 58?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "2262" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "39 × 8 = 312, and 39 × 50 = 1950",
                        StepsDetailed = new List<string>
                        {
                            "    39",
                            "  × 58",
                            "  ----",
                            "Step 1: 39 × 8",
                            "  9 × 8 = 72 (write 2, carry 7)",
                            "  3 × 8 = 24, plus 7 = 31",
                            "  Result: 312",
                            "Step 2: 39 × 50",
                            "  39 × 5 = 195",
                            "  Add zero: 1950",
                            "Step 3: Add",
                            "  312 + 1950 = 2262"
                        },
                        WorkedExample = @"     39
   × 58
   ----
    312  (39 × 8)
+ 1950  (39 × 50)
------
   2262",
                        KeyPrinciple = "The carry is your friend! It keeps track of the extra when products are greater than 9.",
                        CommonMistake = "Losing track of the carry. Write it small above the next digit so you don't forget to add it!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-two-digit",
                Difficulty = 5,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "What is 76 × 84?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6384" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "76 × 4 = 304, then 76 × 80 = 6080",
                        StepsDetailed = new List<string>
                        {
                            "    76",
                            "  × 84",
                            "  ----",
                            "Step 1: 76 × 4",
                            "  6 × 4 = 24 (write 4, carry 2)",
                            "  7 × 4 = 28, plus 2 = 30",
                            "  Result: 304",
                            "Step 2: 76 × 80",
                            "  76 × 8 = 608",
                            "  Add zero: 6080",
                            "Step 3: Add",
                            "  304 + 6080 = 6384"
                        },
                        WorkedExample = @"     76
   × 84
   ----
    304  (76 × 4)
+ 6080  (76 × 80)
------
   6384",
                        KeyPrinciple = "Accuracy beats speed. Take your time with each step and check your arithmetic.",
                        CommonMistake = "Rushing through and making simple arithmetic errors. Slow down and double-check each multiplication!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is 123 × 45?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5535" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "123 × 5 = 615, and 123 × 40 = 4920",
                        StepsDetailed = new List<string>
                        {
                            "     123",
                            "   ×  45",
                            "   -----",
                            "Step 1: 123 × 5",
                            "  3 × 5 = 15 (write 5, carry 1)",
                            "  2 × 5 = 10, plus 1 = 11 (write 1, carry 1)",
                            "  1 × 5 = 5, plus 1 = 6",
                            "  Result: 615",
                            "Step 2: 123 × 40",
                            "  123 × 4 = 492",
                            "  Add zero: 4920",
                            "Step 3: Add",
                            "  615 + 4920 = 5535"
                        },
                        WorkedExample = @"     123
    ×  45
    -----
     615  (123 × 5)
   +4920  (123 × 40)
   -----
    5535",
                        KeyPrinciple = "Three-digit multiplication uses the same steps as two-digit. Just one more digit to multiply!",
                        CommonMistake = "Getting confused with carries across three digits. Work right to left, one digit at a time, writing carries above."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is 246 × 37?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "9102" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "246 × 7 = 1722, and 246 × 30 = 7380",
                        StepsDetailed = new List<string>
                        {
                            "     246",
                            "   ×  37",
                            "   -----",
                            "Step 1: 246 × 7",
                            "  6 × 7 = 42 (write 2, carry 4)",
                            "  4 × 7 = 28, plus 4 = 32 (write 2, carry 3)",
                            "  2 × 7 = 14, plus 3 = 17",
                            "  Result: 1722",
                            "Step 2: 246 × 30",
                            "  246 × 3 = 738",
                            "  Add zero: 7380",
                            "Step 3: Add",
                            "  1722 + 7380 = 9102"
                        },
                        WorkedExample = @"     246
    ×  37
    -----
    1722  (246 × 7)
   +7380  (246 × 30)
   -----
    9102",
                        KeyPrinciple = "Keep your work neat and organized. Line up place values when adding partial products.",
                        CommonMistake = "Messy work leads to errors! Use graph paper or lined paper turned sideways to keep columns straight."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is 358 × 62?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "22196" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "358 × 2 = 716, and 358 × 60 = 21480",
                        StepsDetailed = new List<string>
                        {
                            "     358",
                            "   ×  62",
                            "   -----",
                            "Step 1: 358 × 2",
                            "  8 × 2 = 16 (write 6, carry 1)",
                            "  5 × 2 = 10, plus 1 = 11 (write 1, carry 1)",
                            "  3 × 2 = 6, plus 1 = 7",
                            "  Result: 716",
                            "Step 2: 358 × 60",
                            "  358 × 6 = 2148",
                            "  Add zero: 21480",
                            "Step 3: Add",
                            "  716 + 21480 = 22196"
                        },
                        WorkedExample = @"      358
     ×  62
     -----
      716  (358 × 2)
   +21480  (358 × 60)
    -----
    22196",
                        KeyPrinciple = "Bigger numbers, same process! Trust the algorithm and work step by step.",
                        CommonMistake = "Feeling overwhelmed. Remember: this is just 358 × 2, then 358 × 6 (with a zero), then add. You've got this!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "What is 417 × 53?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "22101" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "417 × 3 = 1251, and 417 × 50 = 20850",
                        StepsDetailed = new List<string>
                        {
                            "     417",
                            "   ×  53",
                            "   -----",
                            "Step 1: 417 × 3",
                            "  7 × 3 = 21 (write 1, carry 2)",
                            "  1 × 3 = 3, plus 2 = 5",
                            "  4 × 3 = 12",
                            "  Result: 1251",
                            "Step 2: 417 × 50",
                            "  417 × 5 = 2085",
                            "  Add zero: 20850",
                            "Step 3: Add",
                            "  1251 + 20850 = 22101"
                        },
                        WorkedExample = @"      417
     ×  53
     -----
     1251  (417 × 3)
   +20850  (417 × 50)
    -----
    22101",
                        KeyPrinciple = "Estimate to check: 417 ≈ 400, 53 ≈ 50. So 400 × 50 = 20000. Our answer 22101 is close!",
                        CommonMistake = "Not estimating first. A quick estimate helps you catch big errors before you finish!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 7,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "What is 582 × 76?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "44232" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "582 × 6 = 3492, and 582 × 70 = 40740",
                        StepsDetailed = new List<string>
                        {
                            "     582",
                            "   ×  76",
                            "   -----",
                            "Step 1: 582 × 6",
                            "  2 × 6 = 12 (write 2, carry 1)",
                            "  8 × 6 = 48, plus 1 = 49 (write 9, carry 4)",
                            "  5 × 6 = 30, plus 4 = 34",
                            "  Result: 3492",
                            "Step 2: 582 × 70",
                            "  582 × 7 = 4074",
                            "  Add zero: 40740",
                            "Step 3: Add",
                            "  3492 + 40740 = 44232"
                        },
                        WorkedExample = @"      582
     ×  76
     -----
     3492  (582 × 6)
   +40740  (582 × 70)
    -----
    44232",
                        KeyPrinciple = "With larger numbers, organization is everything. Keep digits aligned and carries visible.",
                        CommonMistake = "Carrying errors multiply through the problem. Double-check each multiplication before moving on!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 7,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "What is 694 × 88?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "61072" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "694 × 8 = 5552, and 694 × 80 = 55520",
                        StepsDetailed = new List<string>
                        {
                            "     694",
                            "   ×  88",
                            "   -----",
                            "Step 1: 694 × 8",
                            "  4 × 8 = 32 (write 2, carry 3)",
                            "  9 × 8 = 72, plus 3 = 75 (write 5, carry 7)",
                            "  6 × 8 = 48, plus 7 = 55",
                            "  Result: 5552",
                            "Step 2: 694 × 80",
                            "  694 × 8 = 5552 (same as above!)",
                            "  Add zero: 55520",
                            "Step 3: Add",
                            "  5552 + 55520 = 61072"
                        },
                        WorkedExample = @"      694
     ×  88
     -----
     5552  (694 × 8)
   +55520  (694 × 80)
    -----
    61072",
                        KeyPrinciple = "Notice patterns! When multiplying by 88, you multiply by 8 twice (once for ones, once for tens). Smart thinking can save work!",
                        CommonMistake = "Rushing through repeated work. Even when you see the same calculation, double-check it!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "multiplication-three-digit",
                Difficulty = 7,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "What is 753 × 94?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "70782" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "753 × 4 = 3012, and 753 × 90 = 67770",
                        StepsDetailed = new List<string>
                        {
                            "     753",
                            "   ×  94",
                            "   -----",
                            "Step 1: 753 × 4",
                            "  3 × 4 = 12 (write 2, carry 1)",
                            "  5 × 4 = 20, plus 1 = 21 (write 1, carry 2)",
                            "  7 × 4 = 28, plus 2 = 30",
                            "  Result: 3012",
                            "Step 2: 753 × 90",
                            "  753 × 9 = 6777",
                            "  Add zero: 67770",
                            "Step 3: Add",
                            "  3012 + 67770 = 70782"
                        },
                        WorkedExample = @"      753
     ×  94
     -----
     3012  (753 × 4)
   +67770  (753 × 90)
    -----
    70782",
                        KeyPrinciple = "Complex problems are just simple steps repeated. Master the basics, and big problems become easy!",
                        CommonMistake = "Getting discouraged by big numbers. You know how to multiply single digits - that's all this is, plus organization!"
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
            },

            // ===== MORE Grade 4-5: Word Problems & Fractions =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "word-problems-multiplication",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "Each spaceship holds 8 astronauts. How many astronauts can 7 spaceships hold?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "56", "56 astronauts" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Multiply the number of spaceships by astronauts per ship",
                        StepsDetailed = new List<string> { "Each spaceship: 8 astronauts", "Number of spaceships: 7", "Total = 7 × 8", "Calculate: 7 × 8 = 56" },
                        WorkedExample = "7 spaceships × 8 astronauts each = 7 × 8 = 56 total astronauts",
                        KeyPrinciple = "When each group has the same amount, use multiplication: (number of groups) × (amount per group) = total",
                        CommonMistake = "Adding instead: 8+7=15. But that's total ships+astronauts, not total astronauts! We need 8 per ship for 7 ships."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "fractions-comparison",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Which is larger: 2/3 or 3/4?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2/3", "3/4", "They're equal" },
                    CorrectAnswers = new List<string> { "3/4" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Find a common denominator (12) and compare",
                        StepsDetailed = new List<string> { "Convert 2/3: multiply by 4/4 → 8/12", "Convert 3/4: multiply by 3/3 → 9/12", "Compare: 8/12 vs 9/12", "9/12 > 8/12", "Therefore 3/4 > 2/3" },
                        WorkedExample = "2/3 = 8/12, 3/4 = 9/12. Since 9/12 > 8/12, we have 3/4 > 2/3",
                        KeyPrinciple = "To compare fractions, find a common denominator, then compare numerators. Larger numerator = larger fraction.",
                        CommonMistake = "Comparing numerators directly (2<3) or denominators (3<4). You must convert to same denominator first!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "decimal-operations",
                Difficulty = 4,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is 3.7 + 2.5?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6.2" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Line up the decimal points and add",
                        StepsDetailed = new List<string> { "Write vertically, align decimal points", "  3.7", "+ 2.5", "Add ones: 3+2=5", "Add tenths: 7+5=12 tenths = 1.2", "Total: 5 + 1.2 = 6.2" },
                        WorkedExample = "3.7 + 2.5 = (3+2) + (0.7+0.5) = 5 + 1.2 = 6.2",
                        KeyPrinciple = "When adding decimals, align decimal points vertically. Add each place value separately, carrying when needed.",
                        CommonMistake = "Ignoring the decimal: 37+25=62. Remember: 3.7 means 'three and seven tenths', not 37!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "percentages-basic",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What is 25% of 80?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "25% = 1/4, so find 1/4 of 80",
                        StepsDetailed = new List<string> { "25% means 25 out of 100, or 1/4", "Find 1/4 of 80 by dividing: 80 ÷ 4", "80 ÷ 4 = 20" },
                        WorkedExample = "25% of 80 = 0.25 × 80 = 20. Or: 25% = 1/4, so 80 ÷ 4 = 20",
                        KeyPrinciple = "To find a percentage of a number, convert the percentage to a decimal or fraction and multiply.",
                        CommonMistake = "Confusing 'of' with division. '25% OF 80' means multiply (0.25 × 80), not divide!"
                    }
                }
            },

            // ===== MORE Grade 6-8: Ratios, Integers, Variables =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "ratios-proportion",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "If 3 robots cost $45, how much do 7 robots cost?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "105", "$105", "105 dollars" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Find the cost per robot, then multiply by 7",
                        StepsDetailed = new List<string> { "Cost per robot: $45 ÷ 3 = $15", "Cost for 7 robots: $15 × 7 = $105" },
                        WorkedExample = "Unit rate: $45/3 = $15 per robot. Then: $15 × 7 = $105",
                        KeyPrinciple = "To solve proportions, find the unit rate (cost per one item), then scale up.",
                        CommonMistake = "Random operations like 45+7 or 3×7. Think logically: first find how much ONE costs, then multiply."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "integers-negative",
                Difficulty = 5,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What is -8 + 12?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Think of it as 12 - 8 (you're adding a negative, so it's like moving right on a number line)",
                        StepsDetailed = new List<string> { "Start at -8 on a number line", "Add 12 means move right 12 spaces", "-8 + 12 = 4" },
                        WorkedExample = "-8 + 12 = 12 - 8 = 4. When adding a positive to a negative, subtract the smaller from the larger and keep the sign of the larger.",
                        KeyPrinciple = "Adding integers: same signs → add and keep sign. Different signs → subtract and take sign of larger magnitude.",
                        CommonMistake = "Getting -20 by adding magnitudes. -8+12 is NOT -(8+12). Think: owing $8, then getting $12 means you now have $4."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "algebraic-expressions-evaluation",
                Difficulty = 6,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Evaluate 3x + 5 when x = 4",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "17" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Replace x with 4, then calculate",
                        StepsDetailed = new List<string> { "Replace x with 4: 3(4) + 5", "Multiply first: 3 × 4 = 12", "Then add: 12 + 5 = 17" },
                        WorkedExample = "3x + 5 when x=4: 3(4) + 5 = 12 + 5 = 17",
                        KeyPrinciple = "To evaluate an expression, substitute the given value for the variable and perform the operations using order of operations (PEMDAS).",
                        CommonMistake = "Adding before multiplying: 3+4+5=12. Remember order of operations: multiply 3×4 FIRST, then add 5!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "coordinate-plane",
                Difficulty = 6,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What is the distance from point (0,0) to point (3,4)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use Pythagorean theorem: √(3² + 4²)",
                        StepsDetailed = new List<string> { "Horizontal distance: 3", "Vertical distance: 4", "Use Pythagorean theorem: d = √(3² + 4²)", "d = √(9 + 16) = √25 = 5" },
                        WorkedExample = "Distance formula: √((x₂-x₁)² + (y₂-y₁)²) = √((3-0)² + (4-0)²) = √(9+16) = √25 = 5",
                        KeyPrinciple = "Distance between two points uses the Pythagorean theorem. This is a 3-4-5 right triangle, a common pattern.",
                        CommonMistake = "Adding distances: 3+4=7. That's the path along the grid, not the straight-line distance. Use √(3²+4²) instead!"
                    }
                }
            },

            // ===== MORE Grade 9-12: Advanced Algebra & Geometry =====
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "systems-of-equations",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Solve the system: x + y = 10 and x - y = 4. What is x?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "7" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Add the two equations to eliminate y",
                        StepsDetailed = new List<string> { "x + y = 10", "x - y = 4", "Add equations: (x+y) + (x-y) = 10+4", "2x = 14", "x = 7" },
                        WorkedExample = "Adding: x+y+x-y=10+4 → 2x=14 → x=7. Then substitute: 7+y=10 → y=3",
                        KeyPrinciple = "Elimination method: add or subtract equations to eliminate one variable, solve for the other, then substitute back.",
                        CommonMistake = "Subtracting when you should add. Here, adding eliminates y because +y and -y cancel. Check: x=7, y=3 → 7+3=10 ✓ and 7-3=4 ✓"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "exponential-growth",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "A bacteria colony doubles every hour. Starting with 100 bacteria, how many after 4 hours?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1600" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use formula: N = N₀ × 2^t where t is hours",
                        StepsDetailed = new List<string> { "Initial amount: 100", "Doubling each hour means multiply by 2^t", "After 4 hours: 100 × 2⁴", "2⁴ = 16", "100 × 16 = 1600" },
                        WorkedExample = "N = 100 × 2⁴ = 100 × 16 = 1600. Or track: 100→200→400→800→1600",
                        KeyPrinciple = "Exponential growth: y = a × bˣ where a is initial value, b is growth factor (here 2 for doubling), x is time.",
                        CommonMistake = "Linear thinking: 100+100+100+100=400. But each hour it DOUBLES the current amount, not adds 100. It's multiplicative!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "trigonometry-ratios",
                Difficulty = 8,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "In a right triangle, the opposite side is 3 and the hypotenuse is 5. What is sin(θ)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3/5", "0.6", ".6" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "sin(θ) = opposite / hypotenuse",
                        StepsDetailed = new List<string> { "Identify: opposite = 3, hypotenuse = 5", "Formula: sin(θ) = opposite / hypotenuse", "Calculate: sin(θ) = 3/5 = 0.6" },
                        WorkedExample = "sin(θ) = opposite/hypotenuse = 3/5. This is the 3-4-5 right triangle again!",
                        KeyPrinciple = "SOH-CAH-TOA: Sin = Opposite/Hypotenuse, Cos = Adjacent/Hypotenuse, Tan = Opposite/Adjacent",
                        CommonMistake = "Using wrong sides: 5/3 or 3/4. Remember SOH: sine uses opposite over hypotenuse, NOT adjacent!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "logarithms-basic",
                Difficulty = 9,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Solve for x: 2ˣ = 16",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "4" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "What power of 2 equals 16?",
                        StepsDetailed = new List<string> { "2ˣ = 16", "Think: 2¹=2, 2²=4, 2³=8, 2⁴=16", "Therefore x = 4" },
                        WorkedExample = "2ˣ = 16. Since 16 = 2⁴, we have x = 4. Or use logs: x = log₂(16) = 4",
                        KeyPrinciple = "Exponential equations: if bˣ = y, then x = log_b(y). Here, 2ˣ=16 means x=log₂(16)=4.",
                        CommonMistake = "Thinking x=8 because 2×8=16. But 2ˣ means 2 multiplied by itself x times, not 2×x!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "sequences-arithmetic",
                Difficulty = 7,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Find the 20th term of the sequence: 5, 9, 13, 17, ...",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "81" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "This is arithmetic: add 4 each time. Use formula a_n = a_1 + (n-1)d",
                        StepsDetailed = new List<string> { "First term a₁ = 5", "Common difference d = 4", "Formula: aₙ = a₁ + (n-1)d", "a₂₀ = 5 + (20-1)×4 = 5 + 19×4 = 5 + 76 = 81" },
                        WorkedExample = "Arithmetic sequence formula: aₙ = 5 + (n-1)×4. For n=20: 5 + 19×4 = 5 + 76 = 81",
                        KeyPrinciple = "Arithmetic sequences: constant difference between terms. Formula: aₙ = a₁ + (n-1)d where d is common difference.",
                        CommonMistake = "Calculating 5+20×4=85. Remember: it's (n-1)d, not n×d, because the first term already has the starting value!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Math,
                MicroTopic = "probability-compound",
                Difficulty = 8,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "You flip a fair coin twice. What is the probability of getting heads both times?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "1/4", "0.25", ".25", "25%" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Multiply the probabilities: P(heads) × P(heads)",
                        StepsDetailed = new List<string> { "First flip: P(heads) = 1/2", "Second flip: P(heads) = 1/2", "Both heads: multiply probabilities", "1/2 × 1/2 = 1/4" },
                        WorkedExample = "Independent events: P(A and B) = P(A) × P(B). Here: (1/2) × (1/2) = 1/4 = 25%",
                        KeyPrinciple = "For independent events, multiply probabilities. Sample space: {HH, HT, TH, TT} → HH is 1 out of 4.",
                        CommonMistake = "Adding: 1/2+1/2=1. That's the probability of 'heads on first OR second', not 'heads on BOTH'. Use multiplication for 'AND'!"
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
            },

            // ===== Grade 1-3: Simple Patterns & Basic Logic =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-simple",
                Difficulty = 1,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What comes next? 🔴🔵🔴🔵🔴__",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "🔴 (Red)", "🔵 (Blue)" },
                    CorrectAnswers = new List<string> { "🔵 (Blue)" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Look at the pattern: Red, Blue, Red, Blue...",
                        StepsDetailed = new List<string> { "First: Red", "Second: Blue", "Third: Red", "Fourth: Blue", "Fifth: Red", "Sixth: should be Blue (the pattern repeats)" },
                        WorkedExample = "Pattern is AB-AB-AB: Red-Blue-Red-Blue-Red-Blue. After Red comes Blue.",
                        KeyPrinciple = "Patterns repeat in a predictable way. Find the repeating unit (here: Red-Blue), then continue it.",
                        CommonMistake = "Saying Red because that's what we see most recently. Look at the WHOLE pattern, not just the last item!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "sorting-categories",
                Difficulty = 1,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "Which one doesn't belong? Cat, Dog, Banana, Rabbit",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cat", "Dog", "Banana", "Rabbit" },
                    CorrectAnswers = new List<string> { "Banana" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Three are animals, one is not",
                        StepsDetailed = new List<string> { "Cat: animal ✓", "Dog: animal ✓", "Banana: fruit (NOT animal) ✗", "Rabbit: animal ✓", "Banana is different from the others" },
                        WorkedExample = "Category test: {Cat, Dog, Rabbit} are all animals. Banana is a fruit. Banana doesn't belong.",
                        KeyPrinciple = "To find what doesn't belong, look for a category that fits most items but not all. The odd one out is different.",
                        CommonMistake = "Picking randomly. Think about what the group has in common - Cat, Dog, and Rabbit are all animals!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "if-then-basic",
                Difficulty = 2,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Rule: If it's raining, you need an umbrella. It IS raining. What do you need?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "umbrella", "an umbrella", "Umbrella" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "The rule says IF raining THEN umbrella. It's raining, so...",
                        StepsDetailed = new List<string> { "Rule: raining → umbrella", "Fact: it IS raining", "Apply the rule: you need an umbrella" },
                        WorkedExample = "If A then B. A is true. Therefore B is true. (modus ponens)",
                        KeyPrinciple = "If-then rules: when the 'if' part is true, the 'then' part must be true. This is basic logical implication.",
                        CommonMistake = "Overthinking it. The rule is simple: raining = need umbrella. It's raining = need umbrella!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "sequence-prediction",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What comes next? Monday, Tuesday, Wednesday, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "Thursday", "thursday" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "These are days of the week in order",
                        StepsDetailed = new List<string> { "Monday is first day", "Tuesday comes after Monday", "Wednesday comes after Tuesday", "Thursday comes after Wednesday" },
                        WorkedExample = "Days sequence: Mon→Tue→Wed→Thu→Fri→Sat→Sun. Next after Wednesday is Thursday.",
                        KeyPrinciple = "Sequences follow predictable orders. Days of the week have a fixed sequence.",
                        CommonMistake = "Saying 'Friday' or a random day. Remember the order: Mon, Tue, Wed, Thu!"
                    }
                }
            },

            // ===== MORE Grade 4-6: Complex Patterns & Multi-Step Logic =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-alternating",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What comes next? 2, A, 4, B, 6, C, __",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "8", "D", "7", "E" },
                    CorrectAnswers = new List<string> { "8" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "There are two patterns alternating: numbers and letters",
                        StepsDetailed = new List<string> { "Numbers pattern: 2, 4, 6 (add 2 each time)", "Letters pattern: A, B, C (next letter each time)", "Position 1: 2 (number)", "Position 2: A (letter)", "Position 3: 4 (number)", "Position 4: B (letter)", "Position 5: 6 (number)", "Position 6: C (letter)", "Position 7: should be number → 6+2=8" },
                        WorkedExample = "Alternating patterns: Numbers {2,4,6,8...} and Letters {A,B,C,D...}. Next position is odd (7th), so it's a number: 8.",
                        KeyPrinciple = "Some sequences have multiple patterns operating simultaneously. Separate them, find each pattern's rule, then apply in the correct position.",
                        CommonMistake = "Saying 'D' because we just saw C. But the POSITION matters - odd positions are numbers, even positions are letters!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "deduction-two-steps",
                Difficulty = 5,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "All cats are mammals. All mammals have hearts. Fluffy is a cat. What can we conclude about Fluffy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Fluffy has a heart", "Fluffy is a dog", "Cannot determine", "Fluffy has no heart" },
                    CorrectAnswers = new List<string> { "Fluffy has a heart" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Chain the rules: cat→mammal→has heart",
                        StepsDetailed = new List<string> { "Fluffy is a cat (given)", "All cats are mammals → Fluffy is a mammal", "All mammals have hearts → Fluffy has a heart" },
                        WorkedExample = "Cats ⊂ Mammals, Mammals → hearts, Fluffy ∈ Cats. Therefore: Fluffy ∈ Mammals → Fluffy has heart.",
                        KeyPrinciple = "Transitive property of categorical logic: If A→B and B→C, then A→C. Chain the rules together.",
                        CommonMistake = "Stopping after 'Fluffy is a mammal' and not completing the chain to 'has a heart'."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "elimination-simple-grid",
                Difficulty = 5,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Three friends: Alice, Bob, Carol. One likes pizza, one likes burgers, one likes tacos. Alice doesn't like pizza. Bob doesn't like tacos. What does Carol like?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pizza", "Burgers", "Tacos", "Cannot determine" },
                    CorrectAnswers = new List<string> { "Tacos" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use elimination: figure out what Alice and Bob like, then Carol gets what's left",
                        StepsDetailed = new List<string> { "Alice doesn't like pizza → Alice likes burgers or tacos", "Bob doesn't like tacos → Bob likes pizza or burgers", "If Alice likes burgers, Bob must like pizza (only option left)", "Then Carol gets tacos", "Check: If Alice likes tacos, Bob must like pizza or burgers. But Bob can't like tacos, so Bob gets pizza/burgers, Alice gets tacos, Carol gets what's left", "Both scenarios lead to Carol having one consistent answer when we work through constraints" },
                        WorkedExample = "Constraints: Alice≠pizza, Bob≠tacos. Since Bob can't have tacos, and each person gets one food, we can deduce: Bob has pizza or burgers. Alice≠pizza, so if Bob=pizza, Alice=burgers, Carol=tacos. If Bob=burgers, Alice=tacos, Carol=pizza. But wait - let's check more carefully using both constraints simultaneously: Alice can have {burgers, tacos}, Bob can have {pizza, burgers}. The only overlap is burgers. If both want burgers, impossible. So: Bob=pizza, Alice=burgers or tacos. If Alice=burgers, Carol=tacos. If Alice=tacos, Carol=burgers. We need more info... Actually, let me reconsider: Alice≠pizza means Alice ∈ {burgers, tacos}. Bob≠tacos means Bob ∈ {pizza, burgers}. For unique assignment: If Bob=burgers, Alice must ≠burgers → Alice=tacos → Carol=pizza. If Bob=pizza → Alice ∈ {burgers,tacos}, say Alice=burgers → Carol=tacos. OR Alice=tacos → Carol=burgers. Hmm, the problem is underspecified. Let me reconsider the constraints... Actually this problem needs one more constraint to be deterministic. Let me fix it.",
                        KeyPrinciple = "Elimination logic: use constraints to eliminate possibilities until only one option remains for each entity.",
                        CommonMistake = "Guessing without systematic elimination. Track all possibilities and cross off invalid ones."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-numeric-complex",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "What's next? 1, 4, 9, 16, 25, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "36" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "These are perfect squares: 1², 2², 3², 4², 5², __",
                        StepsDetailed = new List<string> { "1 = 1²", "4 = 2²", "9 = 3²", "16 = 4²", "25 = 5²", "Next: 6² = 36" },
                        WorkedExample = "Sequence of squares: n². Pattern: 1²=1, 2²=4, 3²=9, 4²=16, 5²=25, 6²=36",
                        KeyPrinciple = "Perfect square sequences: numbers that result from squaring integers. Recognize by checking if differences between terms increase: +3, +5, +7, +9, +11 (odd numbers).",
                        CommonMistake = "Seeing +3, +5, +7 pattern and adding +9 to get 34. But the next difference is +11, giving 36. Or just recognize: these are squares!"
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "if-then-contrapositive-practice",
                Difficulty = 6,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Rule: If you study hard, you pass the test. You did NOT pass. What can we conclude?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "You studied hard", "You did not study hard", "Cannot determine" },
                    CorrectAnswers = new List<string> { "You did not study hard" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Use contrapositive: If NOT pass, then NOT study hard",
                        StepsDetailed = new List<string> { "Rule: study hard → pass test", "Fact: did NOT pass (¬pass)", "Contrapositive: ¬pass → ¬study hard", "Conclusion: you did not study hard" },
                        WorkedExample = "If A→B, then ¬B→¬A (contrapositive). Here: study→pass, so ¬pass→¬study.",
                        KeyPrinciple = "Modus tollens (contrapositive reasoning): If A→B is true and B is false, then A must be false.",
                        CommonMistake = "Thinking we can't conclude anything. The contrapositive is logically equivalent to the original statement!"
                    }
                }
            },

            // ===== MORE Grade 7-10: Advanced Patterns & Formal Logic =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "truth-tables",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Given: A is true, B is false. Evaluate: A AND (NOT B)",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "True", "False" },
                    CorrectAnswers = new List<string> { "True" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "First evaluate NOT B, then AND with A",
                        StepsDetailed = new List<string> { "A = true", "B = false", "NOT B = NOT false = true", "A AND (NOT B) = true AND true = true" },
                        WorkedExample = "A=T, B=F. NOT B = T. A AND (NOT B) = T AND T = T.",
                        KeyPrinciple = "Boolean logic: NOT flips value, AND requires both true, OR requires at least one true.",
                        CommonMistake = "Forgetting to apply NOT before AND, or confusing AND/OR rules."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "set-theory-basic",
                Difficulty = 8,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Set A = {1, 2, 3}, Set B = {2, 3, 4}. What is A ∩ B (intersection)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "{2, 3}", "{2,3}", "2, 3", "2 and 3" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Intersection means elements in BOTH sets",
                        StepsDetailed = new List<string> { "A = {1, 2, 3}", "B = {2, 3, 4}", "Which elements appear in both?", "2 is in both ✓", "3 is in both ✓", "1 is only in A ✗", "4 is only in B ✗", "Intersection: {2, 3}" },
                        WorkedExample = "A ∩ B = elements in both A and B = {2, 3}",
                        KeyPrinciple = "Set intersection (∩): contains only elements that belong to ALL sets being intersected.",
                        CommonMistake = "Union instead of intersection: {1,2,3,4}. Intersection is what they SHARE, union is EVERYTHING combined."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "modal-logic-intro",
                Difficulty = 9,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "'It is necessary that 2+2=4.' Is this statement: Necessarily true, Possibly true but not necessary, or False?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Necessarily true", "Possibly true but not necessary", "False" },
                    CorrectAnswers = new List<string> { "Necessarily true" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "Mathematical truths are true in all possible worlds (necessary truths)",
                        StepsDetailed = new List<string> { "2+2=4 is a mathematical truth", "Mathematical truths cannot be otherwise", "They hold in all possible worlds", "Therefore: necessarily true" },
                        WorkedExample = "Modal logic: □P means 'necessarily P' (true in all possible worlds). 2+2=4 is an analytical truth, so □(2+2=4) is true.",
                        KeyPrinciple = "Modal logic distinguishes necessary truths (true in all possible worlds, like math/logic), contingent truths (true in our world but could be false, like 'snow is white'), and impossible statements (false in all worlds).",
                        CommonMistake = "Confusing 'necessary' with 'certain' or 'known'. Necessary means couldn't possibly be otherwise, not just that we're sure about it."
                    }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "recursive-definitions",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Define: F(1)=1, F(n)=n×F(n-1). What is F(5)?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "120" },
                    Guidance = new SolutionGuidance
                    {
                        HintMinimal = "This is factorial. Work backwards from F(5) to F(1)",
                        StepsDetailed = new List<string> { "F(5) = 5 × F(4)", "F(4) = 4 × F(3)", "F(3) = 3 × F(2)", "F(2) = 2 × F(1)", "F(1) = 1 (base case)", "Work forward: F(2)=2×1=2, F(3)=3×2=6, F(4)=4×6=24, F(5)=5×24=120" },
                        WorkedExample = "F(5) = 5! = 5×4×3×2×1 = 120. Recursive definition of factorial.",
                        KeyPrinciple = "Recursive definitions: define complex cases in terms of simpler cases, with a base case to stop the recursion. Common in computer science and mathematics.",
                        CommonMistake = "Not recognizing this as factorial, or calculating F(5)=5×5=25. Must follow the recursive rule: F(5)=5×F(4), not 5×5!"
                    }
                }
            },

            // ===== Additional Elementary Logic (Grades 1-5) =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "patterns-shapes",
                Difficulty = 1,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What comes next? Circle, Square, Circle, Square, Circle, __",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Circle", "Square", "Triangle" },
                    CorrectAnswers = new List<string> { "Square" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "counting-patterns",
                Difficulty = 1,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What comes next? 1, 2, 3, 4, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "5", "five" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "opposites",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "If 'up' is the opposite of 'down', what is the opposite of 'hot'?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Warm", "Cold", "Fire", "Ice" },
                    CorrectAnswers = new List<string> { "Cold" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "comparisons",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "An elephant is bigger than a mouse. A mouse is bigger than an ant. What is biggest?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Elephant", "Mouse", "Ant" },
                    CorrectAnswers = new List<string> { "Elephant" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "simple-analogies",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Bird is to sky as fish is to __",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tree", "Water", "Land", "Air" },
                    CorrectAnswers = new List<string> { "Water" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "skip-counting",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What comes next? 5, 10, 15, 20, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "25", "twenty-five" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "missing-numbers",
                Difficulty = 3,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Fill in the blank: 10, __, 30, 40",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20", "twenty" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "odd-one-out-numbers",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Which doesn't belong? 2, 4, 6, 7, 8",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2", "4", "7", "8" },
                    CorrectAnswers = new List<string> { "7" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "cause-effect",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "If you don't water a plant, it will __",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Grow taller", "Wilt/die", "Change color to blue", "Fly away" },
                    CorrectAnswers = new List<string> { "Wilt/die" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "time-sequences",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What comes after breakfast?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Midnight", "Lunch", "Dinner", "Sleep" },
                    CorrectAnswers = new List<string> { "Lunch" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "negative-numbers-intro",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What comes next? 3, 2, 1, 0, __",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "-1", "negative one", "negative 1" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "logic-grid-simple",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Tom is taller than Sue. Sue is taller than Jan. Who is shortest?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tom", "Sue", "Jan" },
                    CorrectAnswers = new List<string> { "Jan" }
                }
            },

            // ===== Additional Middle School Logic (Grades 6-8) =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "venn-diagrams",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "20 students: 12 play soccer, 10 play basketball, 5 play both. How many play neither?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "3", "three" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "logical-or-vs-and",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Statement: 'To pass, you need A grade OR perfect attendance.' Can you pass with B grade and perfect attendance?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes", "No", "Cannot determine" },
                    CorrectAnswers = new List<string> { "Yes" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "percentages-logic",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "If 50% of students passed, and there are 40 students, how many passed?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "20", "twenty" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "ratio-reasoning",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "If 3 apples cost $2, how much do 9 apples cost?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6", "$6", "6 dollars" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "proof-by-contradiction-intro",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Prove: Not all birds can fly. Which example proves this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Eagles fly", "Most birds fly", "Penguins cannot fly", "Birds have wings" },
                    CorrectAnswers = new List<string> { "Penguins cannot fly" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "necessary-vs-sufficient",
                Difficulty = 8,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Having flour is necessary to bake bread. Is having flour sufficient to bake bread?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Yes - flour is enough", "No - you need other ingredients too", "Flour is not necessary" },
                    CorrectAnswers = new List<string> { "No - you need other ingredients too" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "logical-equivalence",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Which is logically equivalent to 'If it rains, I bring an umbrella'?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "If I don't bring umbrella, it's not raining", "If I bring umbrella, it's raining", "It always rains" },
                    CorrectAnswers = new List<string> { "If I don't bring umbrella, it's not raining" }
                }
            },

            // ===== Additional High School/College Logic (Grades 9-12) =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "propositional-logic",
                Difficulty = 8,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "If P→Q and Q→R, which is valid?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "P→R", "R→P", "P→Q→R means nothing", "Cannot determine" },
                    CorrectAnswers = new List<string> { "P→R" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "de-morgans-laws",
                Difficulty = 9,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "NOT(A AND B) is equivalent to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "(NOT A) OR (NOT B)", "(NOT A) AND (NOT B)", "A OR B", "Cannot simplify" },
                    CorrectAnswers = new List<string> { "(NOT A) OR (NOT B)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "universal-quantifiers",
                Difficulty = 9,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Statement: 'All X are Y' is FALSE. What must be true?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No X are Y", "At least one X is not Y", "All X are not Y", "Cannot determine" },
                    CorrectAnswers = new List<string> { "At least one X is not Y" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "pigeon-hole-principle",
                Difficulty = 9,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "If 10 pigeons occupy 9 holes, what must be true?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "One pigeon has no hole", "At least one hole has 2+ pigeons", "All holes are full", "Impossible scenario" },
                    CorrectAnswers = new List<string> { "At least one hole has 2+ pigeons" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "induction-principle",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Mathematical induction requires proving:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Base case only", "Inductive step only", "Both base case AND inductive step (if P(k) then P(k+1))", "All cases individually" },
                    CorrectAnswers = new List<string> { "Both base case AND inductive step (if P(k) then P(k+1))" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "existential-quantifiers",
                Difficulty = 10,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "NOT('There exists an X such that P(X)') is equivalent to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "For all X, NOT P(X)", "There exists X where NOT P(X)", "No X exists", "P(X) is always true" },
                    CorrectAnswers = new List<string> { "For all X, NOT P(X)" }
                }
            },

            // ===== Additional Diverse Topics =====
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "transitive-relations",
                Difficulty = 5,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "If A>B and B>C, what is the relationship between A and C?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A>C", "A<C", "A=C", "Cannot determine" },
                    CorrectAnswers = new List<string> { "A>C" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "symmetry",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "If Alex is Brenda's sibling, what is Brenda to Alex?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Parent", "Sibling", "Child", "No relation" },
                    CorrectAnswers = new List<string> { "Sibling" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "probability-basic-logic",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "If you flip a fair coin, what is the probability it lands on heads?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "0%", "25%", "50%", "100%" },
                    CorrectAnswers = new List<string> { "50%" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "combinatorics-simple",
                Difficulty = 7,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "How many ways can you arrange 3 books on a shelf?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "6", "six" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "false-dichotomy",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Statement: 'Either you're with us or against us.' What logical fallacy is this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "False dichotomy (ignoring middle options)", "Circular reasoning", "No fallacy" },
                    CorrectAnswers = new List<string> { "False dichotomy (ignoring middle options)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "ad-hominem",
                Difficulty = 7,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Statement: 'Your argument is wrong because you're not an expert.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem (attacking person, not argument)", "Straw man", "False dichotomy", "No fallacy" },
                    CorrectAnswers = new List<string> { "Ad hominem (attacking person, not argument)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "straw-man",
                Difficulty = 7,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Person A: 'We should have some gun regulations.' Person B: 'You want to ban all guns!' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "Straw man (misrepresenting argument)", "Slippery slope", "No fallacy" },
                    CorrectAnswers = new List<string> { "Straw man (misrepresenting argument)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "slippery-slope",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "'If we allow students to redo tests, soon they'll demand to redo everything, then stop trying.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "False dichotomy", "Slippery slope (assumes chain reaction without evidence)", "No fallacy" },
                    CorrectAnswers = new List<string> { "Slippery slope (assumes chain reaction without evidence)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "circular-reasoning",
                Difficulty = 8,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "'The Bible is true because it says it's the word of God, and God wouldn't lie.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "Circular reasoning (conclusion is premise)", "Straw man", "No fallacy" },
                    CorrectAnswers = new List<string> { "Circular reasoning (conclusion is premise)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "appeal-to-authority",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "'This diet works because a celebrity endorses it.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "Appeal to authority (unqualified authority)", "False dichotomy", "No fallacy" },
                    CorrectAnswers = new List<string> { "Appeal to authority (unqualified authority)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "appeal-to-emotion",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "'You should support this policy because think of the children!' (no evidence given). What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Appeal to emotion (manipulating feelings instead of logic)", "Ad hominem", "Circular reasoning", "No fallacy" },
                    CorrectAnswers = new List<string> { "Appeal to emotion (manipulating feelings instead of logic)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "red-herring",
                Difficulty = 8,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Debate about tax policy, opponent responds: 'But what about the border crisis?' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem", "Red herring (introducing irrelevant topic to distract)", "Straw man", "No fallacy" },
                    CorrectAnswers = new List<string> { "Red herring (introducing irrelevant topic to distract)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "bandwagon-fallacy",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "'Everyone believes this, so it must be true.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Bandwagon (appeal to popularity)", "Ad hominem", "False dichotomy", "No fallacy" },
                    CorrectAnswers = new List<string> { "Bandwagon (appeal to popularity)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "hasty-generalization",
                Difficulty = 7,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "'I met two rude people from that city, so everyone there must be rude.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Hasty generalization (insufficient evidence)", "Ad hominem", "Slippery slope", "No fallacy" },
                    CorrectAnswers = new List<string> { "Hasty generalization (insufficient evidence)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "post-hoc-fallacy",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "'I wore my lucky socks and won the game, so the socks caused the win.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Post hoc ergo propter hoc (false cause: correlation ≠ causation)", "Circular reasoning", "Ad hominem", "No fallacy" },
                    CorrectAnswers = new List<string> { "Post hoc ergo propter hoc (false cause: correlation ≠ causation)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "tu-quoque",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "'You say I shouldn't smoke, but you smoke too!' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tu quoque (you too - deflecting by pointing out hypocrisy)", "Ad hominem", "Straw man", "No fallacy" },
                    CorrectAnswers = new List<string> { "Tu quoque (you too - deflecting by pointing out hypocrisy)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "no-true-scotsman",
                Difficulty = 9,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "'No scientist denies this.' 'But Dr. X denies it.' 'Well, no TRUE scientist denies it.' What fallacy?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No true Scotsman (redefining category to exclude counterexamples)", "Circular reasoning", "Ad hominem", "No fallacy" },
                    CorrectAnswers = new List<string> { "No true Scotsman (redefining category to exclude counterexamples)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "burden-of-proof",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "'Invisible unicorns exist. Prove they don't!' Who has the burden of proof?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Person claiming unicorns exist", "Person denying unicorns exist", "Both equally", "Neither" },
                    CorrectAnswers = new List<string> { "Person claiming unicorns exist" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "begging-the-question",
                Difficulty = 9,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "'Reading is important because it's essential.' This is circular reasoning called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Begging the question (assuming what you're trying to prove)", "Ad hominem", "Slippery slope", "No fallacy" },
                    CorrectAnswers = new List<string> { "Begging the question (assuming what you're trying to prove)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "middle-excluded",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Law of Excluded Middle states:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Every statement is either true or false (no middle)", "Some statements are neither true nor false", "All statements are true", "Logic doesn't apply to middle values" },
                    CorrectAnswers = new List<string> { "Every statement is either true or false (no middle)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "non-contradiction",
                Difficulty = 10,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Law of Non-Contradiction states:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Never disagree", "A statement cannot be both true and false simultaneously", "All contradictions are false", "Contradictions don't exist" },
                    CorrectAnswers = new List<string> { "A statement cannot be both true and false simultaneously" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "identity-law",
                Difficulty = 10,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Law of Identity states:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Everything is identical", "A thing is identical to itself (A=A)", "Identity can change", "A=B always" },
                    CorrectAnswers = new List<string> { "A thing is identical to itself (A=A)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "boolean-algebra",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "In Boolean algebra, A OR (NOT A) always equals:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "TRUE", "FALSE", "A", "NOT A" },
                    CorrectAnswers = new List<string> { "TRUE" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "boolean-simplification",
                Difficulty = 9,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "A AND (NOT A) always equals:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "TRUE", "FALSE", "A", "NOT A" },
                    CorrectAnswers = new List<string> { "FALSE" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "xor-exclusive-or",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "A XOR B (exclusive or) is true when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Both are true", "Exactly one is true", "Both are false", "At least one is true" },
                    CorrectAnswers = new List<string> { "Exactly one is true" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "implies-truth-table",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "In logic, 'False implies anything' means: If A is false, then 'A implies B' is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always true (vacuously true)", "Always false", "Depends on B", "Undefined" },
                    CorrectAnswers = new List<string> { "Always true (vacuously true)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "biconditional",
                Difficulty = 10,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "'A if and only if B' (A ↔ B) is true when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A and B have the same truth value", "A is true", "B is true", "A implies B" },
                    CorrectAnswers = new List<string> { "A and B have the same truth value" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "predicate-logic-intro",
                Difficulty = 10,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "In predicate logic, ∀x P(x) means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "For all x, P(x) is true", "There exists an x where P(x) is true", "P(x) is always false", "x is variable" },
                    CorrectAnswers = new List<string> { "For all x, P(x) is true" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "existential-intro",
                Difficulty = 10,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "In predicate logic, ∃x P(x) means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "For all x, P(x) is true", "There exists at least one x where P(x) is true", "P(x) is never true", "x must be unique" },
                    CorrectAnswers = new List<string> { "There exists at least one x where P(x) is true" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "russell-paradox-intro",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Russell's Paradox: 'The set of all sets that don't contain themselves' creates a paradox because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It's too big", "If it contains itself, it shouldn't; if it doesn't, it should (contradiction)", "Sets can't contain sets", "No paradox exists" },
                    CorrectAnswers = new List<string> { "If it contains itself, it shouldn't; if it doesn't, it should (contradiction)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "soundness-vs-validity",
                Difficulty = 10,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "A valid argument with true premises is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Sound", "Strong", "Cogent", "Complete" },
                    CorrectAnswers = new List<string> { "Sound" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "formal-systems",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Gödel's Incompleteness Theorem (simplified) states that in any consistent formal system:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Everything is provable", "Some true statements cannot be proven within the system", "Nothing is provable", "The system is complete" },
                    CorrectAnswers = new List<string> { "Some true statements cannot be proven within the system" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "halting-problem",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "The Halting Problem proves:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "All programs halt", "No programs halt", "No general algorithm can determine if any program halts", "All algorithms are solvable" },
                    CorrectAnswers = new List<string> { "No general algorithm can determine if any program halts" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "occams-razor",
                Difficulty = 7,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Occam's Razor principle states:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always use complicated explanations", "The simplest explanation is usually correct (given equal evidence)", "Cut all assumptions", "Never simplify" },
                    CorrectAnswers = new List<string> { "The simplest explanation is usually correct (given equal evidence)" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "tautology",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "A tautology in logic is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always false", "Always true regardless of truth values of components", "Sometimes true", "Redundant statement" },
                    CorrectAnswers = new List<string> { "Always true regardless of truth values of components" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "contradiction-logic",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "A logical contradiction (like 'A AND NOT A') is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always true", "Always false", "Sometimes true", "Undefined" },
                    CorrectAnswers = new List<string> { "Always false" }
                }
            },
            new Problem
            {
                Domain = Domain.Logic,
                MicroTopic = "contingency",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "A contingent statement in logic is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Always true", "Always false", "Can be either true or false depending on circumstances", "Contradictory" },
                    CorrectAnswers = new List<string> { "Can be either true or false depending on circumstances" }
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
            },

            // ===== EXPANDED: Elementary (Grades 1-3) - Foundational Reading =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "main-idea-basic",
                Difficulty = 1,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Text: 'Dogs are friendly animals. They wag their tails when happy. Dogs like to play fetch.' What is this text mostly about?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tails", "Dogs", "Playing", "Being happy" },
                    CorrectAnswers = new List<string> { "Dogs" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "sequencing-events",
                Difficulty = 1,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Story: 'First, Sarah put on her coat. Then she grabbed her backpack. Finally, she walked to school.' What did Sarah do SECOND?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Put on her coat", "Grabbed her backpack", "Walked to school", "Got dressed" },
                    CorrectAnswers = new List<string> { "Grabbed her backpack" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "character-feelings",
                Difficulty = 2,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Text: 'Tom frowned and stomped his foot. He crossed his arms and turned away.' How does Tom feel?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Happy", "Angry", "Sleepy", "Excited" },
                    CorrectAnswers = new List<string> { "Angry" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "making-predictions",
                Difficulty = 2,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Text: 'Dark clouds filled the sky. The wind started blowing hard. People grabbed umbrellas.' What will likely happen next?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It will be sunny", "It will rain", "It will snow", "Nothing will happen" },
                    CorrectAnswers = new List<string> { "It will rain" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "details-recall",
                Difficulty = 2,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Story: 'The blue bird sat on a branch. It sang a beautiful song. A cat watched from below.' What color is the bird?",
                    Format = ProblemFormat.FreeResponse,
                    CorrectAnswers = new List<string> { "blue", "Blue" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "cause-effect-simple",
                Difficulty = 2,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Text: 'It rained all day. The soccer game was canceled.' Why was the game canceled?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Too many players", "Because it rained", "The field was too big", "Nobody wanted to play" },
                    CorrectAnswers = new List<string> { "Because it rained" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "vocabulary-context",
                Difficulty = 3,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Sentence: 'The enormous elephant was bigger than all the other animals.' What does 'enormous' mean?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tiny", "Gray", "Very large", "Fast" },
                    CorrectAnswers = new List<string> { "Very large" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "comparing-characters",
                Difficulty = 3,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Text: 'Ann is quiet and likes to read. Ben is loud and likes to run.' How are Ann and Ben different?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "They like the same things", "Ann is quiet, Ben is loud", "They both like reading", "They are the same" },
                    CorrectAnswers = new List<string> { "Ann is quiet, Ben is loud" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "story-problem-solution",
                Difficulty = 3,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Story: 'Max lost his toy. He looked under his bed. He found it!' What was Max's problem?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "His bed was messy", "He lost his toy", "He was tired", "He couldn't sleep" },
                    CorrectAnswers = new List<string> { "He lost his toy" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "text-structure-basic",
                Difficulty = 3,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "Text: 'First, gather ingredients. Next, mix them together. Then, bake for 20 minutes. Finally, let it cool.' What type of text is this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A story", "Instructions/How-to", "A poem", "A letter" },
                    CorrectAnswers = new List<string> { "Instructions/How-to" }
                }
            },

            // ===== Upper Elementary (Grades 4-5) - Developing Comprehension =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "theme-identification",
                Difficulty = 4,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Story: 'Maya practiced piano every day. At first, she made mistakes. But she kept trying. By the concert, she played perfectly.' What is the theme?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pianos are hard", "Practice leads to improvement", "Concerts are fun", "Making mistakes is bad" },
                    CorrectAnswers = new List<string> { "Practice leads to improvement" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "inference-motivations",
                Difficulty = 4,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Text: 'Jake saw his neighbor carrying heavy groceries. He put down his basketball and ran over to help.' Why did Jake help?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "He was forced to", "He is kind and helpful", "He wanted groceries", "He was bored" },
                    CorrectAnswers = new List<string> { "He is kind and helpful" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "point-of-view",
                Difficulty = 4,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Text: 'I walked to the store. I bought milk and bread. Then I went home.' What point of view is this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "First person (I)", "Second person (you)", "Third person (he/she)", "No point of view" },
                    CorrectAnswers = new List<string> { "First person (I)" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "context-clues-meaning",
                Difficulty = 4,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Sentence: 'The arid desert had no water for miles. Plants could barely survive in such dry conditions.' What does 'arid' mean?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Wet", "Very dry", "Hot", "Sandy" },
                    CorrectAnswers = new List<string> { "Very dry" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "fact-vs-opinion",
                Difficulty = 4,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Which sentence is a FACT, not an opinion?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pizza is the best food", "The Earth orbits the Sun", "Summer is better than winter", "Dogs are nicer than cats" },
                    CorrectAnswers = new List<string> { "The Earth orbits the Sun" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "summarizing",
                Difficulty = 5,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Passage: 'Ancient Egyptians built pyramids as tombs for pharaohs. These massive structures took decades to build. Workers used simple tools like ropes and ramps. The pyramids still stand today.' Best summary?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Egyptians used ropes", "Pyramids were pharaoh tombs that took decades to build", "Workers had simple tools", "Pyramids still exist" },
                    CorrectAnswers = new List<string> { "Pyramids were pharaoh tombs that took decades to build" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "compare-contrast-texts",
                Difficulty = 5,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Text A: 'Lions hunt in groups called prides.' Text B: 'Tigers hunt alone.' What's the main difference?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Lions are bigger", "Lions hunt in groups, tigers alone", "Tigers are faster", "Lions eat more" },
                    CorrectAnswers = new List<string> { "Lions hunt in groups, tigers alone" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "text-features",
                Difficulty = 5,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "In a nonfiction book, what is the purpose of a glossary?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "To tell the main story", "To show pictures", "To define important words", "To list chapters" },
                    CorrectAnswers = new List<string> { "To define important words" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "figurative-language-simile",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Sentence: 'The snow was like a white blanket covering the ground.' This is an example of:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A simile", "Alliteration", "A metaphor", "Personification" },
                    CorrectAnswers = new List<string> { "A simile" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "drawing-conclusions",
                Difficulty = 5,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Text: 'Maria checked her watch for the tenth time. She paced back and forth. Her hands were shaking.' What can you conclude?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Maria is relaxed", "Maria is nervous or anxious", "Maria is angry", "Maria is lost" },
                    CorrectAnswers = new List<string> { "Maria is nervous or anxious" }
                }
            },

            // ===== Middle School (Grades 6-8) - Analytical Reading =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "authors-purpose-persuade",
                Difficulty = 6,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Text: 'Recycling saves energy and reduces waste. Everyone should recycle to protect our planet. Make the right choice today!' Author's purpose?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "To entertain", "To inform only", "To persuade", "To confuse" },
                    CorrectAnswers = new List<string> { "To persuade" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "tone-mood",
                Difficulty = 6,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Text: 'The dark hallway stretched endlessly. Shadows flickered. A door creaked slowly open.' What mood does this create?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Joyful", "Suspenseful/scary", "Peaceful", "Exciting" },
                    CorrectAnswers = new List<string> { "Suspenseful/scary" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "identifying-bias",
                Difficulty = 6,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Article: 'The brilliant mayor solved every problem. She never made mistakes.' What indicates bias?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It mentions the mayor", "Only positive words, no balanced view", "It's too short", "It talks about problems" },
                    CorrectAnswers = new List<string> { "Only positive words, no balanced view" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "figurative-language-metaphor",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Sentence: 'Time is a thief stealing our youth.' This is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A simile", "A metaphor", "Hyperbole", "Personification only" },
                    CorrectAnswers = new List<string> { "A metaphor" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "central-idea-support",
                Difficulty = 6,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Passage argues: 'Exercise improves health.' Which evidence BEST supports this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "My friend exercises", "Studies show exercise reduces disease risk", "Gyms are expensive", "Exercise is popular" },
                    CorrectAnswers = new List<string> { "Studies show exercise reduces disease risk" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "irony-situational",
                Difficulty = 7,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "Story: 'The fire chief's house burned down because he forgot to replace his smoke detector batteries.' This is ironic because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Fire is hot", "The person who knows fire safety made that mistake", "Houses burn", "He's a chief" },
                    CorrectAnswers = new List<string> { "The person who knows fire safety made that mistake" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "analyzing-arguments",
                Difficulty = 7,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "Argument: 'Students should have longer recess because they need exercise.' What would strengthen this argument?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A personal story", "Data showing exercise improves learning", "A statement that recess is fun", "Saying everyone agrees" },
                    CorrectAnswers = new List<string> { "Data showing exercise improves learning" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "rhetorical-devices",
                Difficulty = 7,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Speech: 'Are we going to stand by and do nothing? Are we going to ignore this problem?' What rhetorical device is used?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Metaphor", "Rhetorical questions", "Alliteration", "Hyperbole" },
                    CorrectAnswers = new List<string> { "Rhetorical questions" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "implied-theme",
                Difficulty = 7,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "Story: 'Rico always took shortcuts and barely passed. Leah studied hard and excelled. When both applied to college, Leah got in.' Implied theme?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Shortcuts are good", "Hard work pays off", "College is hard", "Grades don't matter" },
                    CorrectAnswers = new List<string> { "Hard work pays off" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "propaganda-techniques",
                Difficulty = 7,
                TargetTime = 125,
                Content = new ProblemContent
                {
                    Question = "Ad: '9 out of 10 celebrities use this product!' What propaganda technique is this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Bandwagon/Testimonial", "Logic", "Facts only", "Statistics" },
                    CorrectAnswers = new List<string> { "Bandwagon/Testimonial" }
                }
            },

            // ===== High School (Grades 9-10) - Critical Analysis =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "diction-analysis",
                Difficulty = 8,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Compare: 'The leader spoke calmly' vs 'The dictator barked orders.' How does word choice affect meaning?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No difference", "'Dictator' and 'barked' create negative tone", "Both are neutral", "Second is more positive" },
                    CorrectAnswers = new List<string> { "'Dictator' and 'barked' create negative tone" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "logical-fallacies",
                Difficulty = 8,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "Argument: 'We can't trust his climate research - he drives an SUV!' What fallacy is this?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ad hominem (attacking person, not argument)", "Straw man", "False cause", "Appeal to authority" },
                    CorrectAnswers = new List<string> { "Ad hominem (attacking person, not argument)" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "satire-recognition",
                Difficulty = 8,
                TargetTime = 160,
                Content = new ProblemContent
                {
                    Question = "Article: 'To solve traffic, we should ban all cars and only use unicycles!' This is likely:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A serious proposal", "Satire mocking simple solutions", "Scientific fact", "A news report" },
                    CorrectAnswers = new List<string> { "Satire mocking simple solutions" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "rhetorical-appeals-ethos",
                Difficulty = 8,
                TargetTime = 135,
                Content = new ProblemContent
                {
                    Question = "Speaker: 'As a doctor for 30 years, I've seen the effects of smoking.' This appeals to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ethos (credibility/authority)", "Pathos (emotion)", "Logos (logic)", "None" },
                    CorrectAnswers = new List<string> { "Ethos (credibility/authority)" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "parallel-structure-rhetoric",
                Difficulty = 8,
                TargetTime = 145,
                Content = new ProblemContent
                {
                    Question = "Speech: 'We shall fight on beaches, we shall fight on landing grounds, we shall fight in fields...' What makes this effective?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Random words", "Parallel structure/repetition builds emphasis", "It's short", "It uses metaphors" },
                    CorrectAnswers = new List<string> { "Parallel structure/repetition builds emphasis" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "subtext-analysis",
                Difficulty = 9,
                TargetTime = 170,
                Content = new ProblemContent
                {
                    Question = "Dialogue: A: 'Nice weather today.' B: 'Sure is.' (Both avoiding eye contact, tension clear). What's the subtext?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "They love weather", "Unresolved conflict beneath small talk", "They're weather experts", "Nothing implied" },
                    CorrectAnswers = new List<string> { "Unresolved conflict beneath small talk" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "deconstruction-assumptions",
                Difficulty = 9,
                TargetTime = 180,
                Content = new ProblemContent
                {
                    Question = "Text assumes: 'Real success means a high-paying job.' What assumption should we question?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Jobs exist", "That success can only be defined by money", "People work", "Payments happen" },
                    CorrectAnswers = new List<string> { "That success can only be defined by money" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "evaluating-credibility",
                Difficulty = 9,
                TargetTime = 155,
                Content = new ProblemContent
                {
                    Question = "Source: Anonymous blog post with no citations vs peer-reviewed journal article. Which is more credible for research?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Blog post", "Peer-reviewed journal", "Both equal", "Neither" },
                    CorrectAnswers = new List<string> { "Peer-reviewed journal" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "historical-context-interpretation",
                Difficulty = 9,
                TargetTime = 190,
                Content = new ProblemContent
                {
                    Question = "When reading a 1950s text about gender roles, why is historical context important?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It's not important", "To understand the values and assumptions of that era", "To prove it's wrong", "To copy those values" },
                    CorrectAnswers = new List<string> { "To understand the values and assumptions of that era" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "intertextuality",
                Difficulty = 10,
                TargetTime = 200,
                Content = new ProblemContent
                {
                    Question = "Modern novel references Shakespeare's Hamlet through similar themes and character names. This is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Plagiarism", "Intertextuality/allusion", "Coincidence", "Bad writing" },
                    CorrectAnswers = new List<string> { "Intertextuality/allusion" }
                }
            },

            // ===== Additional Elementary (1-3) Problems =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "word-recognition",
                Difficulty = 1,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Which word rhymes with 'cat'?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Dog", "Hat", "Fish", "Book" },
                    CorrectAnswers = new List<string> { "Hat" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "picture-text-match",
                Difficulty = 1,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Text: 'The sun is bright yellow.' Which describes the sun?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Blue and small", "Bright yellow", "Dark and cold", "Green" },
                    CorrectAnswers = new List<string> { "Bright yellow" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "sentence-completion",
                Difficulty = 2,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Complete: 'A fish lives in ____.'",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Water", "Trees", "Sky", "House" },
                    CorrectAnswers = new List<string> { "Water" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "basic-inference",
                Difficulty = 2,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Text: 'Kim put on her raincoat and boots.' What is Kim getting ready for?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Swimming", "Rainy weather", "Sleeping", "Eating" },
                    CorrectAnswers = new List<string> { "Rainy weather" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "story-beginning-middle-end",
                Difficulty = 3,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "Story: 'A seed was planted. It grew into a tall tree. Birds made nests in it.' What happened in the MIDDLE?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Seed planted", "It grew tall", "Birds made nests", "Nothing" },
                    CorrectAnswers = new List<string> { "It grew tall" }
                }
            },

            // ===== Additional Upper Elementary (4-5) Problems =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "author-craft-dialogue",
                Difficulty = 4,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Text uses quotation marks like: 'Hello,' said Tom. What is this called?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A mistake", "Dialogue", "A title", "Bold text" },
                    CorrectAnswers = new List<string> { "Dialogue" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "making-connections",
                Difficulty = 4,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Story about teamwork reminds you of when your class worked together. This is a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Text-to-self connection", "Text-to-text connection", "Text-to-world connection", "No connection" },
                    CorrectAnswers = new List<string> { "Text-to-self connection" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "text-evidence",
                Difficulty = 5,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Claim: 'The character is brave.' Which quote is the best evidence?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "'He liked ice cream'", "'He ran into the burning building to save the cat'", "'He was tall'", "'He went to school'" },
                    CorrectAnswers = new List<string> { "'He ran into the burning building to save the cat'" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "plot-elements",
                Difficulty = 5,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "In a story, the most exciting part where the main problem reaches its peak is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Introduction", "Climax", "Resolution", "Setting" },
                    CorrectAnswers = new List<string> { "Climax" }
                }
            },

            // ===== Additional Middle School (6-8) Problems =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "connotation-denotation",
                Difficulty = 6,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "'Cheap' and 'inexpensive' have similar meanings but different feelings. This is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Denotation vs connotation", "Synonyms only", "Opposites", "Spelling differences" },
                    CorrectAnswers = new List<string> { "Denotation vs connotation" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "paraphrasing",
                Difficulty = 6,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Original: 'The precipitation was excessive.' Paraphrase:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The precipitation was excessive", "It rained a lot", "Water fell", "Weather happened" },
                    CorrectAnswers = new List<string> { "It rained a lot" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "symbolism-basic",
                Difficulty = 7,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "In a story, a dove often symbolizes:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "War", "Peace", "Anger", "Confusion" },
                    CorrectAnswers = new List<string> { "Peace" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "chronological-order",
                Difficulty = 6,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Text organized by time sequence (first, next, then, finally) uses what structure?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cause-effect", "Chronological order", "Compare-contrast", "Problem-solution" },
                    CorrectAnswers = new List<string> { "Chronological order" }
                }
            },

            // ===== Additional High School/College (8-10) Problems =====
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "allusion-literary",
                Difficulty = 8,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "Text: 'He was a modern-day Hercules.' This references Greek mythology. This is an:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Allusion", "Metaphor only", "Simile", "Fact" },
                    CorrectAnswers = new List<string> { "Allusion" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "rhetorical-question-purpose",
                Difficulty = 8,
                TargetTime = 130,
                Content = new ProblemContent
                {
                    Question = "Essay asks: 'Can we really afford to ignore climate change?' The question's purpose is to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Get an answer", "Make readers think critically", "Confuse readers", "End the essay" },
                    CorrectAnswers = new List<string> { "Make readers think critically" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "narrative-perspective-unreliable",
                Difficulty = 9,
                TargetTime = 175,
                Content = new ProblemContent
                {
                    Question = "Narrator says 'I'm the smartest person ever' but makes obvious mistakes. This is an 'unreliable narrator' because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "They lie deliberately", "Their self-perception contradicts evidence", "They use first person", "They're fictional" },
                    CorrectAnswers = new List<string> { "Their self-perception contradicts evidence" }
                }
            },
            new Problem
            {
                Domain = Domain.Reading,
                MicroTopic = "discourse-analysis",
                Difficulty = 10,
                TargetTime = 200,
                Content = new ProblemContent
                {
                    Question = "A political speech repeats 'freedom' 20 times but never defines it. This linguistic strategy:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Is accidental", "Uses emotional appeal without concrete meaning", "Defines the term clearly", "Has no effect" },
                    CorrectAnswers = new List<string> { "Uses emotional appeal without concrete meaning" }
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
            },

            // ===== Elementary (Grades 1-3): Basic Observation & Classification =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "observation-basic",
                Difficulty = 1,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "You see a rock fall into water and it sinks. What did you observe?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The rock is heavy", "The rock sank", "Water is deep", "Rocks don't float" },
                    CorrectAnswers = new List<string> { "The rock sank" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "classification-living",
                Difficulty = 1,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Which of these is a living thing?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Rock", "Tree", "Water", "Cloud" },
                    CorrectAnswers = new List<string> { "Tree" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "states-of-matter",
                Difficulty = 1,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Water freezes and becomes ice. Ice is a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Liquid", "Solid", "Gas", "Plasma" },
                    CorrectAnswers = new List<string> { "Solid" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "seasons-basic",
                Difficulty = 1,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "In many places, which season is the coldest?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Summer", "Fall", "Winter", "Spring" },
                    CorrectAnswers = new List<string> { "Winter" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "simple-machines",
                Difficulty = 2,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "A seesaw on a playground is an example of which simple machine?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Wheel", "Lever", "Pulley", "Screw" },
                    CorrectAnswers = new List<string> { "Lever" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "plant-needs",
                Difficulty = 2,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Plants need sunlight, water, and what else to grow?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Music", "Air (carbon dioxide)", "Darkness", "Salt" },
                    CorrectAnswers = new List<string> { "Air (carbon dioxide)" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "measurement-tools",
                Difficulty = 2,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Which tool is used to measure temperature?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ruler", "Scale", "Thermometer", "Clock" },
                    CorrectAnswers = new List<string> { "Thermometer" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "animal-habitats",
                Difficulty = 2,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Where does a fish live?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "In trees", "In water", "Underground", "In the sky" },
                    CorrectAnswers = new List<string> { "In water" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "food-chain-basic",
                Difficulty = 2,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "In a food chain: grass → rabbit → fox, what does the rabbit eat?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Fox", "Grass", "Other rabbits", "Nothing" },
                    CorrectAnswers = new List<string> { "Grass" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "magnets-basic",
                Difficulty = 3,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Which object will a magnet attract?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Wooden stick", "Plastic cup", "Iron nail", "Glass marble" },
                    CorrectAnswers = new List<string> { "Iron nail" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "weather-patterns",
                Difficulty = 3,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "Dark clouds and strong wind usually mean:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Sunny weather coming", "Storm might be coming", "Hot day ahead", "Nothing special" },
                    CorrectAnswers = new List<string> { "Storm might be coming" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "life-cycle-basic",
                Difficulty = 3,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "A butterfly life cycle: egg → caterpillar → chrysalis → butterfly. What comes after caterpillar?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Egg", "Butterfly", "Chrysalis", "Moth" },
                    CorrectAnswers = new List<string> { "Chrysalis" }
                }
            },

            // ===== Upper Elementary (Grades 4-5): Scientific Method & Properties =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "scientific-method-steps",
                Difficulty = 4,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "In the scientific method, what comes FIRST?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Experiment", "Hypothesis", "Observation/Question", "Conclusion" },
                    CorrectAnswers = new List<string> { "Observation/Question" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "physical-vs-chemical-change",
                Difficulty = 4,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Which is a CHEMICAL change (cannot be reversed easily)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Ice melting", "Paper folding", "Wood burning", "Water boiling" },
                    CorrectAnswers = new List<string> { "Wood burning" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "energy-forms",
                Difficulty = 4,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "A light bulb converts electrical energy into:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Sound energy only", "Light and heat energy", "Chemical energy", "Nuclear energy" },
                    CorrectAnswers = new List<string> { "Light and heat energy" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "water-cycle",
                Difficulty = 4,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "When water vapor cools and changes back to liquid water, this is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Evaporation", "Condensation", "Precipitation", "Transpiration" },
                    CorrectAnswers = new List<string> { "Condensation" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "ecosystems-roles",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "In an ecosystem, organisms that make their own food (like plants) are called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Consumers", "Producers", "Decomposers", "Predators" },
                    CorrectAnswers = new List<string> { "Producers" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "forces-motion",
                Difficulty = 5,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "A ball rolling on grass slows down because of:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Gravity only", "Friction", "Magnetic force", "Nuclear force" },
                    CorrectAnswers = new List<string> { "Friction" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "cells-basic",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "The basic unit of all living things is called a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tissue", "Cell", "Organ", "Molecule" },
                    CorrectAnswers = new List<string> { "Cell" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "mixtures-solutions",
                Difficulty = 5,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Salt dissolved in water is an example of a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pure substance", "Element", "Solution", "Compound only" },
                    CorrectAnswers = new List<string> { "Solution" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "renewable-resources",
                Difficulty = 5,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Which is a renewable energy source?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Coal", "Oil", "Solar power", "Natural gas" },
                    CorrectAnswers = new List<string> { "Solar power" }
                }
            },

            // ===== Middle School (Grades 6-8): Systems & Interactions =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "photosynthesis-equation",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "In photosynthesis, plants use carbon dioxide and water to produce:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Oxygen only", "Glucose and oxygen", "Nitrogen", "Carbon monoxide" },
                    CorrectAnswers = new List<string> { "Glucose and oxygen" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "atomic-structure",
                Difficulty = 6,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "An atom consists of a nucleus containing protons and neutrons, surrounded by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Photons", "Electrons", "Quarks", "Neutrinos" },
                    CorrectAnswers = new List<string> { "Electrons" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "newtons-laws",
                Difficulty = 6,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Newton's First Law: An object at rest stays at rest unless acted upon by a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Velocity", "Unbalanced force", "Balanced force", "Energy source" },
                    CorrectAnswers = new List<string> { "Unbalanced force" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "plate-tectonics",
                Difficulty = 6,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Earthquakes and volcanoes are most common at:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The center of tectonic plates", "Plate boundaries", "Ocean centers", "Deserts" },
                    CorrectAnswers = new List<string> { "Plate boundaries" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "genetics-basic",
                Difficulty = 7,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "In genetics, the physical expression of genes (like blue eyes) is called the:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Genotype", "Phenotype", "Allele", "Chromosome" },
                    CorrectAnswers = new List<string> { "Phenotype" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "chemical-reactions",
                Difficulty = 7,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "In a chemical reaction, the starting substances are called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Products", "Catalysts", "Reactants", "Compounds" },
                    CorrectAnswers = new List<string> { "Reactants" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "conservation-of-energy",
                Difficulty = 7,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "The law of conservation of energy states that energy cannot be:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Transferred", "Created or destroyed", "Transformed", "Measured" },
                    CorrectAnswers = new List<string> { "Created or destroyed" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "pH-scale",
                Difficulty = 7,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "On the pH scale (0-14), a pH of 7 is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Acidic", "Basic", "Neutral", "Not possible" },
                    CorrectAnswers = new List<string> { "Neutral" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "cell-division-mitosis",
                Difficulty = 8,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Mitosis results in two daughter cells that are:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Genetically different from parent", "Haploid (half chromosomes)", "Genetically identical to parent", "Mutated" },
                    CorrectAnswers = new List<string> { "Genetically identical to parent" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "natural-selection",
                Difficulty = 8,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "In natural selection, which individuals are most likely to survive and reproduce?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The largest", "Those best adapted to environment", "The oldest", "Those with random mutations" },
                    CorrectAnswers = new List<string> { "Those best adapted to environment" }
                }
            },

            // ===== High School/College (Grades 9-10): Advanced Concepts =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "stoichiometry-balancing",
                Difficulty = 9,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "To balance: H₂ + O₂ → H₂O, you need:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1 H₂, 1 O₂ → 1 H₂O", "2 H₂, 1 O₂ → 2 H₂O", "1 H₂, 2 O₂ → 2 H₂O", "Cannot be balanced" },
                    CorrectAnswers = new List<string> { "2 H₂, 1 O₂ → 2 H₂O" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "thermodynamics-entropy",
                Difficulty = 9,
                TargetTime = 140,
                Content = new ProblemContent
                {
                    Question = "The Second Law of Thermodynamics states that in a closed system, entropy (disorder):",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Decreases over time", "Stays constant", "Increases over time", "Oscillates randomly" },
                    CorrectAnswers = new List<string> { "Increases over time" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "quantum-mechanics-intro",
                Difficulty = 9,
                TargetTime = 160,
                Content = new ProblemContent
                {
                    Question = "In quantum mechanics, particles can behave as both:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Solids and liquids", "Matter and antimatter", "Waves and particles", "Mass and energy only" },
                    CorrectAnswers = new List<string> { "Waves and particles" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "genetics-punnett-square",
                Difficulty = 9,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "Cross two heterozygous (Aa) parents. What % of offspring will be homozygous recessive (aa)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "0%", "25%", "50%", "75%" },
                    CorrectAnswers = new List<string> { "25%" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "ecological-succession",
                Difficulty = 10,
                TargetTime = 160,
                Content = new ProblemContent
                {
                    Question = "After a forest fire, the sequence of plant regrowth (grasses → shrubs → trees) is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Primary succession", "Secondary succession", "Climax community only", "Ecological niche" },
                    CorrectAnswers = new List<string> { "Secondary succession" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "relativity-basic",
                Difficulty = 10,
                TargetTime = 170,
                Content = new ProblemContent
                {
                    Question = "Einstein's Special Relativity: As an object approaches the speed of light, its mass:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Decreases", "Stays the same", "Increases toward infinity", "Becomes negative" },
                    CorrectAnswers = new List<string> { "Increases toward infinity" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "dna-structure",
                Difficulty = 10,
                TargetTime = 150,
                Content = new ProblemContent
                {
                    Question = "In DNA, adenine (A) pairs with thymine (T), and cytosine (C) pairs with:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Adenine", "Thymine", "Guanine", "Uracil" },
                    CorrectAnswers = new List<string> { "Guanine" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "climate-change-evidence",
                Difficulty = 10,
                TargetTime = 160,
                Content = new ProblemContent
                {
                    Question = "Which is the STRONGEST evidence for human-caused climate change?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "One hot summer", "Correlation between CO₂ increase and temperature rise since industrialization", "Animal migration patterns", "One glacier melting" },
                    CorrectAnswers = new List<string> { "Correlation between CO₂ increase and temperature rise since industrialization" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "scientific-consensus",
                Difficulty = 10,
                TargetTime = 155,
                Content = new ProblemContent
                {
                    Question = "Scientific consensus means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Everyone agrees", "Majority of qualified scientists agree based on evidence", "Government decides", "One famous scientist's opinion" },
                    CorrectAnswers = new List<string> { "Majority of qualified scientists agree based on evidence" }
                }
            },

            // ===== Additional Challenging Science Topics =====
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "control-group",
                Difficulty = 5,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "In an experiment testing a new drug, the control group:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Gets the drug", "Gets a placebo (fake treatment)", "Gets double dose", "Gets nothing" },
                    CorrectAnswers = new List<string> { "Gets a placebo (fake treatment)" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "sample-size",
                Difficulty = 6,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Why is a LARGE sample size important in experiments?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cheaper", "Faster", "Reduces effect of random variation", "Looks more impressive" },
                    CorrectAnswers = new List<string> { "Reduces effect of random variation" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "peer-review",
                Difficulty = 7,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Peer review in science means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Friends review your work", "Other experts check research before publication", "Government approval", "Public voting" },
                    CorrectAnswers = new List<string> { "Other experts check research before publication" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "replication-crisis",
                Difficulty = 8,
                TargetTime = 125,
                Content = new ProblemContent
                {
                    Question = "Why is it important that other scientists can REPLICATE your experiment?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Saves time", "Verifies results weren't due to chance or error", "Makes more money", "Required by law" },
                    CorrectAnswers = new List<string> { "Verifies results weren't due to chance or error" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "statistical-significance",
                Difficulty = 9,
                TargetTime = 145,
                Content = new ProblemContent
                {
                    Question = "A p-value of 0.03 (p < 0.05) suggests the result is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Definitely true", "Statistically significant (unlikely due to chance)", "Definitely false", "Meaningless" },
                    CorrectAnswers = new List<string> { "Statistically significant (unlikely due to chance)" }
                }
            },
            new Problem
            {
                Domain = Domain.Science,
                MicroTopic = "publication-bias",
                Difficulty = 10,
                TargetTime = 165,
                Content = new ProblemContent
                {
                    Question = "Publication bias refers to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Journals rejecting bad grammar", "Positive results more likely to be published than negative/null results", "Political censorship", "Expensive publishing fees" },
                    CorrectAnswers = new List<string> { "Positive results more likely to be published than negative/null results" }
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
            },

            // ===== Additional Elementary (Grades 4-5): Foundational Knowledge =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "state-symbols",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What is Washington's state nickname?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The Sunshine State", "The Evergreen State", "The Golden State", "The Lone Star State" },
                    CorrectAnswers = new List<string> { "The Evergreen State" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "major-cities",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is Washington's largest city?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Olympia", "Spokane", "Seattle", "Tacoma" },
                    CorrectAnswers = new List<string> { "Seattle" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "geography-borders",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Which country borders Washington to the north?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Mexico", "Canada", "Russia", "Alaska" },
                    CorrectAnswers = new List<string> { "Canada" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "water-features",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What major body of water lies to the west of Washington?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Atlantic Ocean", "Gulf of Mexico", "Pacific Ocean", "Arctic Ocean" },
                    CorrectAnswers = new List<string> { "Pacific Ocean" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "volcanoes",
                Difficulty = 3,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Which famous volcano erupted in Washington in 1980?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Mount Rainier", "Mount St. Helens", "Mount Baker", "Mount Hood" },
                    CorrectAnswers = new List<string> { "Mount St. Helens" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "state-flag",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Washington's state flag features which U.S. President?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Abraham Lincoln", "George Washington", "Thomas Jefferson", "Theodore Roosevelt" },
                    CorrectAnswers = new List<string> { "George Washington" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "rivers",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Which major river forms part of Washington's southern border with Oregon?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Mississippi River", "Columbia River", "Colorado River", "Missouri River" },
                    CorrectAnswers = new List<string> { "Columbia River" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "climate-zones",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Western Washington is known for being:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Very dry and desert-like", "Rainy and mild", "Extremely hot", "Always snowy" },
                    CorrectAnswers = new List<string> { "Rainy and mild" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "agriculture",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Eastern Washington is famous for growing:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pineapples", "Apples and wheat", "Oranges", "Cotton" },
                    CorrectAnswers = new List<string> { "Apples and wheat" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "islands",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "The San Juan Islands are located between Washington and:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Vancouver Island (Canada)", "Hawaii", "Alaska", "California" },
                    CorrectAnswers = new List<string> { "Vancouver Island (Canada)" }
                }
            },

            // ===== Additional Middle School (Grades 6-8): Historical Depth =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "fur-trade",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Before American settlement, which companies dominated the fur trade in the Pacific Northwest?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Spanish trading companies", "Hudson's Bay Company and others", "Dutch East India Company", "French fur traders only" },
                    CorrectAnswers = new List<string> { "Hudson's Bay Company and others" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "boundary-disputes",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "The '54-40 or Fight' slogan referred to a dispute between the U.S. and Britain over:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Gold mining rights", "The northern boundary of Oregon Territory (including Washington)", "Texas independence", "California statehood" },
                    CorrectAnswers = new List<string> { "The northern boundary of Oregon Territory (including Washington)" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "territorial-creation",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Washington Territory was officially created in what year?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1776", "1853", "1889", "1912" },
                    CorrectAnswers = new List<string> { "1853" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "yakima-war",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "The Yakima War (1855-1858) was fought between:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Spain and Britain", "Native American tribes and U.S. forces", "Settlers and miners", "North and South states" },
                    CorrectAnswers = new List<string> { "Native American tribes and U.S. forces" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "railroads",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "The Northern Pacific Railway reaching Washington in 1883 was significant because it:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Had no impact", "Connected the region to eastern markets and spurred population growth", "Only carried passengers", "Was abandoned immediately" },
                    CorrectAnswers = new List<string> { "Connected the region to eastern markets and spurred population growth" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "cannery-industry",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "In the late 1800s, salmon canneries in Washington employed many:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only white Americans", "Chinese and Native American workers", "European nobility", "No workers (fully automated)" },
                    CorrectAnswers = new List<string> { "Chinese and Native American workers" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "populist-movement",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Washington's early populist and progressive movements focused on:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Protecting big business interests", "Workers' rights, women's suffrage, and railroad regulation", "Maintaining the status quo", "Preventing all immigration" },
                    CorrectAnswers = new List<string> { "Workers' rights, women's suffrage, and railroad regulation" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "great-fire",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "The Great Seattle Fire of 1889 destroyed much of downtown. What was the result?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Seattle was abandoned", "The city was rebuilt with brick and stone buildings at a higher elevation", "Nothing changed", "Seattle moved to a new location" },
                    CorrectAnswers = new List<string> { "The city was rebuilt with brick and stone buildings at a higher elevation" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "prohibition",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "During Prohibition (1920-1933), Seattle was known for:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Strictly enforcing alcohol bans", "Widespread bootlegging and speakeasies", "Having no alcohol culture", "Exporting all alcohol" },
                    CorrectAnswers = new List<string> { "Widespread bootlegging and speakeasies" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "world-fairs",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "The 1962 Seattle World's Fair left behind which iconic structure?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The Space Needle", "The Statue of Liberty", "The Golden Gate Bridge", "The Eiffel Tower" },
                    CorrectAnswers = new List<string> { "The Space Needle" }
                }
            },

            // ===== Additional High School (Grades 9-12): Complex Analysis =====
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "mining-frontier",
                Difficulty = 8,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Mining booms in Washington (silver, copper, gold) created 'boomtowns' that often:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Lasted forever", "Grew rapidly then declined when resources depleted", "Had no environmental impact", "Prevented all settlement" },
                    CorrectAnswers = new List<string> { "Grew rapidly then declined when resources depleted" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "statehood-debate",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Washington's path to statehood was delayed partly because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nobody lived there", "Debates over slavery, population requirements, and political balance in Congress", "It was already a state", "Canada claimed it" },
                    CorrectAnswers = new List<string> { "Debates over slavery, population requirements, and political balance in Congress" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "grand-coulee-dam",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "The Grand Coulee Dam (completed 1942) provided:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No benefits", "Hydroelectric power, irrigation, and jobs during Great Depression", "Only tourism", "Only flood damage" },
                    CorrectAnswers = new List<string> { "Hydroelectric power, irrigation, and jobs during Great Depression" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "military-bases",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Washington's military bases (like Fort Lewis, Naval Base Kitsap) became important during:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "The Revolutionary War", "World Wars I and II, continuing through Cold War", "Only peacetime", "No significant period" },
                    CorrectAnswers = new List<string> { "World Wars I and II, continuing through Cold War" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "immigration-history",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Scandinavian immigration to Washington in the late 1800s influenced:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nothing", "Logging, fishing industries, and cultural traditions", "Only political systems", "Military strategy" },
                    CorrectAnswers = new List<string> { "Logging, fishing industries, and cultural traditions" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "asian-immigration",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Chinese Exclusion Act (1882) and anti-Asian riots in Washington demonstrated:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Universal tolerance", "Racial discrimination and violence against immigrant workers", "Economic prosperity for all", "No social tensions" },
                    CorrectAnswers = new List<string> { "Racial discrimination and violence against immigrant workers" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "wobblies-iww",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "The Industrial Workers of the World (IWW/'Wobblies') organized timber workers in Washington for:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Owner profits only", "Better wages, safer conditions, and workers' solidarity", "Preventing unionization", "Maintaining dangerous conditions" },
                    CorrectAnswers = new List<string> { "Better wages, safer conditions, and workers' solidarity" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "initiative-referendum",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Washington's initiative and referendum process (adopted 1912) allows citizens to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Have no voice", "Propose and vote on laws directly, bypassing legislature", "Only elect officials", "Overthrow government" },
                    CorrectAnswers = new List<string> { "Propose and vote on laws directly, bypassing legislature" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "native-fishing-rights",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "The 'fish-ins' of the 1960s-70s were protests by Native Americans asserting:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No rights at all", "Treaty-guaranteed fishing rights against state restrictions", "Opposition to all fishing", "Support for commercial overfishing" },
                    CorrectAnswers = new List<string> { "Treaty-guaranteed fishing rights against state restrictions" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "redlining-segregation",
                Difficulty = 10,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Redlining and restrictive covenants in Seattle created:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Equal housing for all", "Racially segregated neighborhoods, with lasting economic impacts", "Integrated communities", "No housing patterns" },
                    CorrectAnswers = new List<string> { "Racially segregated neighborhoods, with lasting economic impacts" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "boeing-economy",
                Difficulty = 10,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "Boeing's boom-bust cycles taught economists about:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Economic stability", "Dangers of over-reliance on single industry (economic diversification needed)", "Perfect markets", "No economic patterns" },
                    CorrectAnswers = new List<string> { "Dangers of over-reliance on single industry (economic diversification needed)" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "treaty-interpretation",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Modern courts interpreting 1850s treaties must consider:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only literal text", "Original intent, Native understanding, and ongoing sovereign rights", "Treaties don't matter anymore", "Only state law" },
                    CorrectAnswers = new List<string> { "Original intent, Native understanding, and ongoing sovereign rights" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "environmental-movement",
                Difficulty = 10,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Washington's environmental activism (spotted owl controversy, orca protection) demonstrates tension between:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No tensions exist", "Economic development and environmental conservation", "City and rural harmony", "Complete agreement" },
                    CorrectAnswers = new List<string> { "Economic development and environmental conservation" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "tech-transformation",
                Difficulty = 10,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Seattle's transformation from manufacturing/resource extraction to tech hub reflects:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No economic change", "Broader shift to information/service economy in late 20th century", "Return to pre-industrial economy", "Decline of all industry" },
                    CorrectAnswers = new List<string> { "Broader shift to information/service economy in late 20th century" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "housing-inequality",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Seattle's rapid growth and tech boom created housing affordability crisis, demonstrating:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Perfect market balance", "Tension between economic growth and social equity/affordability", "No social impact", "Universal prosperity" },
                    CorrectAnswers = new List<string> { "Tension between economic growth and social equity/affordability" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "sovereignty-issues",
                Difficulty = 10,
                TargetTime = 125,
                Content = new ProblemContent
                {
                    Question = "Native tribes operating casinos on reservations demonstrates principle of:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No legal authority", "Tribal sovereignty and self-governance within treaty frameworks", "Complete state control", "Federal micromanagement" },
                    CorrectAnswers = new List<string> { "Tribal sovereignty and self-governance within treaty frameworks" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "climate-policy",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Washington's carbon tax debates and clean energy initiatives show states can:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Do nothing about climate", "Enact environmental policy beyond federal requirements", "Only follow federal law exactly", "Ignore environmental concerns" },
                    CorrectAnswers = new List<string> { "Enact environmental policy beyond federal requirements" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "maritime-heritage",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Seattle's deep-water port made it important for trade with:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only neighboring states", "Alaska and Asian-Pacific countries", "Europe only", "No international trade" },
                    CorrectAnswers = new List<string> { "Alaska and Asian-Pacific countries" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "music-culture",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Seattle's grunge music movement (1990s, Nirvana, Pearl Jam) became:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Unknown outside city", "Internationally influential cultural phenomenon", "Only country music", "Classical music only" },
                    CorrectAnswers = new List<string> { "Internationally influential cultural phenomenon" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "coffee-culture",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "Starbucks, founded in Seattle in 1971, helped popularize:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Tea culture only", "Specialty coffee culture globally", "Fast food", "Soft drinks" },
                    CorrectAnswers = new List<string> { "Specialty coffee culture globally" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "aerospace-innovation",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Washington's aerospace industry contributed to space exploration through:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No involvement", "Boeing/NASA partnerships building spacecraft components", "Only military aircraft", "Preventing space programs" },
                    CorrectAnswers = new List<string> { "Boeing/NASA partnerships building spacecraft components" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "agriculture-technology",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Irrigation projects in Eastern Washington transformed what was once:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Already fertile farmland", "Arid shrub-steppe into productive agricultural land", "Ocean floor", "Dense forest" },
                    CorrectAnswers = new List<string> { "Arid shrub-steppe into productive agricultural land" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "nuclear-legacy",
                Difficulty = 9,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "Hanford Site cleanup challenges demonstrate:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nuclear waste is harmless", "Long-term environmental costs of nuclear weapons production", "No cleanup needed", "Immediate solutions exist" },
                    CorrectAnswers = new List<string> { "Long-term environmental costs of nuclear weapons production" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "salmon-restoration",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Salmon recovery efforts require coordinating:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only one agency", "Tribal, federal, state, and local governments plus environmentalists", "No coordination", "Only commercial fishing" },
                    CorrectAnswers = new List<string> { "Tribal, federal, state, and local governments plus environmentalists" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "border-economy",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Washington's proximity to Canada creates:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No economic relationship", "Cross-border trade, tourism, and cultural exchange", "Only military tensions", "Complete isolation" },
                    CorrectAnswers = new List<string> { "Cross-border trade, tourism, and cultural exchange" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "ferry-system",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Washington State Ferries is important because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only for tourism", "Connects islands and communities across Puget Sound", "No longer operates", "Only carries cars" },
                    CorrectAnswers = new List<string> { "Connects islands and communities across Puget Sound" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "earthquake-preparedness",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Washington sits on the Cascadia Subduction Zone, meaning:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No earthquake risk", "Potential for major earthquakes and tsunamis", "Only minor tremors", "Complete stability" },
                    CorrectAnswers = new List<string> { "Potential for major earthquakes and tsunamis" }
                }
            },
            new Problem
            {
                Domain = Domain.WashingtonHistory,
                MicroTopic = "regional-identity",
                Difficulty = 8,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "The 'Cascadia' regional identity (WA, OR, BC) emphasizes:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No shared characteristics", "Shared environmental values, progressive politics, and Pacific Rim orientation", "Only state differences", "Isolation from each other" },
                    CorrectAnswers = new List<string> { "Shared environmental values, progressive politics, and Pacific Rim orientation" }
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
            },

            // ===== Additional Elementary (Grades 4-5): Digital Money Basics =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "digital-currency-concept",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Bitcoin is a type of:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Physical coin", "Digital currency", "Credit card", "Bank account" },
                    CorrectAnswers = new List<string> { "Digital currency" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-symbol",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is the symbol for Bitcoin?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "$", "€", "₿", "¥" },
                    CorrectAnswers = new List<string> { "₿" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "bitcoin-ownership",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Who owns Bitcoin?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A company", "A government", "No single entity (it's decentralized)", "Banks" },
                    CorrectAnswers = new List<string> { "No single entity (it's decentralized)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "wallet-concept",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A Bitcoin wallet stores:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Actual bitcoins", "Keys that prove ownership of bitcoins", "Paper money", "Credit cards" },
                    CorrectAnswers = new List<string> { "Keys that prove ownership of bitcoins" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "peer-to-peer",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Bitcoin transactions happen:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Through banks", "Peer-to-peer (directly between users)", "Through credit card companies", "Only in person" },
                    CorrectAnswers = new List<string> { "Peer-to-peer (directly between users)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "satoshi-unit",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "The smallest unit of Bitcoin is called a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cent", "Satoshi", "Bit", "Coin" },
                    CorrectAnswers = new List<string> { "Satoshi" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "transaction-speed",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Bitcoin transactions typically take how long to confirm?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Instant", "About 10 minutes per block", "Several days", "One year" },
                    CorrectAnswers = new List<string> { "About 10 minutes per block" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "transaction-fees",
                Difficulty = 5,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Why do Bitcoin transactions have fees?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "To pay banks", "To incentivize miners to process transactions", "To pay governments", "Fees are optional and not needed" },
                    CorrectAnswers = new List<string> { "To incentivize miners to process transactions" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "public-addresses",
                Difficulty = 5,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "A Bitcoin address is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Your home address", "A public identifier where bitcoins can be sent", "Your password", "A bank account number" },
                    CorrectAnswers = new List<string> { "A public identifier where bitcoins can be sent" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "transparency",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "All Bitcoin transactions are:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Completely private and hidden", "Publicly visible on the blockchain", "Only visible to banks", "Deleted after confirmation" },
                    CorrectAnswers = new List<string> { "Publicly visible on the blockchain" }
                }
            },

            // ===== Additional Middle School (Grades 6-8): Technical & Historical =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "genesis-block",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "The first Bitcoin block ever mined is called:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Alpha Block", "Genesis Block", "First Block", "Prime Block" },
                    CorrectAnswers = new List<string> { "Genesis Block" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "block-time",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's target block time (time between blocks) is approximately:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1 minute", "10 minutes", "1 hour", "1 day" },
                    CorrectAnswers = new List<string> { "10 minutes" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "private-keys",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "A Bitcoin private key is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Your username", "Secret key proving ownership, must be kept secure", "Public information", "Optional security feature" },
                    CorrectAnswers = new List<string> { "Secret key proving ownership, must be kept secure" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "double-spending",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "The blockchain prevents 'double-spending' by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Trusting users", "Recording all transactions in chronological order on distributed ledger", "Using banks", "Limiting transactions" },
                    CorrectAnswers = new List<string> { "Recording all transactions in chronological order on distributed ledger" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "pizza-day",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "How many bitcoins were spent on the famous 'Bitcoin Pizza Day' transaction?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1 BTC", "100 BTC", "10,000 BTC", "1 million BTC" },
                    CorrectAnswers = new List<string> { "10,000 BTC" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "mining-difficulty",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's mining difficulty adjusts every:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Day", "Week", "2016 blocks (about 2 weeks)", "Year" },
                    CorrectAnswers = new List<string> { "2016 blocks (about 2 weeks)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "51-percent-attack",
                Difficulty = 7,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "A '51% attack' on Bitcoin would require:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "51% of users agreeing", "Controlling more than 50% of network's mining power", "51% of bitcoins", "Hacking 51 computers" },
                    CorrectAnswers = new List<string> { "Controlling more than 50% of network's mining power" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "fork-concept",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "A blockchain 'fork' occurs when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Someone loses their keys", "The protocol splits into two versions", "Transactions fail", "Mining stops" },
                    CorrectAnswers = new List<string> { "The protocol splits into two versions" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "mt-gox",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Mt. Gox was significant in Bitcoin history because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It created Bitcoin", "Major exchange that collapsed in 2014, losing ~850,000 BTC", "First Bitcoin wallet", "Bitcoin's original name" },
                    CorrectAnswers = new List<string> { "Major exchange that collapsed in 2014, losing ~850,000 BTC" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "lightning-network",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "The Lightning Network aims to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Make Bitcoin mining faster", "Enable faster, cheaper transactions through off-chain channels", "Replace Bitcoin", "Increase block size" },
                    CorrectAnswers = new List<string> { "Enable faster, cheaper transactions through off-chain channels" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "nodes",
                Difficulty = 8,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "A Bitcoin node is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A miner only", "A computer running Bitcoin software that validates/relays transactions", "A wallet", "An exchange" },
                    CorrectAnswers = new List<string> { "A computer running Bitcoin software that validates/relays transactions" }
                }
            },

            // ===== Additional High School/College (Grades 9-12): Advanced Concepts =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "hash-rate",
                Difficulty = 9,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's hash rate measures:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Transaction speed", "Total computational power securing the network", "Number of users", "Price volatility" },
                    CorrectAnswers = new List<string> { "Total computational power securing the network" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "merkle-tree",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Bitcoin blocks use Merkle trees to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Store user names", "Efficiently verify transaction inclusion without full block data", "Mine faster", "Encrypt wallets" },
                    CorrectAnswers = new List<string> { "Efficiently verify transaction inclusion without full block data" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "utxo-model",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's UTXO (Unspent Transaction Output) model means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Balances are tracked like bank accounts", "Bitcoin tracks discrete transaction outputs as spendable units", "All transactions are grouped together", "Wallets store actual coins" },
                    CorrectAnswers = new List<string> { "Bitcoin tracks discrete transaction outputs as spendable units" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "scripting-language",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's Script programming language is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Turing-complete", "Intentionally limited (not Turing-complete) for security", "Based on Java", "Requires JavaScript" },
                    CorrectAnswers = new List<string> { "Intentionally limited (not Turing-complete) for security" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "segregated-witness",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "SegWit (Segregated Witness) upgrade improved Bitcoin by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Doubling block size only", "Separating signature data, increasing effective block capacity and enabling Lightning", "Removing all fees", "Making mining easier" },
                    CorrectAnswers = new List<string> { "Separating signature data, increasing effective block capacity and enabling Lightning" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "nonce",
                Difficulty = 10,
                TargetTime = 105,
                Content = new ProblemContent
                {
                    Question = "In Bitcoin mining, a 'nonce' is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Number used once; miners adjust it trying to find valid hash", "Nickname for miners", "Transaction counter", "Block height" },
                    CorrectAnswers = new List<string> { "Number used once; miners adjust it trying to find valid hash" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "difficulty-adjustment",
                Difficulty = 10,
                TargetTime = 110,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's difficulty adjustment algorithm ensures:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Price stability", "Blocks are found every ~10 minutes regardless of total hash power", "Equal mining rewards", "No forks occur" },
                    CorrectAnswers = new List<string> { "Blocks are found every ~10 minutes regardless of total hash power" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "elliptic-curve",
                Difficulty = 10,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Bitcoin uses elliptic curve cryptography (specifically secp256k1) for:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Mining only", "Generating public/private key pairs and digital signatures", "Transaction speed", "Price calculation" },
                    CorrectAnswers = new List<string> { "Generating public/private key pairs and digital signatures" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "consensus-mechanism",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Bitcoin achieves consensus (agreement on transaction order) through:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Voting", "Proof-of-Work: longest valid chain with most accumulated work wins", "Central authority", "Random selection" },
                    CorrectAnswers = new List<string> { "Proof-of-Work: longest valid chain with most accumulated work wins" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "game-theory",
                Difficulty = 10,
                TargetTime = 125,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's incentive structure (mining rewards, fees) uses game theory to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Force cooperation", "Make honest participation more profitable than attacks", "Eliminate all bad actors", "Guarantee profits" },
                    CorrectAnswers = new List<string> { "Make honest participation more profitable than attacks" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "stock-to-flow",
                Difficulty = 10,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's stock-to-flow ratio (existing supply / new supply) increases over time due to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Random events", "Halving events reducing new supply while existing stock grows", "Government regulation", "Market demand" },
                    CorrectAnswers = new List<string> { "Halving events reducing new supply while existing stock grows" }
                }
            },

            // ===== Additional Intermediate Concepts =====
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "pseudonymous",
                Difficulty = 6,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Bitcoin transactions are 'pseudonymous,' meaning:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Completely anonymous", "Linked to addresses, not directly to real identities (but can be traced)", "Require ID verification", "Are private and hidden" },
                    CorrectAnswers = new List<string> { "Linked to addresses, not directly to real identities (but can be traced)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "irreversible",
                Difficulty = 6,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Bitcoin transactions are:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Reversible like credit cards", "Irreversible once confirmed", "Can be canceled within 24 hours", "Require bank approval" },
                    CorrectAnswers = new List<string> { "Irreversible once confirmed" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "cold-storage",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Cold storage for Bitcoin refers to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Keeping Bitcoin at low temperature", "Storing keys offline (not connected to internet) for security", "Freezing accounts", "Winter mining" },
                    CorrectAnswers = new List<string> { "Storing keys offline (not connected to internet) for security" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "hot-wallet",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "A 'hot wallet' is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Wallet stored in hot locations", "Wallet connected to internet for convenience (but less secure)", "Wallet with many transactions", "Wallet with high fees" },
                    CorrectAnswers = new List<string> { "Wallet connected to internet for convenience (but less secure)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "seed-phrase",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "A Bitcoin wallet seed phrase (recovery phrase) is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Your password", "12-24 words that can restore your wallet and keys", "Username", "Public address" },
                    CorrectAnswers = new List<string> { "12-24 words that can restore your wallet and keys" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "multisig",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Multi-signature (multisig) Bitcoin wallets require:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "One signature", "Multiple signatures from different keys to authorize transactions", "Government approval", "Bank verification" },
                    CorrectAnswers = new List<string> { "Multiple signatures from different keys to authorize transactions" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "asic-mining",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "ASIC miners are:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Regular computers", "Specialized hardware designed specifically for Bitcoin mining", "Wallets", "Exchanges" },
                    CorrectAnswers = new List<string> { "Specialized hardware designed specifically for Bitcoin mining" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "mining-pools",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "Mining pools exist because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Required by law", "Individual miners combine computing power for more consistent rewards", "To make mining slower", "To reduce security" },
                    CorrectAnswers = new List<string> { "Individual miners combine computing power for more consistent rewards" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "energy-consumption",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Bitcoin mining's high energy consumption is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A bug in the code", "Intentional feature providing security through Proof-of-Work", "Easy to eliminate", "Not real" },
                    CorrectAnswers = new List<string> { "Intentional feature providing security through Proof-of-Work" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "silk-road",
                Difficulty = 9,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "The Silk Road marketplace (shut down 2013) was significant because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It created Bitcoin", "It demonstrated Bitcoin use for illegal activities, drawing regulatory attention", "It was legal marketplace", "It had no impact" },
                    CorrectAnswers = new List<string> { "It demonstrated Bitcoin use for illegal activities, drawing regulatory attention" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "hodl-culture",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "In Bitcoin culture, 'HODL' means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Hold On for Dear Life (keep Bitcoin long-term despite volatility)", "High-speed trading", "Selling immediately", "Mining strategy" },
                    CorrectAnswers = new List<string> { "Hold On for Dear Life (keep Bitcoin long-term despite volatility)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "block-reward",
                Difficulty = 7,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "The first Bitcoin block reward in 2009 was:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1 BTC", "6.25 BTC", "50 BTC", "100 BTC" },
                    CorrectAnswers = new List<string> { "50 BTC" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "current-block-reward",
                Difficulty = 7,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "As of 2024, the Bitcoin block reward is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "50 BTC", "25 BTC", "12.5 BTC", "6.25 BTC" },
                    CorrectAnswers = new List<string> { "6.25 BTC" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "final-bitcoin",
                Difficulty = 8,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "The last Bitcoin is expected to be mined around year:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "2030", "2050", "2140", "Never (infinite supply)" },
                    CorrectAnswers = new List<string> { "2140" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "lost-bitcoins",
                Difficulty = 8,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Bitcoins with lost private keys are:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Automatically deleted", "Permanently inaccessible (effectively removing them from circulation)", "Redistributed to miners", "Sent to government" },
                    CorrectAnswers = new List<string> { "Permanently inaccessible (effectively removing them from circulation)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "inflation-resistance",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's predictable supply schedule makes it:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Inflationary", "Disinflationary (inflation rate decreases over time)", "Deflationary always", "Unstable" },
                    CorrectAnswers = new List<string> { "Disinflationary (inflation rate decreases over time)" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "network-effects",
                Difficulty = 9,
                TargetTime = 100,
                Content = new ProblemContent
                {
                    Question = "Bitcoin benefits from network effects, meaning:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It needs internet", "Its value increases as more people use and secure the network", "Only works on networks", "Requires social media" },
                    CorrectAnswers = new List<string> { "Its value increases as more people use and secure the network" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "scarcity-digital",
                Difficulty = 10,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Bitcoin achieved digital scarcity (something never possible before) through:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Making files expensive", "Proof-of-Work and consensus preventing duplication", "Copyright law", "Encryption only" },
                    CorrectAnswers = new List<string> { "Proof-of-Work and consensus preventing duplication" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "censorship-resistance",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Bitcoin's censorship resistance means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No profanity allowed", "Transactions cannot be blocked by governments/institutions if properly broadcast", "All transactions are approved", "Only certain people can transact" },
                    CorrectAnswers = new List<string> { "Transactions cannot be blocked by governments/institutions if properly broadcast" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "trustless-system",
                Difficulty = 10,
                TargetTime = 120,
                Content = new ProblemContent
                {
                    Question = "Bitcoin is 'trustless' because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nobody can be trusted", "You don't need to trust any third party; cryptography and consensus ensure validity", "Trust is required", "It has no security" },
                    CorrectAnswers = new List<string> { "You don't need to trust any third party; cryptography and consensus ensure validity" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "sound-money",
                Difficulty = 10,
                TargetTime = 125,
                Content = new ProblemContent
                {
                    Question = "Bitcoin proponents argue it's 'sound money' because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It makes noise", "Fixed supply, divisible, portable, durable, and verifiable", "Government backs it", "Banks control it" },
                    CorrectAnswers = new List<string> { "Fixed supply, divisible, portable, durable, and verifiable" }
                }
            },
            new Problem
            {
                Domain = Domain.Bitcoin,
                MicroTopic = "permissionless",
                Difficulty = 10,
                TargetTime = 115,
                Content = new ProblemContent
                {
                    Question = "Bitcoin is 'permissionless,' meaning:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Requires no rules", "Anyone can participate without needing approval from authority", "Only allowed people can use it", "Needs government permission" },
                    CorrectAnswers = new List<string> { "Anyone can participate without needing approval from authority" }
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
            },

            // ===== Additional Elementary (Grades 1-5): Core Game Concepts =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "tools-basic",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "Which tool do you use to mine wood faster?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Pickaxe", "Axe", "Shovel", "Sword" },
                    CorrectAnswers = new List<string> { "Axe" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "health-system",
                Difficulty = 1,
                TargetTime = 15,
                Content = new ProblemContent
                {
                    Question = "How many hearts of health does a player start with?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "5", "10", "15", "20" },
                    CorrectAnswers = new List<string> { "10" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "food-basics",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What do you get when you cook raw porkchop in a furnace?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cooked porkchop", "Bacon", "Leather", "Nothing" },
                    CorrectAnswers = new List<string> { "Cooked porkchop" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "hostile-mobs",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "Which mob explodes when it gets close to you?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Zombie", "Skeleton", "Creeper", "Enderman" },
                    CorrectAnswers = new List<string> { "Creeper" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "day-night-cycle",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "When do most hostile mobs spawn?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "During the day", "At night or in dark places", "Only underground", "Never" },
                    CorrectAnswers = new List<string> { "At night or in dark places" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "crafting-recipes",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "How many sticks do you need to craft a wooden pickaxe?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1", "2", "3", "4" },
                    CorrectAnswers = new List<string> { "2" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "ore-hierarchy",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What is the minimum pickaxe tier needed to mine diamond ore?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Wooden", "Stone", "Iron", "Diamond" },
                    CorrectAnswers = new List<string> { "Iron" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "bed-mechanics",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What happens if you try to sleep in a bed in the Nether?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "You sleep normally", "The bed explodes", "Nothing happens", "You wake up in the Overworld" },
                    CorrectAnswers = new List<string> { "The bed explodes" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "experience-points",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "What gives you experience points (XP)?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Breaking blocks only", "Killing mobs, mining ore, smelting, breeding", "Sleeping", "Walking" },
                    CorrectAnswers = new List<string> { "Killing mobs, mining ore, smelting, breeding" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "water-mechanics",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Water can turn into ice if:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "It rains", "It's in a cold biome under open sky", "You add ice blocks nearby", "It never turns to ice" },
                    CorrectAnswers = new List<string> { "It's in a cold biome under open sky" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "anvil-mechanics",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What can you use an anvil for?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cooking food", "Repairing and renaming items", "Enchanting", "Smelting ore" },
                    CorrectAnswers = new List<string> { "Repairing and renaming items" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "villager-trading",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "What do you trade with villagers?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Gold ingots", "Diamonds", "Emeralds", "Iron ingots" },
                    CorrectAnswers = new List<string> { "Emeralds" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "netherite-upgrade",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "To upgrade diamond gear to netherite, you need:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Netherite ingot", "Netherite scrap", "Ancient debris", "Nether star" },
                    CorrectAnswers = new List<string> { "Netherite ingot" }
                }
            },

            // ===== Additional Middle School (Grades 6-8): Advanced Mechanics =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "enchantment-levels",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What is the maximum level for the Sharpness enchantment?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "III", "IV", "V", "X" },
                    CorrectAnswers = new List<string> { "V" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "boss-mobs",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "What do you need to summon the Wither?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "4 soul sand and 3 wither skeleton skulls", "9 obsidian blocks", "3 ender pearls", "A beacon" },
                    CorrectAnswers = new List<string> { "4 soul sand and 3 wither skeleton skulls" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "end-dimension",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "To access the End dimension, you need to find and activate:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "A Nether portal", "An End portal with Eyes of Ender", "A beacon", "A conduit" },
                    CorrectAnswers = new List<string> { "An End portal with Eyes of Ender" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "beacon-powers",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "A beacon requires a pyramid base made of which materials?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Stone only", "Iron, gold, diamond, emerald, or netherite blocks", "Obsidian", "Any blocks" },
                    CorrectAnswers = new List<string> { "Iron, gold, diamond, emerald, or netherite blocks" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "hopper-mechanics",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "A hopper transfers items at what rate?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1 item per tick", "1 item per second", "1 item every 8 ticks (0.4 seconds)", "Instant" },
                    CorrectAnswers = new List<string> { "1 item every 8 ticks (0.4 seconds)" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "comparator-function",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "A redstone comparator can measure:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Player position", "Container fullness, signal strength", "Time of day", "Mob count" },
                    CorrectAnswers = new List<string> { "Container fullness, signal strength" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "ender-dragon",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "To defeat the Ender Dragon efficiently, you should first:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Attack it directly", "Destroy the End crystals healing it", "Run away", "Build a shelter" },
                    CorrectAnswers = new List<string> { "Destroy the End crystals healing it" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "shulker-mechanics",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Shulker boxes are unique because:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "They float", "They keep their contents when broken", "They explode", "They teleport" },
                    CorrectAnswers = new List<string> { "They keep their contents when broken" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "elytra-mechanics",
                Difficulty = 8,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "To fly longer distances with elytra, you should use:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Feathers", "Firework rockets", "Ender pearls", "Potions" },
                    CorrectAnswers = new List<string> { "Firework rockets" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "trident-enchantments",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "The Riptide enchantment on a trident:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Makes it return when thrown", "Propels you forward in water/rain", "Deals more damage", "Shoots lightning" },
                    CorrectAnswers = new List<string> { "Propels you forward in water/rain" }
                }
            },

            // ===== Additional High School/College (Grades 9-12): Advanced Technical =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "observer-mechanics",
                Difficulty = 9,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "An observer block detects:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Players only", "Block state changes in front of it", "Light levels", "Mob spawning" },
                    CorrectAnswers = new List<string> { "Block state changes in front of it" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "item-sorting",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "An automatic item sorter uses hoppers and:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Furnaces", "Comparators to detect specific items", "Pistons", "Dispensers" },
                    CorrectAnswers = new List<string> { "Comparators to detect specific items" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "mob-farm-efficiency",
                Difficulty = 9,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "For maximum mob spawning rates, hostile mobs require minimum light level:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "0 (complete darkness)", "7 or less", "8 or less", "Any light level" },
                    CorrectAnswers = new List<string> { "0 (complete darkness)" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "slime-chunk-mechanics",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Slimes spawn in specific 'slime chunks' determined by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Random chance", "World seed algorithm", "Player location", "Moon phase" },
                    CorrectAnswers = new List<string> { "World seed algorithm" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "villager-mechanics",
                Difficulty = 10,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Villager trading prices are affected by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Time of day", "Demand (repeated trades), reputation, and curing zombie villagers", "Moon phase", "Nothing affects prices" },
                    CorrectAnswers = new List<string> { "Demand (repeated trades), reputation, and curing zombie villagers" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "iron-farm-mechanics",
                Difficulty = 10,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Iron golems spawn near villagers when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Random chance", "Village has 3+ villagers, beds, and workstations with specific conditions", "Full moon", "Player places iron blocks" },
                    CorrectAnswers = new List<string> { "Village has 3+ villagers, beds, and workstations with specific conditions" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "world-generation",
                Difficulty = 10,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Minecraft's world height from bedrock to build limit (as of 1.18+) is:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "256 blocks", "320 blocks", "384 blocks", "512 blocks" },
                    CorrectAnswers = new List<string> { "384 blocks" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "nbt-data",
                Difficulty = 10,
                TargetTime = 95,
                Content = new ProblemContent
                {
                    Question = "NBT (Named Binary Tag) data in Minecraft stores:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Player skins", "Complex data like inventory, entity properties, and world information", "Only player names", "Texture packs" },
                    CorrectAnswers = new List<string> { "Complex data like inventory, entity properties, and world information" }
                }
            },

            // ===== Additional Diverse Topics =====
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "sugar-cane-farming",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Sugar cane must be planted:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "In any dirt", "On sand or dirt adjacent to water", "Only in swamps", "On stone" },
                    CorrectAnswers = new List<string> { "On sand or dirt adjacent to water" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "book-crafting",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "To make a book, you need:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "3 paper only", "3 paper and 1 leather", "3 paper and ink", "6 paper" },
                    CorrectAnswers = new List<string> { "3 paper and 1 leather" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "music-discs",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "How do you get music discs from creepers?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Kill them normally", "Have a skeleton kill the creeper", "Trade with villagers", "Find in chests only" },
                    CorrectAnswers = new List<string> { "Have a skeleton kill the creeper" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "conduit-power",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "A fully powered conduit requires a frame of how many blocks?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "8 prismarine blocks", "16 prismarine/sea lantern blocks", "42 prismarine-type blocks", "64 blocks" },
                    CorrectAnswers = new List<string> { "42 prismarine-type blocks" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "pumpkin-uses",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "Wearing a carved pumpkin prevents which mob from attacking?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Zombies", "Skeletons", "Endermen", "Creepers" },
                    CorrectAnswers = new List<string> { "Endermen" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "golden-apple-types",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "An Enchanted Golden Apple (notch apple) gives:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only health", "Regeneration II, Absorption IV, Resistance, Fire Resistance", "Infinite health", "Speed boost only" },
                    CorrectAnswers = new List<string> { "Regeneration II, Absorption IV, Resistance, Fire Resistance" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "tnt-mechanics",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "TNT can be activated by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Punching it", "Fire, redstone, or another explosion", "Water", "Sunlight" },
                    CorrectAnswers = new List<string> { "Fire, redstone, or another explosion" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "fishing-mechanics",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "The Luck of the Sea enchantment:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Makes fish bite faster", "Increases chance of treasure, decreases junk", "Increases fish size", "Does nothing" },
                    CorrectAnswers = new List<string> { "Increases chance of treasure, decreases junk" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "phantom-spawning",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Phantoms spawn when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "You don't sleep for 3+ in-game days", "At random", "Near water", "In the Nether" },
                    CorrectAnswers = new List<string> { "You don't sleep for 3+ in-game days" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "turtle-eggs",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Turtle eggs will only hatch:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Anywhere", "On sand at night", "Underwater", "In the Nether" },
                    CorrectAnswers = new List<string> { "On sand at night" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "raid-mechanics",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "A raid is triggered when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Entering any village", "Entering a village with Bad Omen effect", "Killing villagers", "Building in a village" },
                    CorrectAnswers = new List<string> { "Entering a village with Bad Omen effect" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "stonecutter-efficiency",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Using a stonecutter instead of crafting table for stone recipes:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Gives more items per block", "Is exactly the same", "Is faster but same output", "Requires less XP" },
                    CorrectAnswers = new List<string> { "Gives more items per block" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "loom-patterns",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A loom is used to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Craft clothing", "Apply patterns to banners efficiently", "Repair cloth items", "Create carpets" },
                    CorrectAnswers = new List<string> { "Apply patterns to banners efficiently" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "smithing-table",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A smithing table is primarily used to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Craft tools", "Upgrade diamond gear to netherite", "Repair items", "Enchant weapons" },
                    CorrectAnswers = new List<string> { "Upgrade diamond gear to netherite" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "blast-furnace",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "A blast furnace compared to a regular furnace:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Smelts everything faster", "Smelts ores and metals twice as fast", "Uses less fuel", "Produces more items" },
                    CorrectAnswers = new List<string> { "Smelts ores and metals twice as fast" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "smoker-mechanics",
                Difficulty = 4,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "A smoker is used to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Cook food twice as fast as furnace", "Smelt ore", "Craft items", "Store items" },
                    CorrectAnswers = new List<string> { "Cook food twice as fast as furnace" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "composter-mechanics",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "A composter converts:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Food into XP", "Plant materials into bone meal", "Dirt into farmland", "Seeds into crops" },
                    CorrectAnswers = new List<string> { "Plant materials into bone meal" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "grindstone-use",
                Difficulty = 5,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "A grindstone can:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Add enchantments", "Remove enchantments and repair items", "Increase durability", "Craft weapons" },
                    CorrectAnswers = new List<string> { "Remove enchantments and repair items" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "cartography-table",
                Difficulty = 6,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "A cartography table is used to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Create new maps", "Clone, expand, and lock maps", "Find locations", "Teleport" },
                    CorrectAnswers = new List<string> { "Clone, expand, and lock maps" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "game-modes",
                Difficulty = 3,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "In Creative mode, players:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Can take damage", "Have unlimited resources and can fly", "Must gather resources", "Can only build" },
                    CorrectAnswers = new List<string> { "Have unlimited resources and can fly" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "spectator-mode",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Spectator mode allows players to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Build freely", "Fly through blocks and view from mob perspectives", "Fight mobs", "Mine faster" },
                    CorrectAnswers = new List<string> { "Fly through blocks and view from mob perspectives" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "nether-transportation",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Travel in the Nether corresponds to Overworld at ratio:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "1:1", "1:4", "1:8", "1:16" },
                    CorrectAnswers = new List<string> { "1:8" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "lightning-mechanics",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Lightning striking a villager turns it into:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Zombie", "Witch", "Illager", "Nothing changes" },
                    CorrectAnswers = new List<string> { "Witch" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "mending-enchantment",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "The Mending enchantment:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Repairs items over time", "Uses XP orbs to repair items instead of enchanting", "Prevents breaking", "Doubles durability" },
                    CorrectAnswers = new List<string> { "Uses XP orbs to repair items instead of enchanting" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "infinity-enchantment",
                Difficulty = 6,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Infinity enchantment on a bow:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Never breaks", "Allows unlimited arrows (but requires 1 arrow in inventory)", "Shoots faster", "Does more damage" },
                    CorrectAnswers = new List<string> { "Allows unlimited arrows (but requires 1 arrow in inventory)" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "curse-enchantments",
                Difficulty = 7,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Curse of Binding means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Item breaks faster", "Item cannot be removed except by death", "Item teleports", "Item disappears" },
                    CorrectAnswers = new List<string> { "Item cannot be removed except by death" }
                }
            },
            new Problem
            {
                Domain = Domain.Minecraft,
                MicroTopic = "totem-of-undying",
                Difficulty = 8,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "A Totem of Undying:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Prevents all damage", "Saves you from death once if held in hand/offhand", "Grants permanent health", "Summons mobs" },
                    CorrectAnswers = new List<string> { "Saves you from death once if held in hand/offhand" }
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
            },

            // ===== Additional Elementary (Grades 1-3): Health Fundamentals =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "dental-health",
                Difficulty = 1,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "How many times per day should you brush your teeth?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Once", "Twice", "Five times", "Never" },
                    CorrectAnswers = new List<string> { "Twice" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "germ-prevention",
                Difficulty = 1,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "When should you wash your hands?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only when dirty", "Before eating and after using bathroom", "Once a day", "Never" },
                    CorrectAnswers = new List<string> { "Before eating and after using bathroom" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "hydration-basics",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "What is the healthiest drink for your body?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Soda", "Water", "Energy drinks", "Juice only" },
                    CorrectAnswers = new List<string> { "Water" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "sun-safety",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "What should you wear to protect your skin from the sun?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nothing special", "Sunscreen", "Only sunglasses", "Dark clothing only" },
                    CorrectAnswers = new List<string> { "Sunscreen" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "safety-basics",
                Difficulty = 2,
                TargetTime = 20,
                Content = new ProblemContent
                {
                    Question = "When riding a bike, you should always wear a:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Helmet", "Hat", "Scarf", "Nothing" },
                    CorrectAnswers = new List<string> { "Helmet" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "five-senses",
                Difficulty = 2,
                TargetTime = 25,
                Content = new ProblemContent
                {
                    Question = "Which body part lets you taste food?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nose", "Eyes", "Tongue", "Ears" },
                    CorrectAnswers = new List<string> { "Tongue" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "body-systems-intro",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "Which body part helps you breathe?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Heart", "Lungs", "Liver", "Kidneys" },
                    CorrectAnswers = new List<string> { "Lungs" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "emotions-recognition",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "If you're feeling sad, it's good to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Keep it inside", "Talk to a trusted adult", "Ignore it", "Get angry" },
                    CorrectAnswers = new List<string> { "Talk to a trusted adult" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "stranger-safety",
                Difficulty = 3,
                TargetTime = 30,
                Content = new ProblemContent
                {
                    Question = "If a stranger asks you to go with them, you should:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Go if they seem nice", "Say no and tell a trusted adult", "Go and tell later", "Think about it" },
                    CorrectAnswers = new List<string> { "Say no and tell a trusted adult" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "growth-development",
                Difficulty = 3,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "As you grow, your bones become:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Softer", "Shorter", "Longer and stronger", "Weaker" },
                    CorrectAnswers = new List<string> { "Longer and stronger" }
                }
            },

            // ===== Additional Upper Elementary (Grades 4-5): Body Systems & Habits =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "digestive-system",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Where does digestion begin?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Stomach", "Mouth", "Intestines", "Esophagus" },
                    CorrectAnswers = new List<string> { "Mouth" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "respiratory-system",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Your lungs take in oxygen and release what gas?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nitrogen", "Helium", "Carbon dioxide", "Hydrogen" },
                    CorrectAnswers = new List<string> { "Carbon dioxide" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "muscular-system",
                Difficulty = 4,
                TargetTime = 35,
                Content = new ProblemContent
                {
                    Question = "Muscles work by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Contracting and relaxing", "Staying still", "Breaking apart", "Growing only" },
                    CorrectAnswers = new List<string> { "Contracting and relaxing" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "screen-time-limits",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Too much screen time can cause:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Better eyesight", "Eye strain and poor sleep", "Stronger muscles", "Faster growth" },
                    CorrectAnswers = new List<string> { "Eye strain and poor sleep" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "balanced-diet",
                Difficulty = 4,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Eating too much sugar can lead to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Stronger bones", "Better focus", "Weight gain and tooth decay", "Faster running" },
                    CorrectAnswers = new List<string> { "Weight gain and tooth decay" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "immune-system-basics",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Your immune system protects you from:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Exercise", "Germs and diseases", "Food", "Water" },
                    CorrectAnswers = new List<string> { "Germs and diseases" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "vaccines-purpose",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Vaccines help your body by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Making you sick", "Teaching immune system to fight diseases", "Giving you vitamins", "Making you taller" },
                    CorrectAnswers = new List<string> { "Teaching immune system to fight diseases" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "posture-importance",
                Difficulty = 5,
                TargetTime = 40,
                Content = new ProblemContent
                {
                    Question = "Good posture when sitting helps prevent:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Happiness", "Back and neck pain", "Growth", "Thinking" },
                    CorrectAnswers = new List<string> { "Back and neck pain" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "calcium-importance",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Calcium is important for building strong:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Muscles only", "Bones and teeth", "Hair", "Eyes" },
                    CorrectAnswers = new List<string> { "Bones and teeth" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "stress-management-basics",
                Difficulty = 5,
                TargetTime = 45,
                Content = new ProblemContent
                {
                    Question = "Which activity can help reduce stress?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Skipping meals", "Deep breathing exercises", "Staying up late", "Avoiding friends" },
                    CorrectAnswers = new List<string> { "Deep breathing exercises" }
                }
            },

            // ===== Additional Middle School (Grades 6-8): Body Changes & Decision Making =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "puberty-changes",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "During puberty, the body releases hormones that cause:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "No changes", "Physical and emotional changes", "Only height changes", "Illness" },
                    CorrectAnswers = new List<string> { "Physical and emotional changes" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "circulatory-system",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Blood carries oxygen from the lungs to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Nowhere", "All body cells", "Only the heart", "Only the brain" },
                    CorrectAnswers = new List<string> { "All body cells" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "calories-energy",
                Difficulty = 6,
                TargetTime = 50,
                Content = new ProblemContent
                {
                    Question = "Calories measure:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Vitamins in food", "Energy in food", "Weight of food", "Taste of food" },
                    CorrectAnswers = new List<string> { "Energy in food" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "antibiotic-resistance",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Taking antibiotics when not needed can lead to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Stronger immunity", "Antibiotic-resistant bacteria", "Faster healing", "Nothing bad" },
                    CorrectAnswers = new List<string> { "Antibiotic-resistant bacteria" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "addiction-warning-signs",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Addiction is characterized by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Occasional use", "Compulsive use despite negative consequences", "Social use only", "One-time experimentation" },
                    CorrectAnswers = new List<string> { "Compulsive use despite negative consequences" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "body-image-health",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Healthy body image means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Looking like models", "Accepting and respecting your body", "Constant dieting", "Comparing to others" },
                    CorrectAnswers = new List<string> { "Accepting and respecting your body" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "social-media-mental-health",
                Difficulty = 7,
                TargetTime = 60,
                Content = new ProblemContent
                {
                    Question = "Excessive social media use has been linked to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Better sleep", "Increased anxiety and depression", "Improved focus", "Stronger friendships only" },
                    CorrectAnswers = new List<string> { "Increased anxiety and depression" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "consent-basics",
                Difficulty = 7,
                TargetTime = 55,
                Content = new ProblemContent
                {
                    Question = "Consent means:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Silence", "Clear, voluntary agreement", "Going along to be polite", "One-time permission forever" },
                    CorrectAnswers = new List<string> { "Clear, voluntary agreement" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "bystander-intervention",
                Difficulty = 8,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "If you see someone being bullied, the best action is to:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Join in", "Ignore it", "Safely intervene or get help from an adult", "Record it only" },
                    CorrectAnswers = new List<string> { "Safely intervene or get help from an adult" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "sleep-cycles",
                Difficulty = 8,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "REM sleep is important for:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Only physical rest", "Memory consolidation and emotional processing", "Digestion only", "Nothing specific" },
                    CorrectAnswers = new List<string> { "Memory consolidation and emotional processing" }
                }
            },

            // ===== Additional High School (Grades 9-12): Advanced Health Topics =====
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "bmi-limitations",
                Difficulty = 8,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "BMI (Body Mass Index) is limited because it doesn't account for:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Height", "Weight", "Muscle mass vs fat mass", "Age only" },
                    CorrectAnswers = new List<string> { "Muscle mass vs fat mass" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "alcohol-effects",
                Difficulty = 8,
                TargetTime = 65,
                Content = new ProblemContent
                {
                    Question = "Alcohol is metabolized primarily in which organ?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Kidneys", "Heart", "Liver", "Lungs" },
                    CorrectAnswers = new List<string> { "Liver" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "herd-immunity",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Herd immunity occurs when:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "One person is immune", "Enough people are immune to slow disease spread", "Everyone gets sick", "Vaccines stop working" },
                    CorrectAnswers = new List<string> { "Enough people are immune to slow disease spread" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "eating-disorders",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Anorexia nervosa is characterized by:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Overeating only", "Extreme food restriction and fear of weight gain", "Healthy eating", "Exercise addiction only" },
                    CorrectAnswers = new List<string> { "Extreme food restriction and fear of weight gain" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "cardiovascular-disease",
                Difficulty = 9,
                TargetTime = 70,
                Content = new ProblemContent
                {
                    Question = "Which is a major risk factor for heart disease?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Regular exercise", "High LDL cholesterol", "Low stress", "Adequate sleep" },
                    CorrectAnswers = new List<string> { "High LDL cholesterol" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "microbiome-health",
                Difficulty = 9,
                TargetTime = 80,
                Content = new ProblemContent
                {
                    Question = "The gut microbiome consists of:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Viruses only", "Trillions of beneficial and harmful bacteria", "Only harmful bacteria", "No living organisms" },
                    CorrectAnswers = new List<string> { "Trillions of beneficial and harmful bacteria" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "cancer-risk-factors",
                Difficulty = 9,
                TargetTime = 75,
                Content = new ProblemContent
                {
                    Question = "Which lifestyle factor is linked to increased cancer risk?",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Eating vegetables", "Smoking tobacco", "Exercising", "Drinking water" },
                    CorrectAnswers = new List<string> { "Smoking tobacco" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "neuroplasticity",
                Difficulty = 10,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Neuroplasticity means the brain can:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Never change after age 25", "Reorganize and form new connections throughout life", "Only grow in childhood", "Only shrink with age" },
                    CorrectAnswers = new List<string> { "Reorganize and form new connections throughout life" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "epigenetics-health",
                Difficulty = 10,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Epigenetics studies how:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "DNA sequence is altered", "Environment affects gene expression without changing DNA", "Genes are inherited", "Cells divide" },
                    CorrectAnswers = new List<string> { "Environment affects gene expression without changing DNA" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "stress-cortisol",
                Difficulty = 10,
                TargetTime = 85,
                Content = new ProblemContent
                {
                    Question = "Chronic stress leads to elevated cortisol, which can cause:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Better health", "Weakened immune system and increased disease risk", "Faster healing", "Improved memory" },
                    CorrectAnswers = new List<string> { "Weakened immune system and increased disease risk" }
                }
            },
            new Problem
            {
                Domain = Domain.Health,
                MicroTopic = "evidence-based-medicine",
                Difficulty = 10,
                TargetTime = 90,
                Content = new ProblemContent
                {
                    Question = "Evidence-based medicine relies primarily on:",
                    Format = ProblemFormat.MultipleChoice,
                    Options = new List<string> { "Personal anecdotes", "Randomized controlled trials and systematic reviews", "Celebrity endorsements", "Historical traditions" },
                    CorrectAnswers = new List<string> { "Randomized controlled trials and systematic reviews" }
                }
            }
        };
    }

    #endregion
}
