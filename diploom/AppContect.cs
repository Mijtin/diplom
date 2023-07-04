using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace diploom
{
    internal class AppContect : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppContect() : base("DefaultConnection") { }
    }
}
