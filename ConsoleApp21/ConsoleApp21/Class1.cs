using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp21
{
    public class TaskFirst
    {
        public static int i = 1;
        public static void Multiplication()
        {
            Random key = new Random();
            Console.WriteLine("Введите размеры первой матрицы:");
            int[,] massFirst = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine("Введите значения первой матрицы:");
            for (int i = 0; i < massFirst.GetLength(0); i++)
            {
                for (int j = 0; j < massFirst.GetLength(1); j++)
                {
                    massFirst[i, j] = key.Next(0,100);
                }
            }
            Console.WriteLine("Введите размеры второй матрицы:");

            int[,] massSecond = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine("Введите значения второй матрицы:");
            for (int i = 0; i < massSecond.GetLength(0); i++)
            {
                for (int j = 0; j < massSecond.GetLength(1); j++)
                {
                    massSecond[i, j] = key.Next(0, 100);
                }
            }
            
            int[,] lastMass = new int[massFirst.GetLength(0),massSecond.GetLength(1)];
            int sum = 0;
            for (int i = 0; i < massFirst.GetLength(0); i++)  
            {
                for (int j = 0; j < massSecond.GetLength(1); j++)
                {
                    for (int r = 0; r < massSecond.GetLength(0); r++)
                    {
                        sum += massFirst[i, r] * massSecond[r, j];
                    }
                    lastMass[i, j] = sum;
                    sum = 0;
                }
            }
            
            Console.WriteLine("ОТВЕТ:");
            for(int i = 0; i < lastMass.GetLength(0); i++)
            {
                for (int j = 0; j < lastMass.GetLength(1); j++)
                    Console.Write(lastMass[i, j] + " ");
                Console.WriteLine();
            }
        }
        public static void MultiplicationTwo()
        {
            Random random = new Random();
            Console.WriteLine("Введите размеры первой матрицы:");
            int[,] massFirst = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
           
            for (int i = 0; i < massFirst.GetLength(0); i++)
            {
                for (int j = 0; j < massFirst.GetLength(1); j++)
                {
                    massFirst[i, j] = random.Next(0,100);
                }
            }
            Console.WriteLine("Введите размеры второй матрицы:");

            int[,] massSecond = new int[Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())];
            
            for (int i = 0; i < massSecond.GetLength(0); i++)
            {
                for (int j = 0; j < massSecond.GetLength(1); j++)
                {
                    massSecond[i, j] = random.Next(0, 100);
                }
            }
            Program.tokenSource.Cancel();
            if (Program.tokenSource.IsCancellationRequested)
                return;
            int[,] lastMass = new int[massFirst.GetLength(0), massSecond.GetLength(1)];
            int sum = 0;
            for (int i = 0; i < massFirst.GetLength(0); i++)
            {
                for (int j = 0; j < massSecond.GetLength(1); j++)
                {
                    for (int r = 0; r < massSecond.GetLength(0); r++)
                    {
                        sum += massFirst[i, r] * massSecond[r, j];
                    }
                    lastMass[i, j] = sum;
                    sum = 0;
                }
            }

            Console.WriteLine("ОТВЕТ:");
            for (int i = 0; i < lastMass.GetLength(0); i++)
            {
                for (int j = 0; j < lastMass.GetLength(1); j++)
                    Console.Write(lastMass[i, j] + " ");
                Console.WriteLine();
            }
        }
        public static string Task3_1()
        {
            Random task11 = new Random();
            return task11.Next(100).ToString();
        }
        public static string Task3_2()
        {
            Random task22 = new Random();
            return task22.Next(200).ToString();
        }
        public static string Task3_3()
        {
            Random task33 = new Random();
            return task33.Next(300).ToString();
        }
        public static void Task3(string a, string b,string c)
        {
            Console.WriteLine(a + b + c);
        }
       public static void Display(Task t)
        {
            Console.WriteLine("Id задачи: {0}", Task.CurrentId);
            Console.WriteLine("Id предыдущей задачи: {0}", t.Id);
            Thread.Sleep(3000);
        }
        public static int ReturnSome()
        {
            i++;
            Console.WriteLine("Выполняется задача:" + Task.CurrentId);
            return i;
        }
       public static void Display2()
        {
            Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
            Thread.Sleep(3000);
        }
       public static void Added()
        {
            Random r = new Random();
            int x;
            List<int> idtech = new List<int>() {1,2,3,4,5};
            for (int i = 0; i < 5; i++)
            {
                x = r.Next(0, idtech.Count - 1);
                Console.WriteLine($"Добавлен товар: {idtech[x]}");
                Program.blockcoll.Add(idtech[x]);
                idtech.RemoveAt(x);
                Thread.Sleep(r.Next(100,1000));
            }
            Program.blockcoll.CompleteAdding();
        }
        public static void Removed()
        {
            int idd;
            
            while (!Program.blockcoll.IsAddingCompleted)
            {
                if (Program.blockcoll.TryTake(out idd))
                {
                    Console.WriteLine($"Куплен товар с ID:{idd}");
                    Thread.Sleep(100);
                }
                else
                {
                    Console.WriteLine("Товара нет на складе");
                    Thread.Sleep(200);
                }
            }
        }
        public static void MyMethod()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 0)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(1000);
                }
            }
        }

        public static async void LastTask()
        {
            Console.WriteLine("Начало асинхронного метода");
            await Task.Run(() => MyMethod());
            Console.WriteLine("Конец асинхронного метода");
        }
    }
}
