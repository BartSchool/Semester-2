using NewCBS.Core;

namespace NewCBS.View.Models;

public class TournementModel
{
    public int Id { get; set; }
    public Tournement tournement { get; set; }
    public string removeName { get; set; }
    public TournementModel()
    {

    }
}
