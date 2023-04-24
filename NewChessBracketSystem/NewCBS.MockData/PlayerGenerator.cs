using NewCBS.Core;

namespace NewCBS.MockData;

public class PlayerGenerator
{
    private static readonly Random r = new Random();
    public string GenerateName(int len)
    {
        string[] consonants = { "b", "c", "ch", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sch", "sh", "zh", "t", "v", "w", "x" };
        string[] vowels = { "a", "e", "i", "o", "u", "y", "aa", "oo", "ee", "oe", "ou", "au" };
        string Name = "";
        Name += consonants[r.Next(consonants.Length)].ToUpper();
        Name += vowels[r.Next(vowels.Length)];
        int b = 2;
        while (b < len)
        {
            Name += consonants[r.Next(consonants.Length)];
            b++;
            Name += vowels[r.Next(vowels.Length)];
            b++;
        }

        return Name;
    }

    public Player Next()
    {
        return new Player(r.Next(100, 3000), GenerateName(r.Next(3, 8)));
    }

    public Player Next(int rating)
    {
        return new Player(rating, GenerateName(r.Next(3, 8)));
    }

    public List<Player> NextPlayers(int amount)
    {
        List<Player> list = new List<Player>();
        for (int i = 0; i < amount; i++)
            list.Add(Next());
        return list;
    }
}
