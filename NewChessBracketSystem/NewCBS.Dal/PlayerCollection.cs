using Microsoft.Data.SqlClient;
using NewCBS.Core;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class PlayerCollection : IPlayerCollection
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    public List<Player> players { get; private set; }

    public int ID { get; private set; }

    public PlayerCollection(int id)
	{
        ID = id;
        players = new List<Player>();
	}

	public List<Player> GetPlayers()
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

        connection.Close();

        return result;
    }

    public List<Player> GetPlayers(int listID)
    {
        List<int> playerIDs = new();
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select PlayerId from PlayerList where ListID = " +listID,
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                playerIDs.Add(reader.GetInt32(0));
            }

        connection.Close();

        List<Player> result = new();
        foreach (int id in playerIDs)
        {
            Player? newPlayer = GetPlayer(id);
            if (newPlayer != null)
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
            "select Rating from Player where Username = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                newPlayer = new(reader.GetInt32(0), name);
            }

        if (newPlayer != null)
            return newPlayer;
        throw new Exception("player does not exist");
    }

    private Player? GetPlayer(int id)
    {
        Player? newPlayer = null;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Rating, Username from Player where ID = '" + id,
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                newPlayer = new(reader.GetInt32(0), reader.GetString(1));
            }

        if (newPlayer != null)
            return newPlayer;
        throw new Exception("player does not exist");
    }
}
