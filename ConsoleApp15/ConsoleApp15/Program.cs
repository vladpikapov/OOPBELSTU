using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            SuperList<string> superList = new SuperList<string>
            {
                "hello","World","!!!","@@@"
            };
            foreach (string write in superList)
                Console.Write(write + " ");
            Console.WriteLine();
            try
            {
                string str = "BOY";
                superList = superList + str;
            }
            
            catch(Exception m)
            {
                Console.WriteLine(m.Message);
            }
            foreach (string write in superList)
                Console.Write(write + " ");
            Console.WriteLine();
            myLinq.Task2(superList);
            Person doctor = new Person();
            Person sick = new Person(36);
            sick.Temperature += Show_Message;
            Console.WriteLine("Температура: " + sick.Temper);
            sick.Work(4);
            Console.WriteLine("Температура: " + sick.Temper);
            Console.ReadKey();
        }
        private static void Show_Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
