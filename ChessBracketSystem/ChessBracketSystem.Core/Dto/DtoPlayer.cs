namespace ChessBracketSystem.Core.Dto;

public class DtoPlayer
{
    public string Name { get; private set; }
    public int Rating { get; private set; }

    public DtoPlayer(string name, int rating)
    {
        Name = name;
        Rating = rating;
    }

    public DtoPlayer(Player player)
    {
        Name = player.Name;
        Rating = player.Rating;
    }
}
