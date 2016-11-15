using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CodeFirst
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("NovokuznetskBuildings")
        { }

        public DbSet<Building> Buildings { get; set; }
    }
}
