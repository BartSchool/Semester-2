using Microsoft.Data.SqlClient;
using NewCBS.Core;

namespace NewCBS.Dal;

public class AllMatchData
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    private AllPlayerData playerData = new();

	public AllMatchData()
	{

	}

	internal Match GetMatch(int id)
	{
        int p1 = -1;
        int p2 = -1;
        DateTime date = DateTime.MinValue;
        string result = "";

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "SELECT [Player1ID],[Player2ID],[StartTime],[Result] FROM [Match] " +
            "WHERE [ID] = " + id,
            connection);
        var reader = command.ExecuteReader();
        if (reader == null)
            throw new Exception("incorrect sql code");

        if (reader.Read())
        {
            p1 = reader.GetInt32(0);
            p2 = reader.GetInt32(1);
            date = reader.GetDateTime(2);
            result = reader.GetString(3);
        }

        connection.Close();

        string p1name = playerData.GetPlayerName(p1);
        string p2name = playerData.GetPlayerName(p2);
        Player player1 = new Player(p1name, playerData.GetPlayerRating(p1name));
        Player player2 = new Player(p2name, playerData.GetPlayerRating(p2name));
        MatchResult r = MatchResult.NotPlayed;

        if (result == "WinP1")
            r = MatchResult.WinP1;
        else if (result == "WinP2")
            r = MatchResult.WinP2;
        else if (result == "Draw")
            r = MatchResult.Draw;

        return new Match(date, r, player1, player2);
    }
}
