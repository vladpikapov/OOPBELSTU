using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class myLinqtoObject
    {
       public static void printMyLinq()
        {
            string[] someMassive = { "Андрей", "Егор",
            "Максим", "Дима", "Влад", "Женя" };
            IEnumerable<string> task1 = someMassive.Where(p => p.Length >= 4)
                .Skip(2)
                .OrderBy(p => p)
                .Where(p => p.Contains('а'))
                .ToArray()
                .Select(p => p);


            foreach (string str in task1)
                Console.Write(str + " ");


        }

    }
}
