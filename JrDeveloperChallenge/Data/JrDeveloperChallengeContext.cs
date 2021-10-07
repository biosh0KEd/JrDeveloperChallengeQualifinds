using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JrDeveloperChallenge.Models;

namespace JrDeveloperChallenge.Models
{
    public class JrDeveloperChallengeContext : DbContext
    {
        public JrDeveloperChallengeContext (DbContextOptions<JrDeveloperChallengeContext> options)
            : base(options)
        {
        }

        public DbSet<JrDeveloperChallenge.Models.User> User { get; set; }

        public DbSet<JrDeveloperChallenge.Models.UserHistory> UserHistory { get; set; }
    }
}
