using NewCBS.Core.Interfaces;

namespace NewCBS.Core;

public class PlayerCollection
{
    private IPlayerCollection _playerDB { get; set; }
	public IReadOnlyList<Player> Players { get; private set; }

	public PlayerCollection(IPlayerCollection playerCollection)
	{
		_playerDB = playerCollection;
	}

	public void AddPlayer(string name)
	{
		if (_playerDB.CanAddPlayer(name))
			_playerDB.AddPlayer(name);
	}

	public void AddPlayer(string name, int rating)
	{
		if (_playerDB.CanAddPlayer(name))
		_playerDB.AddPlayer(name, rating);
	}

	public void RemovePlayer(string name)
	{
		_playerDB.RemovePlayer(name);
	}

	public Player? GetPlayer(string name)
	{
		return _playerDB.GetPlayer(name);
	}

	public List<Player> GetPlayers(int ListID)
	{
		return _playerDB.GetPlayers(ListID);
	}
}
