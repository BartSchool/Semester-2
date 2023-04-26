using Microsoft.Data.SqlClient;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class AllPlayerData : IPlayerDal
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";

    public AllPlayerData()
    {

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
        connection.Close();
    }

    public void RemovePlayer(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "delete from Player where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        connection.Close();
    }

    public List<string> GetPlayerNames()
    {
        List<string> result = new List<string>();
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Username from Player",
            connection);
        var reader = command.ExecuteReader();
        if (reader == null)
            throw new Exception("incorrect sql code");

        while (reader.Read())
            result.Add(reader.GetString(0));

        connection.Close();

        return result;
    }

    public int GetPlayerRating(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Rating from Player where UserName = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        if (reader == null)
            throw new Exception("incorrect sql code");
        reader.Read();
        int result = reader.GetInt32(0);

        connection.Close();

        return result;
    }

    internal int GetPlayerID(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Player where UserName = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        if (reader == null)
            throw new Exception("incorrect sql code");

        reader.Read();
        int result = reader.GetInt32(0);

        connection.Close();

        return result;
    }

    internal string GetPlayerName(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select UserName from Player where ID = " + id,
            connection);
        var reader = command.ExecuteReader();
        if (reader == null)
            throw new Exception("incorrect sql code");

        reader.Read();
        string result = reader.GetString(0);

        connection.Close();

        return result;
    }
}
