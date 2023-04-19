namespace NewCBS.Core.Interfaces;

public interface IPlayerCollection
{
    int ID { get; }

    List<Player> GetPlayers(int listID);
    void AddPlayer(string name);
    void AddPlayer(string name, int rating);
    void RemovePlayer(string name);
    Player? GetPlayer(string name);
    bool DoesPlayerExist(string name);

}
