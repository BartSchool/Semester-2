namespace ChessBracketSystem.Core.Interface;

public interface ITournement
{
    int ID { get; }
    string Name { get; }
    int MaxPlayers { get;  }
    IPlayerCollection Players { get; }
    IPlayerCollection InvitedPlayers { get; }
    Bracket Bracket { get; }
    DateTime StartTime { get;  }
    bool IsOpen { get; }

    void Edit(string name, int maxPlayers);
    int GetAvailableSpaces();
}
