using NewCBS.Core;

namespace NewCBS.View.Models;

public class AddPlayerModel
{
	public List<string> players { get; set; }
    public int ID { get; set; }
	public string name { get; set; }
	public int rating { get; set; }
	public AddPlayerModel()
	{

	}
}
