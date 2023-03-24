using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class Player : IPlayer
{
    public string Name { get; private set; }
    public int Rating { get; private set; }

    public Player(string name, int rating)
    {
        Name = name;
        Rating = rating;
    }

    public Player(DtoPlayer dto)
    {
        Name = dto.Name;
        Rating = dto.Rating;
    }

    public bool CanJoin(Tournement tournament)
    {
        throw new NotImplementedException();
    }
}