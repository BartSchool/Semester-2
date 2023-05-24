namespace NewCBS.View.Models
{
    public class AddTournementModel
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public bool isOpen { get; set; }
        public int MaxPlayers { get; set; }
        public string bracketType { get; set; }

        public AddTournementModel()
        {

        }
    }
}
