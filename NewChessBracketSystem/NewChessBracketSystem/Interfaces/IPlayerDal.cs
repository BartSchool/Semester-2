namespace NewCBS.Core.Interfaces;

public interface IPlayerDal
{
    void AddPlayer(string name, int rating);
    void RemovePlayer(string name);
    int GetPlayerRating(string name);
    List<string> GetPlayerNames();
}
