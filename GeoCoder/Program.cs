using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Mikhail\\Documents\\Houses_database\\Novokuznetsk\\Novokuznetsk.csv", System.Text.Encoding.UTF8);

            var csv = new StringBuilder();

            string line;
            int count = 0;
            Random random = new Random();

            //for (int i = 0; i < 9809; ++i)
            //{
            //    line = file.ReadLine();
            //}

            while ((line = file.ReadLine()) != null)
            {
                Address address = new Address(line.Split(';')[1]);
                address.GeoCode();
                string newLine = string.Format("{0};{1};{2}", line, address.Latitude, address.Longitude);
                csv.AppendLine(newLine);

                ++count;
                Console.WriteLine(count);
                    
                System.Threading.Thread.Sleep(500);
                if (count == 2500)
                {
                    break;
                }

                //int mseconds = random.Next(3, 10) * 1000;
                //System.Threading.Thread.Sleep(mseconds);
            }
            file.Close();

            File.WriteAllText("C:\\Users\\Mikhail\\Documents\\Houses_database\\Novokuznetsk\\Novokuznetsk_coord.csv", csv.ToString());
        }
    }
}
