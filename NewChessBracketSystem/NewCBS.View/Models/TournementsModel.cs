using NewCBS.Core;

namespace NewCBS.View.Models;

public class TournementsModel
{
	public List<int> Ids { get; set; }
    public List<string> Tournementnames { get; set; }
	public List<int> MaxPlayers { get; set; }
	public List<int> CurrentPlayers { get; set; }
	public List<DateTime> StartTimes { get; set; }

	public int ID { get; set; }

	public TournementsModel()
	{

	}
}
