using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
namespace ProjectMaui.Models
{
    [Table("client")]
    public class Client
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("mobile")]
        public string Mobile {  get; set; }
        [Column("email")]
        public string Email {  get; set; }
        [Column("notes")]
        public string Notes { get; set; }
    }
}
