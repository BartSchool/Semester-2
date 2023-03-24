using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;
using System.Numerics;

namespace ChessBracketSystem.Core;

public class PlayerCollection : IPlayerCollection
{
    public IReadOnlyList<IPlayer> List { get; private set; }

    public PlayerCollection(IReadOnlyList<IPlayer> list)
    {
        List = list;
    }

    public PlayerCollection(DtoPlayerCollection dto)
    {
        List = dto.List;
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
