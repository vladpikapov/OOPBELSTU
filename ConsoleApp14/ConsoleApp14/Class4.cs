using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class MyJoin
    {
        public static void PrintMyJoin()
        {
            string[] names = { "Егор", "Таня", "Максим", "Лена" };
            int[] key = { 1, 4, 5, 7 };

            var result = names.Join(key, p => p.Length, w => w,
                (p, w) => new { id = p,name = string.Format("{0}",w)});
            Console.WriteLine("Результат:");
            foreach (var item in result)
            {
               
                Console.WriteLine(item);
                
            }
                
        }

    }
}
