using SQLite;

namespace ProjectMaui.Models
{
    public class Exercise
    {
        [PrimaryKey, AutoIncrement]
        public int clientId { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string muscle { get; set; }
        public string equipment { get; set; }
        public string difficulty { get; set; }
        public string instructions { get; set; }
    }
}
