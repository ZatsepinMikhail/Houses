using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser
{
    class Program
    {

        static string ParsePage(string page)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
          
            htmlDoc.Load(page);

            if (htmlDoc.ParseErrors != null && htmlDoc.ParseErrors.Count() > 0)
            {
                foreach (var error in htmlDoc.ParseErrors)
                {
                    Console.WriteLine(error.Line);
                    Console.WriteLine(error.Reason);
                }
            }
            else
            {
                var csv = new StringBuilder();

                foreach (var row in htmlDoc.DocumentNode.SelectNodes("/table/tbody/tr"))
                {
                    var cells = row.SelectNodes("td");
                    string address = cells[1].InnerText;
                    string year = cells[3].InnerText;
                    string newLine = string.Format("{0};{1}", year, address);

                    byte[] bytes = Encoding.Default.GetBytes(newLine);
                    string encodedNewLine = Encoding.UTF8.GetString(bytes);
                    csv.AppendLine(encodedNewLine);
                 }

                return csv.ToString();
            }
            return null;
        }

        static string PreparePage(string page)
        {
            string contents = File.ReadAllText(page);
            int startIndex = contents.IndexOf("<table id=\"grid-data\"");
            Console.WriteLine(contents.Count() + " " + startIndex);
            contents = contents.Substring(startIndex);
            int endIndex = contents.IndexOf("</table>");
            Console.WriteLine(contents.Count() + " " + endIndex);
            contents = contents.Substring(0, endIndex + "</table>".Count());
            return contents;
        }

        static void Main(string[] args)
        {
            string table = PreparePage("C:\\Users\\Mikhail\\Documents\\Houses_database\\Moscow\\Moscow.html");
            File.WriteAllText("C:\\Users\\Mikhail\\Documents\\Houses_database\\Moscow\\Moscow_table.html", table);
            string parsedTable = ParsePage("C:\\Users\\Mikhail\\Documents\\Houses_database\\Moscow\\Moscow_table.html");
            File.WriteAllText("C:\\Users\\Mikhail\\Documents\\Houses_database\\Moscow\\Moscow.csv", parsedTable);
        }
    }
}
