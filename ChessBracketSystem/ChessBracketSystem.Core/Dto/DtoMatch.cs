using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoMatch
{
    public DateTime StartTime { get; private set; }
    public DtoPlayerCollection Players { get; private set; }
    public string Result { get; private set; }
    public bool Finished { get; private set; }

    public DtoMatch(DateTime startTime, DtoPlayerCollection players, string result, bool finished)
    {
        StartTime = startTime;
        Players = players;
        Result = result;
        Finished = finished;
    }

    public DtoMatch(Match match)
    {
        StartTime = match.StartTime;
        Players = new DtoPlayerCollection(match.Players);
        Result = match.Result;
        Finished = match.Finished;
    }
}
