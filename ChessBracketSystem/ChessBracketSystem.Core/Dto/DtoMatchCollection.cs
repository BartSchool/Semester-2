using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoMatchCollection
{
	public int ID { get; private set; }
    public IReadOnlyList<DtoMatch> List { get; private set; }

	public DtoMatchCollection(int id, IReadOnlyList<DtoMatch> list)
	{
		ID = id;
		List = list;
	}

	public DtoMatchCollection(IMatchCollection collection)
	{
		ID = collection.ID;
		List<DtoMatch> temp = new();
		foreach (Match match in collection.List)
			temp.Add(new(match));
		List = temp;
	}
}
