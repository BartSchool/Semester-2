using ChessBracketSystem.Core.Dto;

namespace ChessBracketSystem.View.Models;

public class PlayerModel
{
    public List<DtoPlayer> Players { get; set; }
	public int RemoveID { get; set; }
	public string RemoveName { get; set; }
	public int RemoveRating { get; set; }
	public PlayerModel()
	{

	}
}
