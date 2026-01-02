namespace VulcanLearningPit.Models;

public class LeaderboardEntry
{
    public string StudentName { get; set; } = string.Empty;
    public int TotalScore { get; set; }
    public int TotalTokens { get; set; }
    public int Rank { get; set; }
    public GradeLevel Grade { get; set; }
}

public class Leaderboard
{
    public List<LeaderboardEntry> Entries { get; set; } = new();
    public DateTime LastUpdated { get; set; }

    public void UpdateRankings()
    {
        Entries = Entries.OrderByDescending(e => e.TotalScore)
                        .ThenByDescending(e => e.TotalTokens)
                        .ToList();

        for (int i = 0; i < Entries.Count; i++)
        {
            Entries[i].Rank = i + 1;
        }
    }
}
