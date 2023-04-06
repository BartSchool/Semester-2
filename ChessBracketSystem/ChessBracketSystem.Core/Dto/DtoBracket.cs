using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoBracket
{
    public DtoMatchCollection Matches { get; private set; }

    public string Type { get; private set; }

    public DtoBracket(DtoMatchCollection matches, string type)
	{
		Matches = matches;
		Type = type;
	}

	public DtoBracket(Bracket bracket)
	{
		Matches = new(bracket.Matches);
		Type = bracket.Type;
	}
}
