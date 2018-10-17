using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Product printer = new Printer(1, "Техника", 1200, 12);
            Product pC = new PC(2, "Техника", 1500);
            Product scaner = new Scaner(3, "Техника", 1100, 7);
            printer.Info();
            pC.Info();
            Client client = new Client("Vlad", 50000);
            client.Put(1200);
            client.Take(5000);
            WriteLine(client.CurrentSum);
            Output output = new Output();
            ((Text)output).print();
            ((Tuxt)output).print();
            BaseClient obj = client as BaseClient;
            obj = client;
            obj.Put(1321);
            WriteLine(obj.CurrentSum);
            IAccount obj2 = client as IAccount;
            obj2.Put(12);
            WriteLine(obj2.CurrentSum);
            WriteLine(pC.ToString());
            Printers printers = new Printers();
            var mass = new[] {pC,printer,scaner};
            for(int i = 0; i< 3; i++)
            {
               printers.IAmPrinting(mass[i]);
            }
            
            ReadKey();

        }
    }
    abstract class Product 
    {
       
        public abstract int Average { get; set; }
        public Product(int a)
        {
            Average = a;
        }
       
        public virtual void Info()
        {
            WriteLine($"Номер товара:{Average}");
        }
        
    }
    class Equipment : Product
    {   
        public override int Average { get; set; }
        public Equipment(int a,string str):base(a)
        {
            Average = a;
            Name = str;
        }
        public string Name { get; set; }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}");
        }
        public override string ToString()
        {
            Write("Метод ToString():");
            return Name +"  "+ base.ToString();
        }
    }
    class Tablet : Equipment
    {
        public int Cost { get; set; }
        public Tablet(int a, string str, int cost) : base(a, str)
        {
            Cost = cost;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}");
        }
        public override string ToString()
        {
            return Name + " "+base.ToString();
        }
    }
    class PC : Equipment
    {
        public int Cost { get; set; }
        public PC(int a, string str, int cost) : base(a, str)
        {
            Cost = cost;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}");
        }
        public override string ToString()
        {
            return Average+" "+Cost +" "+ base.ToString();
        }
    }
    class PrintDevice : Equipment
    {
        
        public PrintDevice(int a, string str) : base(a, str)
        {
            
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}");
        }
        public override string ToString()
        {
            return Name +" "+ base.ToString();
        }
    }
   sealed class Scaner : PrintDevice
    {
        public int Cost { get; set; }
        public int Weight { get; set; }
        public Scaner(int a, string str, int cost,int weight) : base(a, str)
        {
            Cost = cost;
            Weight = weight;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}||Вес:{Weight}");
        }
        public override string ToString()
        {
            return Weight + " "+base.ToString();
        }
    }
   sealed class Printer : PrintDevice
    {
        public int Cost { get; set; }
        public int Weight { get; set; }
        public Printer(int a, string str, int cost, int weight) : base(a, str)
        {
            Cost = cost;
            Weight = weight;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}||Вес:{Weight}");
        }
        public override bool Equals(object obj)
        {
            Write("Метод Equals():");
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            Write("Метод GetHashCode():");
            return base.GetHashCode();
        }
         public override string ToString()
        {
            return Weight + " "+ base.ToString();
        }
      
    } 
    abstract class IPrint
    {
        public virtual void IAmPrinting(Product product)
        {
            WriteLine(product.GetType().ToString());
        }
    }
    class Printers : IPrint
    {
        public override void IAmPrinting(Product product)
        {
            base.IAmPrinting(product);
        }

       
    }
    interface IAccount
    {
        int CurrentSum { get; }
        void Put(int sum);
        void Take(int sum);
    }
    interface IClient
    {
     
        string Name { get; set; }
    }
    abstract class BaseClient : IAccount, IClient
    {
        protected int _sum;
        public string Name { get; set; }
        public int CurrentSum
        {
            get
            {
                return _sum;
            }
        }
        public abstract void Put(int sum);
        
        public abstract void Take(int sum);
    }
    interface Text
    {
        void print();
    }
    interface Tuxt
    {
        void print();

    }
    class Output:Text,Tuxt
    {
        void Text.print()
        {
            WriteLine("TEXT");
        }
        void Tuxt.print()
        {
            WriteLine("TUXT");
        }
    }
    class Client : BaseClient
    {
        
        
        public Client(string name,int sum)
        {
            Name = name;
            _sum = sum;
        }
      
        public override void Put(int sum)
        {
            _sum += sum;
        }
       
        public override void Take(int sum)
        {
            if (sum <= _sum)
                _sum -= sum;
        }
    }
}
