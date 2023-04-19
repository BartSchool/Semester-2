namespace NewCBS.Core;

public class Player
{
    public int Ranking { get; private set; }
    public string Name { get; private set; }

    public Player(int ranking, string name)
    {
        Ranking = ranking;
        Name = name;
    }

    public void Edit(string name)
    {
        Name = name;
    }

    public void UpdateRanking(int newRanking)
    {
        Ranking = newRanking;
    }
}