namespace NewCBS.Core.Interfaces;

public interface IPlayerDal
{
    void AddPlayer(string name, int rating);
    void RemovePlayer(string name);
    int GetPlayerRating(string name);
    List<string> GetPlayerNames();
    bool IsPlayerActive(string name);
    void EditPlayerName(string name, string newName);
    void EditPlayerRating(string name, int newRating);
}
