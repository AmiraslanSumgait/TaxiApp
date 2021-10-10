using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiApp.Models;

namespace TaxiApp.Data
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserDb") { }

        public DbSet<User> Users { get; set; }
    }
}
