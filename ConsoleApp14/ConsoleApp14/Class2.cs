using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Time
    {
        public static void TimeTask()
        {
            //список дат для заданного года;
            //список дат, которые имеют заданный месяц
            //количество дат в определённом диапазоне
            //максимальную дату
            //Первую дату для заданного дня
            //Упорядоченный список дат(хронологически)
            var mass = new[] {
                new{year = 1990,month = 5,day = 6},
                new{year = 1520,month = 10,day = 25},
                new{year = 2018,month = 12, day = 31},
                new{year = 2007,month = 7,day =7 },
                new{year = 2024,month = 6,day =7 },
            };
            string []   key = { "Ночь", "Утро", "День", "Вечер" };
            IEnumerable<string> myYear = from t in mass //1 запрос 
                                         where t.year == 2018
                                         select t.year.ToString() + ":" + t.month.ToString() + ":" + t.day.ToString();
            IEnumerable<string> myMonth = from t in mass
                                          where t.month == 5
                                          select t.year.ToString() +":"+ t.month.ToString() +":"+ t.day.ToString();

            Console.WriteLine("Дата с заданным годом:");
            foreach (string x in myYear)
                Console.Write(x);
            Console.WriteLine();
            Console.WriteLine("Дата с заданным месяцем:");
            foreach (string x in myMonth)
                Console.Write(x);
            Console.WriteLine();
            IEnumerable<string> myDiapazone = from t in mass
                                          where t.day >5 && t.day<30
                                          select t.year.ToString() + ":" + t.month.ToString() + ":" + t.day.ToString();
            Console.WriteLine("С диапазоном дат:");
            foreach (string x in myDiapazone)
                Console.Write(x + "^-^");
            Console.WriteLine();
            int min = mass.Min(a => a.year);
            IEnumerable<string> MyMaxYear = from t in mass
                                            where t.year == min
                                            select t.year.ToString() + ":" + t.month.ToString() + ":" + t.day.ToString(); 
            Console.WriteLine("Максимальная дата:");
            foreach (string x in MyMaxYear)
                Console.Write(x);
            Console.WriteLine();
            Console.WriteLine("Первая дата для заданного дня:");

            IEnumerable<string> MyDate = from t in mass
                                         where t.day.ToString().StartsWith("7") 
                                         select t.year.ToString() + ":" + t.month.ToString() + ":" + t.day.ToString();
            int i = 0;
            foreach (string x in MyDate)
            {
                if(i < 1)
                    Console.Write(x);
                i++;

            }
            Console.WriteLine("Хронология:");
            IEnumerable<string> MyChrono = from t in mass
                                         orderby t.year, t.day, t.month
                                         select t.year.ToString() + ":" + t.month.ToString() + ":" + t.day.ToString() + " ";
            foreach (string x in MyChrono)
                Console.Write(x);
            Console.WriteLine();

        }

    }
}
