namespace NewCBS.Core.Interfaces;

public interface IBracketDal
{
    void AddMatch(string Player1name, string Player2name, DateTime startTime, string result);
    string GetBracketType();
    int GetID();
    List<Match> GetMatches();
}
