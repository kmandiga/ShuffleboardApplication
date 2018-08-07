using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShuffleboardApplication.Models
{
    public class MyDBContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }

        public MyDBContext() : base("MyDBConnection")
        {
            
        }
        
    }
}