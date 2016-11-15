using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TEST
{
    [Table("Test")]
    public class Building
    {
        public int Year { get; set; }
        [Key]
        public string Street { get; set; }
        public string CoordX { get; set; }
        public string CoordY { get; set; }
    }
}
