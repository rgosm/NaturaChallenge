using SQLite;

namespace App2
{
    public class WonderWoman
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email  { get; set; }
        public string Cel { get; set; }
    }
}
