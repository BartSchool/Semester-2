namespace ChessBracketSystem.Core.Interface;

public interface IMatch
{
    DateTime StartTime { get; }
    IPlayerCollection Players { get; }
    string Result { get; }
    bool Finnished { get; }

    void Edit(DateTime startTime);
    void UpdateResult(string Result);
}
