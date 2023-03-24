using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoTournement
{
    public string Name { get; private set; }
    public int MaxPlayers { get; private set; }
    public DtoPlayerCollection Players { get; private set; }
    public DtoPlayerCollection InvitedPlayers { get; private set; }
    public DtoBracket Bracket { get; private set; }
    public DateTime StartTime { get; private set; }
    public bool IsOpen { get; private set; }

    public DtoTournement(string name, int maxPlayers, DtoPlayerCollection players, DtoPlayerCollection invitedPlayers, DtoBracket bracket, DateTime startTime, bool isOpen)
    {
        Name = name;
        MaxPlayers = maxPlayers;
        Players = players;
        InvitedPlayers = invitedPlayers;
        Bracket = bracket;
        StartTime = startTime;
        IsOpen = isOpen;
    }

    public DtoTournement(Tournement tournement)
    {
        Name = tournement.Name;
        MaxPlayers = tournement.MaxPlayers;
        Players = new(tournement.Players);
        InvitedPlayers = new(tournement.InvitedPlayers);
        Bracket = new(tournement.Bracket);
        StartTime = tournement.StartTime;
        IsOpen = tournement.IsOpen;
    }
}
