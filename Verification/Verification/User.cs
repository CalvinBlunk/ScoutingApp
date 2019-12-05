using SQLite;

namespace Verification
{
    class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string username { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string password { get; set; }
        [MaxLength(10)]
        public string address { get; set; }
        public string pin { get; set; }
    }
}