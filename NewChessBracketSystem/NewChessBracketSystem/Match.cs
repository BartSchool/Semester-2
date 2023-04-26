using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class Match
{
    public Player Player1 { get; private set; }
    public Player Player2 { get; private set; }
    public MatchResult Result { get; private set; }
    public DateTime StartTime { get; private set; }

    public Match(DateTime startTime, Player p1, Player p2)
    {
        if (startTime < DateTime.UtcNow)
            throw new Exception("Can't make a match in the past");

        Player1 = p1;
        Player2 = p2;
        Result = MatchResult.NotPlayed;
        StartTime = startTime;
    }

    public Match(DateTime startTime, MatchResult result, Player p1, Player p2) : this(startTime, p1, p2)
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
        List<Player> list = new List<Player>();
        list.Add(Player1);
        list.Add(Player2);
        return list;
    }
}
