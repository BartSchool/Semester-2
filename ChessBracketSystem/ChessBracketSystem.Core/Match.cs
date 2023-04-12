using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class Match : IMatch
{
    public int ID { get; private set; }
    public DateTime StartTime { get; private set; }
    public IPlayerCollection Players { get; private set; }
    public string Result { get; private set; }
    public bool Finished { get; private set; }

    public Match(int id, DateTime startTime, string result, bool finished, IPlayerCollection players)
    {
        ID = id;
        StartTime = startTime;
        Result = result;
        Finished = finished;
        Players = players;
    }

    public Match(DtoMatch dto)
    {
        ID = dto.ID;
        StartTime = dto.StartTime;
        Players = new PlayerCollection(dto.Players);
        Result = dto.Result;
        Finished = dto.Finished;
    }

    public void Edit(DateTime startTime)
    {
        StartTime = startTime;
    }

    public void UpdateResult(string result)
    {
        Result = result;
    }
}
