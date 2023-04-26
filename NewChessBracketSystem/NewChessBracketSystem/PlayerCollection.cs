using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class PlayerCollection
{
    private IPlayerDal _playerDB { get; set; }
	public IReadOnlyList<Player> List { get; private set; }

	public PlayerCollection(IPlayerDal playerCollection)
	{
		_playerDB = playerCollection;
		List = SetPlayers();
    }

	public void AddPlayer(string name)
	{
		Player player = new Player(name);
        if (CanAddPlayer(player.Name))
            _playerDB.AddPlayer(player.Name, player.Ranking);
		List = SetPlayers();
    }

	public void AddPlayer(string name, int rating)
	{
        Player player = new Player(name, rating);
		if (CanAddPlayer(player.Name))
			_playerDB.AddPlayer(player.Name, player.Ranking);
        List = SetPlayers();
    }

	public void RemovePlayer(string name)
	{
        Player player = new Player(name);
        if (CanRemovePlayer(player.Name))
            _playerDB.RemovePlayer(player.Name);
        List = SetPlayers();
    }

	public Player GetPlayer(string name)
	{
		if (DoesPlayerExist(name))
		{
			foreach (Player player in List)
				if (player.Name == name)
					return player;
		}
		throw new Exception("Could not get player for unknown reasons");
	}

	public List<string> GetPlayerNames()
	{
		List<string> result = new();
		foreach (Player player in List)
			result.Add(player.Name);
		return result;
	}

    public List<Player> GetPlayers()
    {
		return new(List);
    }

	private IReadOnlyList<Player> SetPlayers()
	{
		List<Player> result = new List<Player>();
		List<string> names = _playerDB.GetPlayerNames();
		foreach (string name in names)
		{
			int? rating = _playerDB.GetPlayerRating(name);

            if (rating != null)
				result.Add(new Player(name));
		}
		return result;
	}

    private bool DoesPlayerExist(string name)
	{
		foreach (Player player in List)
			if (player.Name == name)
				return true;
		return false;
	}

	private bool CanRemovePlayer(string name)
	{
		if (!DoesPlayerExist(name))
			throw new Exception("player does not exist");
		return true;
	}

	private bool CanAddPlayer(string name)
	{
		if (DoesPlayerExist(name))
			throw new Exception("player allready exist");
		return true;
	}
}
