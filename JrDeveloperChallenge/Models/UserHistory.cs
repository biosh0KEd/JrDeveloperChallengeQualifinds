using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JrDeveloperChallenge.Models
{
    public class UserHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
