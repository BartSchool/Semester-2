using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoPlayerCollection
{
    public IReadOnlyList<DtoPlayer> List { get; private set; }

	public DtoPlayerCollection(IReadOnlyList<DtoPlayer> list)
	{
		List = list;
	}

	public DtoPlayerCollection(IPlayerCollection collection)
	{
        List<DtoPlayer> temp = new List<DtoPlayer>();
		foreach (IPlayer p in collection.List)
			temp.Add(new(p));
		List = temp;
	}
}
