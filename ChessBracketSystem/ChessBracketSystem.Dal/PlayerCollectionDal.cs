using ChessBracketSystem.Core;
using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;
using Microsoft.Data.SqlClient;

namespace ChessBracketSystem.Dal;

public class PlayerCollectionDal : IPlayerCollection
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";
    public int ID { get; private set; }
    public IReadOnlyList<IPlayer> List { get; private set; }

    public PlayerCollectionDal()
    {
        List = new List<IPlayer>();
        updateList();
    }

    public List<DtoPlayer> GetPlayers()
    {
        List<DtoPlayer> list = new List<DtoPlayer>();
        foreach (IPlayer player in List)
            list.Add(new DtoPlayer(player));
        return list;
    }

    private void updateList()
    {
        List<IPlayer> temp = new List<IPlayer>();
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "select ID, Username, Rating from Player",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                DtoPlayer nextplayer = new(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                temp.Add(new Player(nextplayer));
            }

        connection.Close();
        List = temp;
    }

    public void Add(IPlayer player)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "IF not exists (SELECT Username FROM Player WHERE Username = '" + player.Name + "') " +
            "BEGIN " +
            "INSERT INTO Player(Username, rating) " +
            "VALUES ('" + player.Name + "', " + player.Rating + ") " +
            "END",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
        updateList();
    }

    public void Add(List<IPlayer> playerList)
    {
        foreach (IPlayer player in playerList)
            Add(player);
    }

    public void Remove(IPlayer player)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = new SqlCommand(
            "delete from Player where Username = '" + player.Name + "' and Rating = " + player.Rating,
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
        updateList();
    }

    public void Remove(List<IPlayer> playerList)
    {
        foreach (IPlayer player in playerList)
            Remove(player);
    }

    internal List<DtoPlayer> GetPlayersFromIDs(List<int> ids)
    {
        List<DtoPlayer> result = new List<DtoPlayer>();
        foreach (int id in ids)
            result.Add(GetPlayerFromID(id));
        return result;
    }

    internal List<int> GetPlayerIDsFromList(int id)
    {
        List<int> playerIds = new();

        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(
            "select PlayerId from PlayerListPlayer Where ListID = " + id,
            connection);

        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                playerIds.Add(reader.GetInt32(0));
            }

        connection.Close();
        return playerIds;
    }

    internal DtoPlayer GetPlayerFromID(int id)
    {
        DtoPlayer player = new(0, "new", 0);

        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(
            "select ID, UserName, Rating from Player Where ID = " + id,
            connection);

        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                int idee = reader.GetInt32(0);
                string name = reader.GetString(1);
                int rating = reader.GetInt32(2);

                player = new(idee, name, rating);
            }

        connection.Close();
        return player;
    }

    internal int? GetIDFromUsername(string username)
    {
        int result = -1;
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(
            "select ID from Player Where Username = '" + username +"'",
            connection);

        var reader = command.ExecuteReader();

        if (reader != null)
            result = reader.GetInt32(0);
        connection.Close();
        
        return result;
    }
}