using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spock.Core.Models;
using Spock.Data;

namespace Spock.Tests.Data;

/// <summary>
/// Tests for ProblemBank domain coverage and content validation
/// </summary>
[TestClass]
public class ProblemBankTests
{
    [TestMethod]
    [Timeout(5000)]
    public void GetAllProblems_ShouldReturnProblems()
    {
        var problems = ProblemBank.GetAllProblems();
        
        Assert.IsNotNull(problems);
        Assert.IsTrue(problems.Count > 0, "Problem bank should contain problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetAllProblems_ShouldIncludeMinecraftDomain()
    {
        var problems = ProblemBank.GetAllProblems();
        var minecraftProblems = problems.Where(p => p.Domain == Domain.Minecraft).ToList();
        
        Assert.IsTrue(minecraftProblems.Count > 0, "Should have Minecraft problems");
        Assert.IsTrue(minecraftProblems.Count >= 10, "Should have at least 10 Minecraft problems across grade levels");
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetAllProblems_ShouldIncludeHealthDomain()
    {
        var problems = ProblemBank.GetAllProblems();
        var healthProblems = problems.Where(p => p.Domain == Domain.Health).ToList();
        
        Assert.IsTrue(healthProblems.Count > 0, "Should have Health problems");
        Assert.IsTrue(healthProblems.Count >= 10, "Should have at least 10 Health problems across grade levels");
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetProblemsByDomain_Minecraft_ShouldReturnOnlyMinecraftProblems()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        
        Assert.IsTrue(problems.Count > 0);
        Assert.IsTrue(problems.All(p => p.Domain == Domain.Minecraft));
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetProblemsByDomain_Health_ShouldReturnOnlyHealthProblems()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        
        Assert.IsTrue(problems.Count > 0);
        Assert.IsTrue(problems.All(p => p.Domain == Domain.Health));
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldCoverElementaryLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        var elementaryProblems = problems.Where(p => p.Difficulty >= 1 && p.Difficulty <= 3).ToList();
        
        Assert.IsTrue(elementaryProblems.Count > 0, "Should have elementary-level Minecraft problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldCoverMiddleSchoolLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        var middleSchoolProblems = problems.Where(p => p.Difficulty >= 4 && p.Difficulty <= 7).ToList();
        
        Assert.IsTrue(middleSchoolProblems.Count > 0, "Should have middle school-level Minecraft problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldCoverHighSchoolLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        var highSchoolProblems = problems.Where(p => p.Difficulty >= 8 && p.Difficulty <= 10).ToList();
        
        Assert.IsTrue(highSchoolProblems.Count > 0, "Should have high school-level Minecraft problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldCoverElementaryLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        var elementaryProblems = problems.Where(p => p.Difficulty >= 1 && p.Difficulty <= 3).ToList();
        
        Assert.IsTrue(elementaryProblems.Count > 0, "Should have elementary-level Health problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldCoverMiddleSchoolLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        var middleSchoolProblems = problems.Where(p => p.Difficulty >= 4 && p.Difficulty <= 7).ToList();
        
        Assert.IsTrue(middleSchoolProblems.Count > 0, "Should have middle school-level Health problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldCoverHighSchoolLevel()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        var highSchoolProblems = problems.Where(p => p.Difficulty >= 8 && p.Difficulty <= 10).ToList();
        
        Assert.IsTrue(highSchoolProblems.Count > 0, "Should have high school-level Health problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldHaveValidContent()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        
        foreach (var problem in problems)
        {
            Assert.IsNotNull(problem.Content, $"Problem should have content");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Question), "Question should not be empty");
            Assert.IsNotNull(problem.Content.CorrectAnswers, "Should have correct answers");
            Assert.IsTrue(problem.Content.CorrectAnswers.Count > 0, "Should have at least one correct answer");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.MicroTopic), "Should have micro-topic");
        }
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldHaveValidContent()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        
        foreach (var problem in problems)
        {
            Assert.IsNotNull(problem.Content, $"Problem should have content");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Question), "Question should not be empty");
            Assert.IsNotNull(problem.Content.CorrectAnswers, "Should have correct answers");
            Assert.IsTrue(problem.Content.CorrectAnswers.Count > 0, "Should have at least one correct answer");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.MicroTopic), "Should have micro-topic");
        }
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldCoverBasicMechanics()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        var basicMechanics = problems.Where(p => 
            p.MicroTopic.Contains("block") || 
            p.MicroTopic.Contains("crafting") || 
            p.MicroTopic.Contains("mob")).ToList();
        
        Assert.IsTrue(basicMechanics.Count > 0, "Should have problems covering basic Minecraft mechanics");
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldCoverRedstoneLogic()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        var redstoneProblems = problems.Where(p => p.MicroTopic.Contains("redstone")).ToList();
        
        Assert.IsTrue(redstoneProblems.Count > 0, "Should have redstone logic problems for cross-domain integration");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldCoverNutrition()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        var nutritionProblems = problems.Where(p => p.MicroTopic.Contains("nutrition")).ToList();
        
        Assert.IsTrue(nutritionProblems.Count > 0, "Should have nutrition problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldCoverMentalHealth()
    {
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        var mentalHealthProblems = problems.Where(p => p.MicroTopic.Contains("mental")).ToList();
        
        Assert.IsTrue(mentalHealthProblems.Count > 0, "Should have mental health awareness problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void AllDomains_ShouldBeRepresented()
    {
        var problems = ProblemBank.GetAllProblems();
        var domains = problems.Select(p => p.Domain).Distinct().ToList();
        
        Assert.IsTrue(domains.Contains(Domain.Math), "Should have Math problems");
        Assert.IsTrue(domains.Contains(Domain.Logic), "Should have Logic problems");
        Assert.IsTrue(domains.Contains(Domain.Reading), "Should have Reading problems");
        Assert.IsTrue(domains.Contains(Domain.Science), "Should have Science problems");
        Assert.IsTrue(domains.Contains(Domain.Minecraft), "Should have Minecraft problems");
        Assert.IsTrue(domains.Contains(Domain.Health), "Should have Health problems");
        Assert.IsTrue(domains.Contains(Domain.Bitcoin), "Should have Bitcoin problems");
        Assert.IsTrue(domains.Contains(Domain.WashingtonHistory), "Should have Washington History problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void GetProblemsByDifficulty_ShouldFilterCorrectly()
    {
        var easyProblems = ProblemBank.GetProblemsByDifficulty(1, 3);
        var hardProblems = ProblemBank.GetProblemsByDifficulty(8, 10);
        
        Assert.IsTrue(easyProblems.All(p => p.Difficulty >= 1 && p.Difficulty <= 3));
        Assert.IsTrue(hardProblems.All(p => p.Difficulty >= 8 && p.Difficulty <= 10));
        Assert.IsTrue(easyProblems.Count > 0, "Should have easy problems");
        Assert.IsTrue(hardProblems.Count > 0, "Should have hard problems");
    }

    [TestMethod]
    [Timeout(5000)]
    public void MinecraftProblems_ShouldSupportCrossDomainIntegration()
    {
        // Per plan: Minecraft can disguise math, logic, reading, and science
        var problems = ProblemBank.GetProblemsByDomain(Domain.Minecraft);
        
        // Check for problems that could integrate with other domains
        var mathIntegration = problems.Any(p => 
            p.Content.Question.Contains("How many") || 
            p.Content.Question.Contains("calculate") ||
            p.MicroTopic.Contains("crafting")); // crafting often involves counting
        
        var logicIntegration = problems.Any(p => 
            p.MicroTopic.Contains("redstone") || 
            p.MicroTopic.Contains("logic"));
        
        Assert.IsTrue(mathIntegration, "Should have Minecraft problems that integrate math concepts");
        Assert.IsTrue(logicIntegration, "Should have Minecraft problems that integrate logic concepts");
    }

    [TestMethod]
    [Timeout(5000)]
    public void HealthProblems_ShouldBeEvidenceBased()
    {
        // Per plan: All health content backed by CDC, WHO, and pediatric guidelines
        var problems = ProblemBank.GetProblemsByDomain(Domain.Health);
        
        // Verify content includes evidence-based topics
        var evidenceBasedTopics = problems.Where(p => 
            p.MicroTopic.Contains("nutrition") ||
            p.MicroTopic.Contains("hygiene") ||
            p.MicroTopic.Contains("mental-health") ||
            p.MicroTopic.Contains("exercise") ||
            p.MicroTopic.Contains("sleep")).ToList();
        
        Assert.IsTrue(evidenceBasedTopics.Count > 0, "Should have evidence-based health topics");
    }

    [TestMethod]
    [Timeout(5000)]
    public void AllMathProblems_ShouldHaveComprehensiveGuidance()
    {
        var mathProblems = ProblemBank.GetProblemsByDomain(Domain.Math);

        Assert.IsTrue(mathProblems.Count > 0, "Should have math problems");

        foreach (var problem in mathProblems)
        {
            // Verify all guidance fields are populated
            Assert.IsNotNull(problem.Content.Guidance, $"Problem '{problem.Content.Question}' should have Guidance");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Guidance.HintMinimal),
                $"Problem '{problem.Content.Question}' should have HintMinimal");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Guidance.WorkedExample),
                $"Problem '{problem.Content.Question}' should have WorkedExample");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Guidance.KeyPrinciple),
                $"Problem '{problem.Content.Question}' should have KeyPrinciple");
            Assert.IsFalse(string.IsNullOrWhiteSpace(problem.Content.Guidance.CommonMistake),
                $"Problem '{problem.Content.Question}' should have CommonMistake");

            // Verify StepsDetailed has actual steps
            Assert.IsNotNull(problem.Content.Guidance.StepsDetailed,
                $"Problem '{problem.Content.Question}' should have StepsDetailed list");
            Assert.IsTrue(problem.Content.Guidance.StepsDetailed.Count > 0,
                $"Problem '{problem.Content.Question}' should have at least one detailed step");
        }
    }

    [TestMethod]
    [Timeout(5000)]
    public void MathProblems_MultiplicationTwoDigit_ShouldHaveStepByStepWork()
    {
        var mathProblems = ProblemBank.GetProblemsByDomain(Domain.Math);
        var multiplicationProblems = mathProblems
            .Where(p => p.MicroTopic == "multiplication-two-digit" || p.MicroTopic == "multiplication-three-digit")
            .ToList();

        Assert.IsTrue(multiplicationProblems.Count >= 16, "Should have at least 16 two/three-digit multiplication problems");

        foreach (var problem in multiplicationProblems)
        {
            // Verify step-by-step guidance shows the work
            Assert.IsTrue(problem.Content.Guidance.StepsDetailed.Count >= 5,
                $"Multiplication problem '{problem.Content.Question}' should have at least 5 detailed steps");

            // Verify worked example shows visual representation
            Assert.IsTrue(problem.Content.Guidance.WorkedExample.Length > 20,
                $"Multiplication problem '{problem.Content.Question}' should have a detailed worked example");

            // Verify it has a meaningful common mistake section
            var commonMistake = problem.Content.Guidance.CommonMistake;
            Assert.IsTrue(commonMistake.Length > 20,
                $"Multiplication problem '{problem.Content.Question}' should have a detailed CommonMistake explanation");
        }
    }
}
