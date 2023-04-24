using Microsoft.Data.SqlClient;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class AllPlayerData : IPlayerDal
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";

    public AllPlayerData()
    {

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
        connection.Close();
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

        if (reader != null)
            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }

        connection.Close();

        return result;
    }

    public int? GetPlayerRating(string name)
    {
        int? result = null;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Rating from Player where UserName = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                result = reader.GetInt32(0);
            }

        connection.Close();

        return result;
    }

    public bool DoesPlayerExist(string name)
    {
        if (GetPlayerRating(name) == null)
            return false;
        return true;
    }
}
