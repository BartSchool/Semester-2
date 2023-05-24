using Microsoft.Data.SqlClient;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class AllTournementDal : IAllTournementDal
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";

    public void AddTournement(string name, DateTime startTime, bool IsOpen, int maxPlayers, string bracketType)
    {
        int open = 0;
        if (IsOpen)
            open = 1;

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "if not exists (select ID from Toernooi where [name] = '" + name + "')" +
            "begin insert into Toernooi (StartTime, [Open], [name], maxPlayers)" +
            "values ('" + startTime.ToString("yyyy-MM-dd HH:mm:ss") + "'," + open + ",'" + name + "'," + maxPlayers + ") end",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();

        connection.Open();

        command = new SqlCommand(
            "insert into Bracket (TournementID, Type)" +
            "values ((select ID from Toernooi where [name] = '" + name + "'),'" + bracketType + "')",
            connection);
        reader = command.ExecuteReader();
                    
        connection.Close();
    }

    public bool DoesTournementExist(string name)
    {
        bool result = false;

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            if (reader.Read())
                result = true;

        connection.Close();

        return result;
    }

    public List<string> GetAllTournementNames()
    {
        List<string> names = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select name from Toernooi",
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
                names.Add(reader.GetString(0));

        connection.Close();

        return names;
    }

    public int GetTournementID(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        reader.Read();
        int result = reader.GetInt32(0);

        connection.Close();
        return result;
    }

    public int GetTournementMaxPlayers(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select maxPlayers from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        reader.Read();
        int result = reader.GetInt32(0);

        connection.Close();
        return result;
    }

    public DateTime GetTournementStartTime(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select StartTime from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        reader.Read();
        DateTime result = reader.GetDateTime(0);

        connection.Close();
        return result;
    }

    public bool IsTournementOpen(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [Open] from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();
        reader.Read();
        bool result = reader.GetBoolean(0);

        connection.Close();
        return result;
    }

    public void RemoveTournement(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "delete from Toernooi where name = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    internal string GetTournementName(int id)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select name from Toernooi where ID = " + id,
            connection);
        var reader = command.ExecuteReader();
        reader.Read();
        string result = reader.GetString(0);

        connection.Close();
        return result;
    }
}
