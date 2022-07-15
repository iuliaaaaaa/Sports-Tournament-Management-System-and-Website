using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynthesisAssignment.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Tournament> tournaments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<User> SignedUsers { get; set; }
        public DbSet<Players> players { get; set; }
        public static string LoggedInUsername { get; set; }
    }
}
