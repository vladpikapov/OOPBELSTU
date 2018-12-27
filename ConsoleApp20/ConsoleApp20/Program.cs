using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp20
{
    class Program
    {
        static object locker = new object();
        public static Thread myThread, thread;
        static void Main(string[] args)
        {
            Process []current = Process.GetProcesses();
            try
            {
                foreach (Process p in current)
                    Console.WriteLine($"{p.Id}-{p.ProcessName}-{p.StartTime}-{p.TotalProcessorTime}");
            }
            catch
            {

            }
            AppDomain app = AppDomain.CurrentDomain;
            Console.WriteLine(app.FriendlyName);
            Console.WriteLine(app.SetupInformation);
            Assembly[] assemblies = app.GetAssemblies();
            foreach (Assembly asm in assemblies)
                Console.WriteLine(asm.GetName().Name);
            AppDomain secondDomain = AppDomain.CreateDomain("Secondary Domain");
            secondDomain.AssemblyLoad += Domain_AssemblyLoad;
            secondDomain.DomainUnload += SecondaryDomain_DomainUnload;
            Console.WriteLine("Домен:" + secondDomain.FriendlyName);
            secondDomain.Load("System.Data"); 
            Assembly[] assemblies2 = secondDomain.GetAssemblies();
            foreach (Assembly asm in assemblies2)
                Console.WriteLine(asm.GetName().Name);

            AppDomain.Unload(secondDomain);
            
            Thread threadd  = new Thread(PrintFile);
            threadd.Start();
            Thread.Sleep(7000);
            thread = new Thread(new ThreadStart(Count1));
            myThread = new Thread(new ThreadStart(Count2));
           
            thread.Start();

            myThread.Priority = ThreadPriority.AboveNormal;
            
            myThread.Start();
            myThread.Join();
            thread = new Thread(new ThreadStart(Write1));
            myThread = new Thread(new ThreadStart(Write2));
            thread.Start();
            myThread.Start();

            Thread.Sleep(5000);
        int num = 0;
       
        TimerCallback tm = new TimerCallback(Count);
        
        Timer timer = new Timer(tm, num, 0, 2000);

        Console.ReadLine();
    }
    public static void Count(object obj)
    {
        int x = (int)obj;
        for (int i = 1; i < 9; i++, x++)
        {
            Console.WriteLine("{0}", x * i);
        }
    }
    public static void Write1()
        {
            for(int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Четн:" + i);
                    Thread.Sleep(400);
                }
            }
        }
        public static void Write2()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine("Нечетн:" + i);
                    Thread.Sleep(400);
                }
            }
        }
        public static void Count2()
        {

            thread.Join();
          
            StreamWriter writer = new StreamWriter("secondtask.txt",true);
            Console.WriteLine("\n\nНечетные числа\n");
            writer.WriteLine("\n\nНечетные числа\n");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + ", ");
                    writer.Write(i + ", ");
                }
            }
            writer.Close();
           
            Console.WriteLine();

        }
        public static void PrintFile()
        {
            Console.WriteLine("Введите число:");
            int num = Convert.ToInt32(Console.ReadLine());
            Thread t = Thread.CurrentThread;
            t.Name = "PrintFile";
            using (StreamWriter fs = new StreamWriter("nums.txt"))
            {
                for (int i = 1; i <= num; i++)
                {
                    fs.WriteLine(i);
                    if (i == 25)
                    {
                        Thread.Sleep(500);

                        Console.WriteLine(t.ThreadState + "-" + t.Name + "-" + t.Priority + "-" + t.ManagedThreadId);
                    }
                    if(i == 50)
                    {
                        Thread.Sleep(700);
                        Console.WriteLine(t.ThreadState + "-" + t.Name + "-" + t.Priority + "-" + t.ManagedThreadId);
                    }
                }
            }
        }
        private static void SecondaryDomain_DomainUnload(object sender, EventArgs e)
        {
            Console.WriteLine("Домен выгружен из процесса");
        }

        private static void Domain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            Console.WriteLine("Сборка загружена");
        }
        public static void Count1()
        {

           
            StreamWriter writer = new StreamWriter("secondtask.txt",true);
            Console.WriteLine("\nЧетные числа\n");
            writer.WriteLine("\nЧетные числа\n");
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + ", ");
                    writer.Write(i + ", ");
                }
            }
            Console.WriteLine();
            writer.WriteLine();
            writer.Close();
           

        }

    }
}
