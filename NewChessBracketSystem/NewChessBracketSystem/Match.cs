namespace NewCBS.Core;

public class Match
{
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public MatchResult Result { get; private set; }
    public DateTime StartTime { get; private set; }

    public Match(Player player1, Player player2, DateTime startTime)
    {
        if (startTime < DateTime.UtcNow)
            throw new Exception("Can't make a match in the past");

        Player1 = player1;
        Player2 = player2;
        Result = MatchResult.NotPlayed;
        StartTime = startTime;
    }

    public Match(Player player1, Player player2, DateTime startTime, MatchResult result) : this(player1, player2, startTime)
    {
        Result = result;
    }

    public void EditStartTime(DateTime newStartTime)
    {
        if (newStartTime < DateTime.UtcNow)
            throw new Exception("Can't change the starttime to the past");
        StartTime = newStartTime;
    }

    public void SetPlayers(Player player1, Player player2)
    {
        Player1 = player1;
        Player2 = player2;
    }

    public void UpdateResult(MatchResult newResult)
    {
        Result = newResult;
    }

    public List<Player> GetPlayers()
    {
        return new List<Player>() { Player1, Player2};
    }
}
