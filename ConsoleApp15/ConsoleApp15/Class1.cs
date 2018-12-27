using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class myLinq
    {
        public static void Task2(SuperList<string> m )
        {
            IEnumerable<string> task2 = m.Take(1);
            foreach (string writestr in task2)
                Console.WriteLine(writestr);
                                        
        }
    }
}
