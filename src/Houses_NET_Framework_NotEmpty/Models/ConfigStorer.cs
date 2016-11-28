using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Houses_NET_Framework_NotEmpty.Models
{
    public class ConfigStorer
    {
        public string server { get; }
        public string database { get; }
        public string uid { get; }
        public string password { get; }

        public ConfigStorer()
        {
            SortedDictionary<string, string> configs =
                new SortedDictionary<string, string>();

            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader("..\\..\\config_file.txt");

            while ((line = file.ReadLine()) != null)
            {
                var splitted_line = line.Split(':');
                configs.Add(splitted_line[0], splitted_line[1]);
                Console.WriteLine(line);
            }
            file.Close();

            server = configs["SERVER"];
            database = configs["DATABASE"];
            uid = configs["UID"];
            password = configs["PASSWORD"];
        }
    }
}
