namespace ChessBracketSystem.Core.Interface;

public interface ITournement
{
    string Name { get; }
    int MaxPlayers { get; }
    IPlayerCollection Players { get; }
    IPlayerCollection InvitedPlayers { get; }
    IBracket Bracket { get; }
    DateTime StartTime { get; }
    bool IsOpen { get; }

    void Edit(string name, int maxPlayers);
}
