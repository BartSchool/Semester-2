using Microsoft.Data.SqlClient;
using NewCBS.Core;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class PlayerCollection : IPlayerCollection
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    public List<Player> players { get; private set; }

	public PlayerCollection()
	{
		players = GetPlayersFromDB();
	}

	private List<Player> GetPlayersFromDB()
	{
		List<Player> result = new List<Player>();
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Username, Rating from Player",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                Player newPlayer = new(reader.GetInt32(1), reader.GetString(0));
                result.Add(newPlayer);
            }
        return result;
    }

    public void AddPlayer(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into Player (Username, Rating)" +
            "values('" + name + "', " + 800 + ")",
            connection);
        var reader = command.ExecuteReader();
    }

    public void AddPlayer(string name, int rating)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into Player (Username, Rating)" +
            "values('" + name + "', " + rating + ")",
            connection);
        var reader = command.ExecuteReader();
    }

    public void RemovePlayer(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "delete from Player where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
    }

    public Player? GetPlayer(string name)
    {
        Player? newPlayer = null;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Username, Rating from Player",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            newPlayer = new(reader.GetInt32(1), reader.GetString(0));

        return newPlayer;
    }
}
