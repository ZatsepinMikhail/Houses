using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TEST
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("123")
        { }

        public DbSet<Building> Buildings { get; set; }
    }
}
