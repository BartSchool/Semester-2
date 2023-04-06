using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.View.Models;

public class PlayerModel
{
    public IPlayerCollection Players { get; set; }
	public string RemoveName { get; set; }
	public int RemoveRating { get; set; }
	public PlayerModel()
	{

	}
}
