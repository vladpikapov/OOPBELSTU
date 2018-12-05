using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
   public class Task1
    {
       
        public static void TasknumOne()
        {
            string[] month = { "Январь", "Февраль", "Март", "Апрель",
                "Май", "Июнь", "Июль", "Август",
                "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            Console.WriteLine("Введите длину названия месяца:");
            int size = Convert.ToInt32(Console.ReadLine());
            IEnumerable<string> task1 = from m in month//1 запрос
                                        where m.Length == size
                                        select m;
            PrintLinQ(task1);
            Console.WriteLine("Только зимние и летние месяцы:");
            IEnumerable<string> task1_1 = from m in month//2 запрос
                                          where m == "Январь" || m == "Февраль" || m == "Декабрь" || m == "Июнь" || m == "Июль" || m == "Август"
                                          select m;
            PrintLinQ(task1_1);
            Console.WriteLine("В алфавитном порядке:");
            IEnumerable<string> task1_2 = from m in month //3 запрос
                                          orderby m
                                          select m;
            PrintLinQ(task1_2);
            Console.WriteLine("Введите букву:");
            char a = Convert.ToChar(Console.ReadLine());
            Console.WriteLine($"Содержашие букву {a} и не менее 6 символов:");
            IEnumerable<string> task1_3 = from m in month//4 запрос
                                          where m.Contains(a) == true && m.Length <= 6
                                          select m;
            PrintLinQ(task1_3);
        }
        
        public static void PrintLinQ(IEnumerable<string> s)// вывод запроса
        {
            foreach (string write in s)
                Console.Write(write + " ");
            Console.WriteLine();
        }
    }
            
}

