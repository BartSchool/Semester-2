using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class Tournement
{
    private IPlayerCollection _PlayerDB { get; set; } 
    public string Name { get; private set; }
    public int MaxPlayers { get; private set; }
    public DateTime StartTime { get; private set; }
    public IReadOnlyList<Player> Players { get; private set; }
    public IReadOnlyList<Player> InvitedPlayers { get; private set; }

    public Tournement(string name, int maxPlayers, DateTime startTime, IPlayerCollection PlayerDB)
    {
        _PlayerDB = PlayerDB;
        Name = name;
        MaxPlayers = maxPlayers;
        StartTime = startTime;
        Players = new List<Player>();
        InvitedPlayers = new List<Player>();
    }

    public void AddPlayer(string name)
    {
        List<Player> temp =new(Players);
        Player? playerfromDB = _PlayerDB.GetPlayer(name);
        if (playerfromDB == null)
            throw new Exception("Player does not exist");
        temp.Add(playerfromDB);
        Players = temp;
    }

    public void RemovePlayer(string name)
    {
        List<Player> temp = new(Players);

        Player? removedPlayer = _PlayerDB.GetPlayer(name);
        if (removedPlayer == null)
            throw new Exception("Cant remove a player that doesnt exist");
        _PlayerDB.RemovePlayer(name);
        temp.Remove(removedPlayer);

        Players = temp;
    }

    public void AddInvitedPlayer(string name)
    {
        List<Player> temp = new(Players);
        Player? playerfromDB = _PlayerDB.GetPlayer(name);
        if (playerfromDB == null)
            throw new Exception("Player does not exist");
        temp.Add(playerfromDB);
        InvitedPlayers = temp;
    }

    public void RemoveInvitedPlayer(string name)
    {
        List<Player> temp = new(Players);

        Player? removedPlayer = _PlayerDB.GetPlayer(name);
        if (removedPlayer == null)
            throw new Exception("Cant remove a player that doesnt exist");
        _PlayerDB.RemovePlayer(name);
        temp.Remove(removedPlayer);

        InvitedPlayers = temp;
    }
}
