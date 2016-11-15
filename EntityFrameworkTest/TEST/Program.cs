using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;
using System.Diagnostics;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleContext context = new SampleContext();
            using (var sr = new StreamReader(@"C:\Users\iceisnice\Documents\EntityFrameworkTest\TEST\data\Novokuznetsk_coord.csv"))
            {
                var parser = new CsvParser(sr);
                parser.Configuration.Delimiter = "\t";
                while (true)
                {
                    string[] row = parser.Read();
                    if (row == null)
                    {
                        break;                     
                    }
                    if (row.Length >= 4)
                    {
                        Building building = new Building();
                        building.Year = Convert.ToInt32(row[0]);
                        building.Street = row[1];
                        building.CoordX = row[2];
                        building.CoordY = row[3];
                        context.Buildings.Add(building);
                        context.SaveChanges();
                    }                  
                }
            }
        }
    }
}
