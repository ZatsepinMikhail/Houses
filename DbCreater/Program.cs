using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            DBConnect db = new DBConnect("cities");
            Console.WriteLine(db.Count("novokuznetsk"));
            var result = db.Select("novokuznetsk", 2005, 2010);
            Console.WriteLine(result.Count());
            foreach (var coord in result)
            {
                Console.WriteLine("(" + coord.Item1 + ";" + coord.Item2 + ")");
            }
            string a;
            a = Console.ReadLine();            
        }
    }
}
