using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class Tournement
{
    private IToernementDal _tournement;
    private IBracketDal _bracket;
    public string Name { get; private set; }
    public int MaxPlayers { get; private set; }
    public DateTime StartTime { get; private set; }
    public bool isOpen { get; private set; }
    public IReadOnlyList<Player> Players { get; private set; }
    public IReadOnlyList<Player> InvitedPlayers { get; private set; }
    public Bracket Bracket { get; private set; }

    public Tournement(IToernementDal tournement, IBracketDal bracket)
    {
        _tournement = tournement;
        _bracket = bracket;

        Bracket = new(_bracket);
        Name = _tournement.GetName();
        MaxPlayers = _tournement.GetMaxPlayers();
        StartTime = _tournement.GetStartTime();
        isOpen = _tournement.IsTournementOpen();
        Players = GetPlayersFromDal();
        InvitedPlayers = GetInvitedPlayersFromDal();
    }

    public bool IsStarted()
    {
        if (DateTime.Now > StartTime)
            return true;
        return false;
    }

    public void RemovePlayer(string name)
    {
        _tournement.RemovePlayer(name);
        Players = GetPlayersFromDal();
    }

    public void AddPlayer(string name)
    {
        if (CanPlayerJoin(name))
            _tournement.AddPlayer(name);
        Players = GetPlayersFromDal();
    }

    public void UnInvitePlayer(string name)
    {
        _tournement.UninvitePlayer(name);
        InvitedPlayers = GetInvitedPlayersFromDal();
    }

    public void InvitePlayer(string name)
    {
        if (CanInvitePlayer(name))
            _tournement.InvitePlayer(name);
        InvitedPlayers = GetInvitedPlayersFromDal();
    }

    public void EditName(string name)
    {
        Name = name;
        _tournement.EditName(name);
    }

    public void EditMaxPlayers(int maxPlayers)
    {
        MaxPlayers = maxPlayers;
        _tournement.EditMaxPlayers(maxPlayers);
    }

    public void EditStartTime(DateTime startTime)
    {
        StartTime = startTime;
        _tournement.EditStartTime(startTime);
    }

    private bool CanPlayerJoin(string name)
    {
        if (!DoesPlayerExist(name))
            throw new Exception("Player does not exist");
        if (!isOpen && !IsPlayerInvited(name))
            throw new Exception("Player is not invited");
        if (IsTournementFull())
            throw new Exception("The tournement is full");
        if (IsPlayerInTournement(name))
            throw new Exception("Player is allready in tournement");
        return true;
    }

    private bool CanInvitePlayer(string name)
    {
        if (!DoesPlayerExist(name))
            throw new Exception("Player does not exist");
        if (IsPlayerInvited(name))
            throw new Exception("Player is allready invited");
        return true;
    }

    private bool IsPlayerInvited(string name)
    {
        foreach (Player player in InvitedPlayers)
            if (player.Name == name)
                return true;
        return false;
    }

    private bool IsTournementFull()
    {
        if (Players.Count >= MaxPlayers)
            return true;
        return false;
    }

    private List<Player> GetPlayersFromDal()
    {
        List<Player> players = new List<Player>();
        List<string> names = _tournement.GetPlayers();
        List<int> ratings = _tournement.GetPlayerRatings(names);

        for (int i = 0; i < names.Count; i++)
            players.Add(new Player(names[i], ratings[i]));

        return players;
    }

    private List<Player> GetInvitedPlayersFromDal()
    {
        List<Player> players = new List<Player>();
        List<string> names = _tournement.GetInvitedPlayers();
        List<int> ratings = _tournement.GetPlayerRatings(names);

        for (int i = 0; i < names.Count; i++)
            players.Add(new Player(names[i], ratings[i]));

        return players;
    }

    private bool IsPlayerInTournement(string name)
    {
        foreach (Player player in Players)
            if (player.Name == name)
                return true;
        return false;
    }

    private bool DoesPlayerExist(string name)
    {
        return _tournement.DoesPlayerExist(name);
    }
}
