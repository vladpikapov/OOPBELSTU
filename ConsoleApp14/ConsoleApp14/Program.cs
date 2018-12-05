using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {

        static void Main(string[] args)
        {
            Task1.TasknumOne(); //1 задание
            List<Program> programs = new List<Program>();//2 задание
            Time.TimeTask();//3 задание
            myLinqtoObject.printMyLinq();//4 задание
            MyJoin.PrintMyJoin();//5 задание
            Console.ReadKey();
        }
    }
}
