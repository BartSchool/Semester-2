using System.Net;

namespace NewCBS.Core;

public class Bracket
{
    public BracketType Type { get; private set; }
    private IReadOnlyList<Match>? Matches { get; set; }

    public Bracket(BracketType type)
    {
        Type = type;
    }

    public Bracket(BracketType type, List<Match> matches) : this(type)
    {
        Matches = matches;
    }

    public void CreateMatches(List<Player> players)
    {
        if (players.Count % 2 != 0)
            throw new Exception("Can't create matches with an uneven amount of players");

        throw new NotImplementedException();
    }

    public void EditType(BracketType newType)
    {
        Type = newType;
    }

    public List<Match> GetMatches()
    {
        if (Matches == null)
            return new List<Match>();
        return new List<Match>(Matches);
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
}
