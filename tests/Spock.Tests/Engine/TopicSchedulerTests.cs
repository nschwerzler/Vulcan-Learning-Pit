using FluentAssertions;
using Spock.Core.Models;
using Spock.Engine;

namespace Spock.Tests.Engine;

[TestClass]
public class TopicSchedulerTests
{
    [TestMethod]
    [Timeout(5000)]
    public async Task ShouldSwitchDomainAsync_ShortTime_ReturnsFalse()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - 5 minutes in domain
        var result = await scheduler.ShouldSwitchDomainAsync(
            Domain.Math,
            problemsSolved: 3,
            timeInDomain: 300,
            cts.Token);

        // Assert
        result.Should().BeFalse("under 10 minutes should not trigger switch");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ShouldSwitchDomainAsync_LongTime_ReturnsTrue()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - 15 minutes in domain (900s = 100% switch probability)
        var result = await scheduler.ShouldSwitchDomainAsync(
            Domain.Math,
            problemsSolved: 3,
            timeInDomain: 900,
            cts.Token);

        // Assert
        result.Should().BeTrue("15 minutes should trigger switch for ADD-friendly engagement");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ShouldSwitchDomainAsync_ManyProblems_EventuallyReturnsTrue()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - 12 problems = 100% switch probability
        var result = await scheduler.ShouldSwitchDomainAsync(
            Domain.Math,
            problemsSolved: 12,
            timeInDomain: 400, // Under 10 minutes
            cts.Token);

        // Assert
        result.Should().BeTrue("12 problems should trigger switch to prevent fatigue");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ShouldSwitchDomainAsync_ModerateUse_MayOrMayNotSwitch()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - 10 problems, 12 minutes (both in probability range)
        // Run multiple times to verify randomness works
        var switches = 0;
        for (int i = 0; i < 100; i++)
        {
            var result = await scheduler.ShouldSwitchDomainAsync(
                Domain.Math,
                problemsSolved: 10,
                timeInDomain: 720, // 12 minutes = 40% probability
                cts.Token);
            if (result) switches++;
        }

        // Assert - should switch some but not all times (probabilistic)
        switches.Should().BeGreaterThan(10, "should have some switches with 40% probability");
        switches.Should().BeLessThan(90, "should not switch every time");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SelectNextDomainAsync_NoAvailableDomains_ReturnsNull()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        var profile = new StudentProfile 
        { 
            Level = new CurrentLevel { UnlockedDomains = new List<Domain> { Domain.Math } }
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - only one domain unlocked, currently using it
        var result = await scheduler.SelectNextDomainAsync(
            Domain.Math,
            profile,
            new List<Domain>(),
            cts.Token);

        // Assert
        result.Should().BeNull("no other domains available");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SelectNextDomainAsync_WithWeaknesses_PrioritizesWeakDomains()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        var profile = new StudentProfile
        {
            Level = new CurrentLevel
            {
                UnlockedDomains = new List<Domain> { Domain.Math, Domain.Science, Domain.Reading }
            }
        };
        var weaknessDomains = new List<Domain> { Domain.Science };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act - run multiple times to check weakness prioritization (40% chance)
        var scienceCount = 0;
        for (int i = 0; i < 100; i++)
        {
            var result = await scheduler.SelectNextDomainAsync(
                Domain.Math,
                profile,
                weaknessDomains,
                cts.Token);
            if (result == Domain.Science) scienceCount++;
        }

        // Assert - Science should be selected more often due to weakness priority
        scienceCount.Should().BeGreaterThan(25, "weakness domains should be prioritized (40% base chance)");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SelectNextDomainAsync_UsesInterleaving_SelectsLeastRecent()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        var profile = new StudentProfile
        {
            Level = new CurrentLevel
            {
                UnlockedDomains = new List<Domain> { Domain.Math, Domain.Science, Domain.Reading }
            }
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Record usage to establish recency
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        await Task.Delay(50); // Small delay to ensure different timestamps
        await scheduler.RecordDomainUsedAsync(Domain.Science, cts.Token);

        // Act - switch from Reading (never used), should pick Math or Science based on recency
        var result = await scheduler.SelectNextDomainAsync(
            Domain.Reading,
            profile,
            new List<Domain>(), // No weaknesses
            cts.Token);

        // Assert - should select Math (oldest used) or Science, not Reading
        result.Should().NotBe(Domain.Reading, "should not return current domain");
        result.Should().BeOneOf(Domain.Math, Domain.Science);
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task RecordDomainUsedAsync_UpdatesLastUsedAndCount()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        var usage = await scheduler.GetDomainUsageAsync(cts.Token);

        // Assert
        usage[Domain.Math].Should().Be(2, "domain was used twice");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetDomainUsageAsync_ReturnsCorrectCounts()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        await scheduler.RecordDomainUsedAsync(Domain.Science, cts.Token);
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        var usage = await scheduler.GetDomainUsageAsync(cts.Token);

        // Assert
        usage[Domain.Math].Should().Be(2);
        usage[Domain.Science].Should().Be(1);
        usage.Should().NotContainKey(Domain.Reading, "Reading was never used");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ResetSessionCountersAsync_ClearsUsageCounts()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        await scheduler.RecordDomainUsedAsync(Domain.Science, cts.Token);

        // Act
        await scheduler.ResetSessionCountersAsync(cts.Token);
        var usage = await scheduler.GetDomainUsageAsync(cts.Token);

        // Assert
        usage.Should().BeEmpty("session counters should be cleared");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ResetSessionCountersAsync_PreservesLastUsedForInterleaving()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        var timeSinceBefore = await scheduler.GetTimeSinceLastUsedAsync(Domain.Math, cts.Token);

        // Act - Reset counters
        await scheduler.ResetSessionCountersAsync(cts.Token);
        var timeSinceAfter = await scheduler.GetTimeSinceLastUsedAsync(Domain.Math, cts.Token);

        // Assert
        timeSinceBefore.Should().NotBeNull("domain was used");
        timeSinceAfter.Should().NotBeNull("last-used timestamp should be preserved after reset");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetTimeSinceLastUsedAsync_NeverUsed_ReturnsNull()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Act
        var result = await scheduler.GetTimeSinceLastUsedAsync(Domain.Math, cts.Token);

        // Assert
        result.Should().BeNull("domain was never used");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task GetTimeSinceLastUsedAsync_RecentlyUsed_ReturnsSmallTimeSpan()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);

        // Act
        var result = await scheduler.GetTimeSinceLastUsedAsync(Domain.Math, cts.Token);

        // Assert
        result.Should().NotBeNull();
        result!.Value.TotalSeconds.Should().BeLessThan(1, "just used within last second");
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task ShouldSwitchDomainAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
        {
            await scheduler.ShouldSwitchDomainAsync(Domain.Math, 5, 300, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task SelectNextDomainAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        var profile = new StudentProfile
        {
            Level = new CurrentLevel { UnlockedDomains = new List<Domain> { Domain.Math, Domain.Science } }
        };
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
        {
            await scheduler.SelectNextDomainAsync(Domain.Math, profile, new List<Domain>(), cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task RecordDomainUsedAsync_WithCancellation_ThrowsOperationCanceledException()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        // Act & Assert
        await Assert.ThrowsExceptionAsync<OperationCanceledException>(async () =>
        {
            await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        });
    }

    [TestMethod]
    [Timeout(5000)]
    public async Task MultipleDomainsInterleaving_SelectsBasedOnRecency()
    {
        // Arrange
        var scheduler = new TopicScheduler();
        var profile = new StudentProfile
        {
            Level = new CurrentLevel
            {
                UnlockedDomains = new List<Domain> 
                { 
                    Domain.Math, Domain.Science, Domain.Reading, Domain.WinPants 
                }
            }
        };
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

        // Record usage with delays to establish clear recency order
        await scheduler.RecordDomainUsedAsync(Domain.Math, cts.Token);
        await Task.Delay(50);
        await scheduler.RecordDomainUsedAsync(Domain.Science, cts.Token);
        await Task.Delay(50);
        await scheduler.RecordDomainUsedAsync(Domain.Reading, cts.Token);

        // Act - switch from WinPants (never used), with no weaknesses
        // Should pick Math (oldest) since WinPants is never-used (DateTime.MinValue)
        var result = await scheduler.SelectNextDomainAsync(
            Domain.WinPants,
            profile,
            new List<Domain>(),
            cts.Token);

        // Assert - should select Math (oldest used domain)
        result.Should().Be(Domain.Math, "Math was used longest ago among used domains");
    }
}
