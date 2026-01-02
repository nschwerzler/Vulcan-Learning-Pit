using System.Collections.ObjectModel;
using VulcanLearningPit.Models;

namespace VulcanLearningPit.ViewModels;

public class LeaderboardViewModel : ViewModelBase
{
    private readonly Leaderboard _leaderboard;

    public LeaderboardViewModel()
    {
        _leaderboard = new Leaderboard();
        LoadSampleData();
        UpdateEntries();
    }

    public ObservableCollection<LeaderboardEntry> Entries { get; } = new();

    private void LoadSampleData()
    {
        // Add some sample leaderboard entries
        _leaderboard.Entries.Add(new LeaderboardEntry
        {
            StudentName = "James T. Kirk",
            TotalScore = 8500,
            TotalTokens = 425,
            Grade = GradeLevel.Grade7
        });

        _leaderboard.Entries.Add(new LeaderboardEntry
        {
            StudentName = "Spock",
            TotalScore = 9950,
            TotalTokens = 498,
            Grade = GradeLevel.Grade8
        });

        _leaderboard.Entries.Add(new LeaderboardEntry
        {
            StudentName = "Nyota Uhura",
            TotalScore = 8750,
            TotalTokens = 438,
            Grade = GradeLevel.Grade7
        });

        _leaderboard.Entries.Add(new LeaderboardEntry
        {
            StudentName = "Pavel Chekov",
            TotalScore = 7200,
            TotalTokens = 360,
            Grade = GradeLevel.Grade6
        });

        _leaderboard.Entries.Add(new LeaderboardEntry
        {
            StudentName = "Hikaru Sulu",
            TotalScore = 7800,
            TotalTokens = 390,
            Grade = GradeLevel.Grade6
        });
    }

    public void AddEntry(LeaderboardEntry entry)
    {
        _leaderboard.Entries.Add(entry);
        UpdateEntries();
    }

    private void UpdateEntries()
    {
        _leaderboard.UpdateRankings();
        Entries.Clear();
        foreach (var entry in _leaderboard.Entries)
        {
            Entries.Add(entry);
        }
    }
}
