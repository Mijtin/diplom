using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace diploom
{
    internal class AppConCar : DbContext
    {
        public DbSet<car> cars { get; set; }
        public AppConCar() : base("DefaultConnection1") { }
    }
}
