namespace NewCBS.Core;

public class Player
{
    public int Ranking { get; private set; }
    public string Name { get; private set; }

    public Player(string name)
    {
        Name = name;
        Ranking = 500;
    }

    public Player(string name, int ranking) : this(name)
    {
        Ranking = ranking;
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