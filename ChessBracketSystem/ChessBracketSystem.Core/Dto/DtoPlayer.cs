using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoPlayer
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public int Rating { get; private set; }

    public DtoPlayer(int id, string name, int rating)
    {
        ID = id;
        Name = name;
        Rating = rating;
    }

    public DtoPlayer(IPlayer player)
    {
        ID = player.ID;
        Name = player.Name;
        Rating = player.Rating;
    }
}
