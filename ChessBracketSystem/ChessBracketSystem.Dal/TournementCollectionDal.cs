using ChessBracketSystem.Core;
using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;
using Microsoft.Data.SqlClient;

namespace ChessBracketSystem.Dal;

public class TournementCollectionDal : ITournementCollection
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    private PlayerCollectionDal _playerCollection = new();
    public List<ITournement> list { get; private set; }

    public TournementCollectionDal()
    {
        list = new();
        UpdateList();
    }

    private void UpdateList()
    {
        List<DateTime> startDates = new();
        List<string> names = new();
        List<bool> opens = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [StartTime],[name],[Open] from [Toernooi]",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                    startDates.Add(reader.GetDateTime(0));

                if (!reader.IsDBNull(1))
                    names.Add(reader.GetString(1));

                if (!reader.IsDBNull(2))
                    opens.Add(reader.GetBoolean(2));
            }

        connection.Close();

        List<DtoTournement> Tournements = new List<DtoTournement>();

        List<List<DtoPlayer>> playerLists = GetPlayers();
        List<List<DtoPlayer>> invitedPlayerLists = GetInvitedPlayers();

        List<int> maxplayers = GetMaxAmountOfPlayers();
        for (int i = 0; i < playerLists.Count; i++)
        {
            DtoPlayerCollection players = new(-1, playerLists[i]);
            DtoPlayerCollection invitedPlayers = new(-1, invitedPlayerLists[i]);
            Tournements.Add(new(0, names[i], maxplayers[i], players, invitedPlayers, new DtoBracket(-1, new(-1, new List<DtoMatch>()), "temp"), startDates[i], opens[i]));
        }

        foreach (DtoTournement dto in Tournements)
            list.Add(new Tournement(dto));
    }



    private List<List<DtoPlayer>> GetPlayers()
    {
        List<int> ids = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [PlayersListID] from [Toernooi]",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                int id = -1;
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

                ids.Add(id);
            }

        connection.Close();

        List<List<DtoPlayer>> playerLists = new();

        foreach (int id in ids)
            playerLists.Add(_playerCollection.GetPlayersFromIDs(_playerCollection.GetPlayerIDsFromList(id)));

        return playerLists;
    }

    private List<List<DtoPlayer>> GetInvitedPlayers()
    {
        List<int> ids = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [InvitedPlayersListID] from [Toernooi]",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                int id = -1;
                if (!reader.IsDBNull(0))
                    id = reader.GetInt32(0);

                ids.Add(id);
            }

        connection.Close();

        List<List<DtoPlayer>> playerLists = new();

        foreach (int id in ids)
            playerLists.Add(_playerCollection.GetPlayersFromIDs(_playerCollection.GetPlayerIDsFromList(id)));

        return playerLists;
    }

    private List<int> GetMaxAmountOfPlayers()
    {
        List<int> temp = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select [MaxPlayers] from [Toernooi]",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                int max = -1;
                if (!reader.IsDBNull(0))
                    max = reader.GetInt32(0);

                temp.Add(max);
            }

        connection.Close();

        return temp;
    }

}
