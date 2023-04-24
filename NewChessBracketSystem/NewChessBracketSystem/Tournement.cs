using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class Tournement
{
    public string Name { get; private set; }
    public int MaxPlayers { get; private set; }
    public DateTime StartTime { get; private set; }
    public PlayerCollection Players { get; private set; }
    public PlayerCollection InvitedPlayers { get; private set; }

    public Tournement(string name, int maxPlayers, DateTime startTime, IPlayerDal playerData)
    {
        Name = name;
        MaxPlayers = maxPlayers;
        StartTime = startTime;
        Players = new PlayerCollection(playerData);
        InvitedPlayers = new PlayerCollection(playerData);
    }

    public void EditName(string name)
    {
        Name = name;
    }

    public void EditMaxPlayers(int maxPlayers)
    {
        MaxPlayers = maxPlayers;
    }

    public void EditStartTime(DateTime startTime)
    {
        StartTime = startTime;
    }
}
