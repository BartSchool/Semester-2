namespace ChessBracketSystem.Core.Interface;

public interface IMatch
{
    public int ID { get; }
    public DateTime StartTime { get; }
    public IPlayerCollection Players { get; }
    public string Result { get; }
    public bool Finished { get; }
}
