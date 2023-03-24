using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class Tournement : ITournement
{
    public string Name { get; private set; }
    public int MaxPlayers { get; private set; }
    public IPlayerCollection Players { get; private set; }
    public IPlayerCollection InvitedPlayers { get; private set; }
    public IBracket Bracket { get; private set; }
    public DateTime StartTime { get; private set; }
    public bool IsOpen { get; private set; }

    public Tournement(string name, int maxPlayers, IPlayerCollection players, IPlayercollection invitedPlayers, IBracket bracket, DateTime startTime, bool isOpen)
    {
        Name = name;
        MaxPlayers = maxPlayers;
        Players = players;
        InvitedPlayers = invitedPlayers;
        Bracket = bracket;
        StartTime = startTime;
        IsOpen = isOpen;
    }

    public Tournement(DtoTournement dto)
    {
        Name=dto.Name;
        MaxPlayers = dto.MaxPlayers;
        Players = dto.Players;
        InvitedPlayers = dto.InvitedPlayers;
        Bracket=dto.Bracket;
        StartTime = dto.StartTime;
        IsOpen = dto.IsOpen;
    }

    public void Edit(string name, int maxPlayers)
    {
        Name = name;
        MaxPlayers = maxPlayers;
    }
}