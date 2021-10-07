using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JrDeveloperChallenge.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int IsActive { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
