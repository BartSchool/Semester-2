namespace NewCBS.Core.Interfaces;

public interface IAllTournementDal
{
    List<string> GetAllTournementNames();
    int GetTournementMaxPlayers(string name);
    int GetTournementID(string name);
    bool IsTournementOpen(string name);
    DateTime GetTournementStartTime(string name);
    void AddTournement(string name, DateTime startTime, bool IsOpen, int maxPlayers);
    void RemoveTournement(string name);
    bool DoesTournementExist(string name);
}
