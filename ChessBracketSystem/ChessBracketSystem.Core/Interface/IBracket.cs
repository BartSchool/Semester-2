namespace ChessBracketSystem.Core.Interface;

public interface IBracket
{
    IMatchCollection Matches { get; }
    string Type { get; }

    void Edit(string type);
}
