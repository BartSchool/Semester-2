using Microsoft.Data.SqlClient;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class PlayerData : IPlayerDal
{
    private AllPlayerData _playerData = new();
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    private int ID { get; set; }

    public PlayerData(int id)
    {
        ID = id;
    }

    public void AddPlayer(string name)
    {
        if (!_playerData.DoesPlayerExist(name))
            throw new Exception("Cant Add A Player That Does Not Exist");

        int? playerid = GetIdFromName(name);
        if (playerid != null)
            AddPlayerListConnection(ID, playerid);
    }

    public void AddPlayer(string name, int rating)
    {
        if (!_playerData.DoesPlayerExist(name))
            throw new Exception("Cant Add A Player That Does Not Exist");

        int? playerid = GetIdFromName(name);
        AddPlayerListConnection(ID, playerid);
    }

    public void RemovePlayer(string name)
    {
        using var connection = new SqlConnection(connectionString);
        int? playerid = GetIdFromName(name);

        connection.Open();

        var command = new SqlCommand(
            "delete from PlayerList where PlayerID = " + playerid + "and ListID = " + ID,
            connection);
        var reader = command.ExecuteReader();
        connection.Close();
    }

    public List<string> GetPlayerNames()
    {
        List<int> playerIDs = GetPlayerIds();

        List<string> result = new();
        foreach (int id in playerIDs)
        {
            string? newPlayer = GetPlayerName(id);
            if (newPlayer != null)
                result.Add(newPlayer);
        }

        return result;
    }

    public int? GetPlayerRating(string name)
    {
        List<string> allPlayers = GetPlayerNames();

        int? rating = null;
        foreach (string player in allPlayers)
            if (player == name)
                rating = GetRating(name);
        return rating;
    }

    public bool DoesPlayerExist(string name)
    {
        if (GetRating(name) == null)
            return false;
        return true;
    }

    private string? GetPlayerName(int id)
    {
        string? result = null;

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Username from Player where ID = " + id,
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                result = reader.GetString(0);
            }
        connection.Close();

        return result;
    }

    private List<int> GetPlayerIds()
    {
        List<int> playerIDs = new();
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select PlayerId from PlayerList where ListID = " + ID,
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                playerIDs.Add(reader.GetInt32(0));
            }

        connection.Close();
        return playerIDs;
    }

    private int? GetRating(string name)
    {
        int? rating = null;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Rating from Player where Username = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                rating = reader.GetInt32(0);
            }
        connection.Close();

        return rating;
    }

    private int? GetIdFromName(string name)
    {
        int? id = null;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Player where Username = '" + name + "'",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
        connection.Close();

        return id;
    }

    private void AddPlayerListConnection(int listid, int? playerid)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into PlayerList (ListID,PlayerId)" +
            "values (" + listid + "," + playerid + ")"
            , connection);
        command.ExecuteReader();

        connection.Close();
    }
}
