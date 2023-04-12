namespace ChessBracketSystem.Core.Dto;

public class DtoBracket
{
	public int ID { get; private set; }
    public DtoMatchCollection Matches { get; private set; }

    public string Type { get; private set; }

    public DtoBracket(int id, DtoMatchCollection matches, string type)
	{
		ID = id;
		Matches = matches;
		Type = type;
	}

	public DtoBracket(Bracket bracket)
	{
		ID = bracket.ID;
		Matches = new(bracket.Matches);
		Type = bracket.Type;
	}
}
