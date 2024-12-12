using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMaui.Models
{
    internal class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(30), Unique]
        public string Username { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
