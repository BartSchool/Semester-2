using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class Match
{
    public PlayerCollection Players { get; private set; }
    public MatchResult Result { get; private set; }
    public DateTime StartTime { get; private set; }

    public Match(DateTime startTime, IPlayerDal playerData)
    {
        if (startTime < DateTime.UtcNow)
            throw new Exception("Can't make a match in the past");

        Players = new PlayerCollection(playerData, 2);
        Result = MatchResult.NotPlayed;
        StartTime = startTime;
    }

    public Match(DateTime startTime, MatchResult result, IPlayerDal playerData) : this(startTime, playerData)
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
        Players.AddPlayer(player1.Name, player1.Ranking);
        Players.AddPlayer(player2.Name, player1.Ranking);
    }

    public void UpdateResult(MatchResult newResult)
    {
        Result = newResult;
    }

    public List<Player> GetPlayers()
    {
        return new List<Player>(Players.List);
    }
}
