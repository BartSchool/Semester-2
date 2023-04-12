namespace ChessBracketSystem.Core.Interface;

public interface IPlayer
{
    public int ID { get; }
    public string Name { get; }
    public int Rating { get; }
}
