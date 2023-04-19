using NewCBS.Core;

namespace NewCBS.Dal;

public class TournamentCollection
{
    private readonly string connectionString = @"Server=LAPTOP-1JC5056U\SQLEXPRESS; Database=ChessBracketSystem; Trusted_Connection=True; TrustServerCertificate=True";

    public List<Tournement> tournements { get; private set; }

	public TournamentCollection()
	{
		tournements = new List<Tournement>();
	}
}
