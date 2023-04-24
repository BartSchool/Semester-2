using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class PlayerCollection
{
	private int? MaxPlayers { get; set; }
    private IPlayerDal _playerDB { get; set; }
	public IReadOnlyList<Player> List { get; private set; }

	public PlayerCollection(IPlayerDal playerCollection)
	{
		_playerDB = playerCollection;
		List = SetPlayers();
		MaxPlayers = null;
    }

	public PlayerCollection(IPlayerDal playerCollection, int maxPlayers) : this(playerCollection)
	{
		MaxPlayers = maxPlayers;
	}

	public void AddPlayer(string name)
	{
		List<Player> list = new List<Player>();
		if (CanAddPlayer(name))
            _playerDB.AddPlayer(name);

        list.Add(new Player(800, name));
        List = list;
    }

	public void AddPlayer(string name, int rating)
	{
        List<Player> list = new List<Player>();
        if (CanAddPlayer(name))
             _playerDB.AddPlayer(name, rating);

        list.Add(new Player(rating, name));
        List = list;
    }

	public void RemovePlayer(string name)
	{
		List<Player > list = new List<Player>();
		if (CanRemovePlayer(name))
            _playerDB.RemovePlayer(name);
		
		Player player = GetPlayer(name);
		list.Remove(player);
	}

	public Player GetPlayer(string name)
	{
		foreach (Player player in List)
			if (player.Name == name)
				return player;
		throw new Exception("player does not exist");
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
				result.Add(new Player((int)rating, name));
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
		if (List.Count == MaxPlayers)
			throw new Exception("allready enough players");
		return true;
	}
}
