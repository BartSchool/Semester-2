using NewCBS.Core;
using NewCBS.Core.Interfaces;

namespace NewCBS.MockData;

public class PlayerMockData : IPlayerDal
{
    private List<Player> players { get; set; }

    public PlayerMockData()
    {
        players = new List<Player>();
    }

    public void AddPlayer(string name, int rating)
    {
        players.Add(new Player(name, rating));
    }

    public void RemovePlayer(string name)
    {
        foreach (Player player in players)
            if (player.Name == name)
                players.Remove(player);
    }

    public List<string> GetPlayerNames()
    {
        List<string> names = new List<string>();
        foreach (Player player in players)
            names.Add(player.Name);
        return names;
    }

    public int GetPlayerRating(string name)
    {
        foreach (Player player in players)
            if (player.Name == name)
                return player.Ranking;
        throw new Exception("Player does not exist");
    }
}