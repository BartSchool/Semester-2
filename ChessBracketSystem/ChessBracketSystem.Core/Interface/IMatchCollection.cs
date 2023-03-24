namespace ChessBracketSystem.Core.Interface;

public interface IMatchCollection
{
    IReadOnlyList<IMatch> List { get; }
    void Add(IMatch match);
    void Add(List<IMatch> list);
    void Remove (IMatch match);
    void Remove (List<IMatch> list);
}
