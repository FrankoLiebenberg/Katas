using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerKata1
{
    public class ContainerDepot
    {
        static void Main(string[] args)
        {
            Sorter sort = new Sorter();

            string[] readFile = sort.GetFile();

            List<string> lstMessages = sort.Sort(readFile);

            foreach(string message in lstMessages)
            {
                Console.WriteLine(message);
            }
            Console.WriteLine("Press any key to continue...");

            Console.ReadKey();
        }

    }
}
