using ChessBracketSystem.Core;
using ChessBracketSystem.Core.Dto;
using ChessBracketSystem.Core.Interface;
using Microsoft.Data.SqlClient;

namespace ChessBracketSystem.Dal;

public class MatchCollectionDal : IMatchCollection
{
    private static readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True";
    public int ID { get; private set; }
    public IReadOnlyList<IMatch> List { get; private set; }

    public MatchCollectionDal()
    {
        List = new List<IMatch>();
        UpdateList();
    }

    private void UpdateList()
    {
        PlayerCollectionDal playersDB = new PlayerCollectionDal();
        List<IMatch> temp = new List<IMatch>();

        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(
            "select (ID, StartTime, Result, Finished, PlayerListID) from Match",
            connection);
        var reader = command.ExecuteReader();

        if (reader != null)
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                DateTime start = reader.GetDateTime(1);
                string result = reader.GetString(2);
                bool finished = reader.GetBoolean(3);
                int listid = reader.GetInt32(4);

                DtoPlayerCollection collection = new(ID, playersDB.GetPlayersFromIDs(playersDB.GetPlayerIDsFromList(listid)));

                Match next = new Match(id, start, result, finished, new PlayerCollection(collection));
                temp.Add(next);
            }

        connection.Close();
        List = temp;
    }

    public void Add(IMatch match)
    {
        throw new NotImplementedException();
    }

    public void Add(List<IMatch> list)
    {
        throw new NotImplementedException();
    }

    public void Remove(IMatch match)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        var command = new SqlCommand(
        "delete from Player where Username = '" + ""  + "' and Rating = ",
            connection);
        var reader = command.ExecuteReader();

        connection.Close();
    }

    public void Remove(List<IMatch> list)
    {
        throw new NotImplementedException();
    }
}