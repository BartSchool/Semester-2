using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using NewCBS.Core;
using NewCBS.Core.Interfaces;

namespace NewCBS.Dal;

public class BracketDal : IBracketDal
{
    private AllPlayerData _allPlayerData = new();
    private AllMatchData _allMatchData = new();
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    private int ID { get; set; }
    private string Type { get; set; }
    public BracketDal(int tournementID)
    {
        if (DoesBracketExist(tournementID))
            ID = GetBracketID(tournementID);
        Type = GetBracketType();
    }

    public void AddMatch(string Player1name, string Player2name, DateTime startTime, string result)
    {
        int id1 = _allPlayerData.GetPlayerID(Player1name);
        int id2 = _allPlayerData.GetPlayerID(Player2name);
        int finnished = 0;
        if (result != "NotPlayed")
            finnished = 1;

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "insert into Match (BracketID, Player1ID, Player2ID, StartTime, Result, Finished) " +
            "values (" + ID + "," + id1 + "," + id2 + ",'" + startTime.ToString() + "','" + result + "','" + finnished + "')",
            connection);
        command.ExecuteReader();
        connection.Close();
    }

    private int GetBracketID(int tournementID)
    {
        int result = -1;
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Bracket Where TournementID = " + tournementID,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            if (reader.Read())
                result = reader.GetInt32(0);

        connection.Close();

        return result;
    }

    public string GetBracketType()
    {
        string result = "";
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select Type from Bracket Where ID = " + ID,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            if (reader.Read())
                result = reader.GetString(0);

        connection.Close();

        return result;
    }

    public int GetID()
    {
        return ID;
    }

    public List<Match> GetMatches()
    {
        List<int> ids = GetMatchIds();
        
        List<Match> matches = new List<Match>();
        foreach (int id in ids)
            matches.Add(_allMatchData.GetMatch(id));
        return matches;
    }

    private List<int> GetMatchIds()
    {
        List<int> Ids = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID from Match Where BracketID = " + ID,
            connection);
        var reader = command.ExecuteReader();
        if (reader != null)
            while (reader.Read())
            {
                Ids.Add(reader.GetInt32(0));
            }

        connection.Close();

        return Ids;
    }

    private bool DoesBracketExist(int id)
    {
        if (GetBracketID(id) == -1)
            return false;
        return true;
    }
}
