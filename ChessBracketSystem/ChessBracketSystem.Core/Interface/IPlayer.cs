namespace ChessBracketSystem.Core.Interface;

public interface IPlayer
{
    string Name { get; }
    int Rating { get; }

    bool CanJoin(Tournement tournament);
}
