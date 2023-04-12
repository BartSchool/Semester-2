using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core.Dto;

public class DtoPlayerCollection
{
	public int ID { get; private set; }
    public IReadOnlyList<DtoPlayer> List { get; private set; }

	public DtoPlayerCollection(int id, IReadOnlyList<DtoPlayer> list)
	{
		ID = id;
		List = list;
	}

	public DtoPlayerCollection(IPlayerCollection collection)
	{
		ID = collection.ID;
        List<DtoPlayer> temp = new List<DtoPlayer>();
		foreach (IPlayer p in collection.List)
			temp.Add(new(p));
		List = temp;
	}
}
