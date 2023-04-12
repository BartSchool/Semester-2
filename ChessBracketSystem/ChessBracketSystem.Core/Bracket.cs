using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class Bracket
{
    public int ID { get; private set; }
    public IMatchCollection Matches { get; private set; }
    public string Type { get; private set; }

    public Bracket(int iD, IMatchCollection matches, string type)
    {
        ID = iD;
        Matches = matches;
        Type = type;
    }

    public Bracket(DtoBracket dto)
    {
        ID = dto.ID;
        Matches = new MatchCollection(dto.Matches);
        Type = dto.Type;
    }

    public void Edit(string type)
    {
        Type = type;
    }
}
