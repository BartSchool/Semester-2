using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoPlayerCollection
{
    public IReadOnlyList<IPlayer> List { get; private set; }

	public DtoPlayerCollection(IReadOnlyList<IPlayer> list)
	{
		List = list;
	}

	public DtoPlayerCollection(IPlayerCollection collection)
	{
		List = collection.List;
	}
}
