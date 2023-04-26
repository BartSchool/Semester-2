namespace NewCBS.Core.Interfaces;

public interface IToernementDal
{
    void EditName(string name);
    string GetName();
    void EditMaxPlayers(int maxPlayers);
    int GetMaxPlayers();
    void EditStartTime(DateTime start);
    DateTime GetStartTime();
    void AddPlayer(string name);
    void RemovePlayer(string name);
    List<string> GetPlayers();
    void InvitePlayer(string name);
    void UninvitePlayer(string name);
    List<string> GetInvitedPlayers();
    List<int> GetPlayerRatings(List<string> names);
    bool IsTournementOpen();
}
