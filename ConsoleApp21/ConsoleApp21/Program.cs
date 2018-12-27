using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace ConsoleApp21
{
    public class Program
    {
        public static BlockingCollection<int> blockcoll;
        static int x = 0;
        public static CancellationTokenSource tokenSource;
        public static CancellationToken token;
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();// 1 задание
            Task task = new Task(TaskFirst.Multiplication);
            stopwatch.Start();
            task.Start();

            Console.WriteLine("ID:" + task.Id);
            Console.WriteLine("Статус:" + task.Status);
            task.Wait();
            Console.WriteLine("Завершилось ли задание: " + task.IsCompleted);
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine("Затраченное время:  " + ts);

            Console.WriteLine("Повторный запуск программы!");//2 задание

            tokenSource = new CancellationTokenSource();
         
            Task task1 = new Task(() => TaskFirst.MultiplicationTwo());
            task1.Start();
            task1.Wait();
            if (tokenSource.IsCancellationRequested)
                Console.WriteLine("Task отменен");
            task1.Dispose();
            var task3_11 = Task.Factory.StartNew(() => TaskFirst.Task3_1());//3 задание
            var task3_12 = Task.Factory.StartNew(() => TaskFirst.Task3_2());
            var task3_13 = Task.Factory.StartNew(() => TaskFirst.Task3_3());
            task1 = new Task(() => TaskFirst.Task3(task3_11.Result, task3_12.Result, task3_13.Result));
            task1.Start();
            task1.Wait();
            task3_11.Dispose();
            task3_12.Dispose();
            task3_13.Dispose();
            task1.Dispose();
            //4 задание 
            task1 = new Task(() => {
                Console.WriteLine("Id задачи: {0}", Task.CurrentId);
            });
            Task task2 = task1.ContinueWith(TaskFirst.Display);
            task1.Start();
            task2.Wait();
            var awaiter = task2.GetAwaiter();
            awaiter.OnCompleted(() => {
                Console.WriteLine("GetAwaiter + OnCompleted");
            });

            //5 задание
            int[] mass1 = new int[10000000];
            int[] mass2 = new int[10000000];

            Random rand = new Random();
            stopwatch.Restart();
            for (int i = 0; i < mass1.Length; i++)
            {
                mass1[i] = rand.Next(1000);
                mass2[i] = rand.Next(1000);

            }
            stopwatch.Stop();
            TimeSpan t5 = stopwatch.Elapsed;
            Console.WriteLine($"Время затраченное в обычном цикле for: {t5}");
            int[] mass4 = new int[10000000];
            int[] mass5 = new int[10000000];
            stopwatch.Restart();
            Parallel.For(0, 10000000, i => { mass4[i] = rand.Next(1000); mass5[i] = rand.Next(1000); });
            stopwatch.Stop();
            TimeSpan t6 = stopwatch.Elapsed;
            Console.WriteLine($"Время затраченное в обычном цикле Parallel.For: {t6}");

            int[] mass6 = new int[10000000];
            int[] mass7 = new int[10000000];
            stopwatch.Restart();
            Parallel.ForEach<int>(mass6, i => { mass6[i] = rand.Next(1000); });
            stopwatch.Stop();
            TimeSpan t7 = stopwatch.Elapsed;
            stopwatch.Restart();
            Parallel.ForEach<int>(mass7, i => { mass7[i] = rand.Next(1000); });
            stopwatch.Stop();
            TimeSpan t8 = stopwatch.Elapsed;
            Console.WriteLine($"Генерация двух массивов в ParallelForEach: {t7 + t8}");
            Console.WriteLine();
            //задание 6
            Parallel.Invoke(TaskFirst.Display2,
        () => {
            Console.WriteLine("Выполняется задача {0}", Task.CurrentId);
            Thread.Sleep(3000);
        },
        () =>  Console.WriteLine(TaskFirst.ReturnSome()));;

            // задание 7
            blockcoll = new BlockingCollection<int>(5);
            Task added = new Task(TaskFirst.Added);
            Task removed = new Task(TaskFirst.Removed);
            added.Start();
            removed.Start();
            Task.WaitAll(added, removed);
            added.Dispose();
            removed.Dispose();
            // задание 8
            TaskFirst.LastTask();
            Console.WriteLine("Нажмите Enter");
            string someWrite = Console.ReadLine();
            Console.WriteLine(someWrite);
            Console.ReadKey();
        }
        
       
    }
}r
