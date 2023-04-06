using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class Bracket
{
    public IMatchCollection Matches { get; private set; }

    public string Type { get; private set; }

    public Bracket(IMatchCollection matches, string type)
    {
        Matches = matches;
        Type = type;
    }

    public Bracket(DtoBracket dto)
    {
        Matches = new MatchCollection(dto.Matches);
        Type = dto.Type;
    }

    public void Edit(string type)
    {
        Type = type;
    }
}
