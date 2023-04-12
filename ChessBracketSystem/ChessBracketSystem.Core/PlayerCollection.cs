using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class PlayerCollection : IPlayerCollection
{
    public int ID { get; private set; }
    public IReadOnlyList<IPlayer> List { get; private set; }

    public PlayerCollection(IReadOnlyList<IPlayer> list)
    {
        List = list;
    }

    public PlayerCollection(int iD)
    {
        ID = iD;
        List = new List<IPlayer>();
    }

    public PlayerCollection(DtoPlayerCollection dto)
    {
        ID = dto.ID;
        List<IPlayer> temp = new();
        foreach (DtoPlayer dtoplayer in dto.List)
            temp.Add(new Player(dtoplayer));
        List = temp;
    }

    public void Add(IPlayer player)
    {
        List<IPlayer> temp = new(List);
        temp.Add(player);
        List = temp;
    }

    public void Add(List<IPlayer> playerList)
    {
        List<IPlayer> temp = new(List);
        temp.AddRange(playerList);
        List = temp;
    }

    public void Remove(IPlayer player)
    {
        List<IPlayer> temp = new(List);
        temp.Remove(player);
        List = temp;
    }

    public void Remove(List<IPlayer> playerList)
    {
        List<IPlayer> temp = new(List);
        while (playerList.Count > 0)
            temp.Remove(playerList[0]);
        List = temp;
    }
}
