using System;
using System.Linq;
using LinqToDB.Mapping;
using Newtonsoft.Json;


namespace FilmLabBackEnd.Models
{
    [Table(Name = "users")]
    public class Account
    {
        [Column("user_id")]
        [Column(IsPrimaryKey = true)]
        public Guid Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
        
        [Column("nickname")]
        public string Nickname { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("password")]
        public string Password { get; set; }

        [Column("user_role")]
        public string Role { get; set; }
    }

    
}