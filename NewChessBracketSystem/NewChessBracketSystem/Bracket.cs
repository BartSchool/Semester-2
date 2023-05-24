using NewCBS.Core.Interfaces;
using System.Net;

namespace NewCBS.Core;

public class Bracket
{
    private IBracketDal _bracket;
    public BracketType Type { get; private set; }
    public IReadOnlyList<Match>? Matches { get; set; }
    private static Random rnd = new();

    public Bracket(IBracketDal dal)
    {
        _bracket = dal;

        string type = _bracket.GetBracketType();
        if (type == "roundRobin")
            Type = BracketType.roundRobin;
        else if (type == "elimination")
            Type = BracketType.elemination;
        UpdateMatches();
    }

    public void CreateMatches(List<Player> Players)
    {
        if (Players.Count % 2 != 0)
            throw new Exception("Can't create matches with an uneven amount of players");

        switch (Type)
        {
            case BracketType.roundRobin:
                CreateRoundRobin(Players);
                break;
            case BracketType.elemination:
                break;
            default:
                break;
        }
    }

    private void CreateRoundRobin(List<Player> Players)
    {
        List<Match> matches = new List<Match>();

        for (int i = 0; i < Players.Count; i++)
        {
            Player p1 = Players[i];
            for (int j = i+1; j < Players.Count; j++)
            {
                Player p2 = Players[j];
                Match match = new Match(DateTime.Now.AddMinutes(j*30), p1, p2);
                matches.Add(match);
            }
        }

        foreach (Match match in matches)
            _bracket.AddMatch(match.Player1.Name, match.Player2.Name, match.StartTime, match.Result.ToString());
    }

    private void CreateElimination(List<Player> Players)
    {
        throw new Exception("not Implemented");
    }

    public void EditType(BracketType newType)
    {
        Type = newType;
    }

    public void UpdateMatches()
    {
        Matches = _bracket.GetMatches();
    }

    public List<Match> FilterMatches(List<Match> matches, Player player)
    {
        List<Match> result = new();
        foreach (Match match in matches)
            if (match.GetPlayers().Contains(player))
                result.Add(match);
        return result;
    }

    public List<Match> FilterMatches(List<Match> matches, DateOnly Date)
    {
        List<Match> result = new();
        foreach (Match match in matches)
            if (match.StartTime.DayOfYear == Date.DayOfYear)
                result.Add(match);
        return result;
    }

    private List<Player> RandomiseList(List<Player> players)
    {
        List<Player> result = new();
        while (players.Count > 0)
        {
            int i = rnd.Next(0, players.Count);
            result.Add(players[i]);
            players.RemoveAt(i);
        }
        return result;
    }
}
