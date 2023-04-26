using Microsoft.Data.SqlClient;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class TournementDal : IToernementDal
{
    private AllPlayerData _playerData = new();
    private AllTournementDal _tournementData = new();
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    private int ID { get; set; }
    private string Name { get; set; }

    public TournementDal(string name)
    {
        Name = name;
        ID = _tournementData.GetTournementID(name);
    }

    public TournementDal(int id)
    {
        ID = id;
        Name = _tournementData.GetTournementName(id);
    }

    public void EditName(string name)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "update Toernooi" +
            "set name = '" + name + "'" +
            "where ID = " + ID,
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void EditMaxPlayers(int maxPlayers)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "update Toernooi" +
            "set maxPlayers = " + maxPlayers +
            "where ID = " + ID,
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void EditStartTime(DateTime start)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "update Toernooi" +
            "set StartTime = '" + start + "'" +
            "where ID = " + ID,
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public List<string> GetInvitedPlayers()
    {
        List<string> names = new List<string>();
        List<int> ids = GetInvitedPlayerIDs();
        foreach (int id in ids)
        {
            string? name = _playerData.GetPlayerName(id);
            if (name != null)
                names.Add(name);
        }
        return names;
    }

    public List<string> GetPlayers()
    {
        List<string> names = new List<string>();
        List<int> ids = GetPlayerIDs();
        foreach (int id in ids)
        {
            string? name = _playerData.GetPlayerName(id);
            if (name != null)
                names.Add(name);
        }
        return names;
    }

    public void AddPlayer(string name)
    {
        int? playerID = _playerData.GetPlayerID(name);

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "if not exists (select * from Players where TournementID = " + ID + " and PlayerId = " + playerID + ")" +
            " begin insert into Players (TournementID, PlayerId)" +
            "values (" + ID + "," + playerID + ") end",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void InvitePlayer(string name)
    {
        int? playerID = _playerData.GetPlayerID(name);

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "if not exists (select * from InvitedPlayers where TournementID = " + ID + " and PlayerId = " + playerID + ")" +
            " begin insert into Players (TournementID, PlayerId)" +
            "values (" + ID + "," + playerID + ")",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void RemovePlayer(string name)
    {
        int? id = _playerData.GetPlayerID(name);
        if (id != null)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "delete from Players where ID = " + id,
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
    }

    public void UninvitePlayer(string name)
    {
        int? id = _playerData.GetPlayerID(name);
        if (id != null)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(
                "delete from InvitedPlayers where ID = " + id,
                connection);
            var reader = command.ExecuteReader();

            connection.Close();
        }
    }

    public List<int> GetPlayerRatings(List<string> names)
    {
        List<int> result = new();
        foreach (string name in names)
            result.Add(_playerData.GetPlayerRating(name));
        return result;
    }

    public string GetName()
    {
        return Name;
    }

    public int GetMaxPlayers()
    {
        return _tournementData.GetTournementMaxPlayers(Name);
    }

    public DateTime GetStartTime()
    {
        return _tournementData.GetTournementStartTime(Name);
    }

    public bool IsTournementOpen()
    {
        return _tournementData.IsTournementOpen(Name);
    }

    private List<int> GetPlayerIDs()
    {
        List<int> ids = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select PlayerId from Players where TournementID = " + ID,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }

        connection.Close();

        return ids;
    }

    private List<int> GetInvitedPlayerIDs()
    {
        List<int> ids = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select PlayerId from InvitedPlayers where TournementID = " + ID,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }

        connection.Close();

        return ids;
    }
}
