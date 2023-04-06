using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;

namespace ChessBracketSystem.Core;

public class MatchCollection : IMatchCollection
{
    public IReadOnlyList<IMatch> List { get; private set; }

    public MatchCollection()
    {
        List = new List<IMatch>();
    }

    public MatchCollection(List<IMatch> list)
    {
        List = list;
    }

    public MatchCollection(DtoMatchCollection dto)
    {
        List<IMatch> temp = new List<IMatch>();
        foreach (DtoMatch dtomatch in dto.List)
            temp.Add(new Match(dtomatch));
        List = temp;
    }

    public void Add(IMatch match)
    {
        throw new NotImplementedException();
    }

    public void Add(List<IMatch> list)
    {
        throw new NotImplementedException();
    }

    public void Remove(IMatch match)
    {
        throw new NotImplementedException();
    }

    public void Remove(List<IMatch> list)
    {
        throw new NotImplementedException();
    }
}
