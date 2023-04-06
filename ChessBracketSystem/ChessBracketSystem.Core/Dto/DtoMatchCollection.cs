using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoMatchCollection
{
    public IReadOnlyList<DtoMatch> List { get; private set; }

	public DtoMatchCollection()
	{
		List = new List<DtoMatch>();
	}

	public DtoMatchCollection(IReadOnlyList<DtoMatch> list)
	{
		List = list;
	}

	public DtoMatchCollection(IMatchCollection collection)
	{
		List<DtoMatch> temp = new();
		foreach (Match match in collection.List)
			temp.Add(new(match));
		List = temp;
	}
}
