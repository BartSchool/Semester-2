namespace NewCBS.Core.Interfaces;

public interface IPlayerCollection
{
    int ID { get; }

    List<Player> GetPlayers();
    void AddPlayer(string name);
    void AddPlayer(string name, int rating);
    void RemovePlayer(string name);
    Player? GetPlayer(string name);
    bool CanAddPlayer(string name);

}
