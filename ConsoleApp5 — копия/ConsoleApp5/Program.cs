using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipment printer = new Printer(1,2, "Принтер", 1200, 12);
            Equipment pC = new PC(2,4, "Компьютер", 1500);
            Equipment scaner = new Scaner(3,1, 1700, "Сканер",  7);
            Printer printer1 = new Printer(4,6, "Техника", 1762, 5);
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
            var mass = new[] { pC, printer, scaner };
            for (int i = 0; i < 3; i++)
            {
                printers.IAmPrinting(mass[i]);
            }
            Person person = new Person();
            Write("Имя: ");
            person.name = ReadLine();
            WriteLine();
            Write("Возраст: ");

            person.age = Convert.ToInt32(ReadLine());
            Mounth mounth = Mounth.October;
            WriteLine(mounth + 1);
            printer1.ShowInfo();
            Control laboratory = new Control();
            laboratory.Push(pC);
            laboratory.Push(printer);
            laboratory.Push(scaner);       
            laboratory.Show();
            WriteLine();
            laboratory.Count();
            laboratory.Age(3);

            laboratory.Librariary.Sort(laboratory);
            laboratory.Show();
            WriteLine();
            
            Man man = new Man();
            try
            {

                man.Money = 99;

            }
            catch (ManException ex)
            {
                WriteLine(ex.Message);
                StackTrace stackTrace = new StackTrace(ex, true);
                WriteLine(stackTrace);
            }
            catch (StrException ex)
            {
                WriteLine(ex.Message);
                StackTrace stackTrace = new StackTrace(ex, true);
                WriteLine(stackTrace);
            }
            catch (DivideByZeroException ex)
            {
                StackTrace stackTrace = new StackTrace(ex, true);
                WriteLine(stackTrace);
                WriteLine("Деление на ноль!");

            }
            catch (OverflowException ex)
            {
                WriteLine("Данное число не входит в диапазон");
                StackTrace stackTrace = new StackTrace(ex, true);
                WriteLine(stackTrace);
            }
            catch (MoneyException ex)
            {
                WriteLine(ex.Message + " he has " + ex.Money + "$");
                StackTrace stackTrace = new StackTrace(ex, true);
                WriteLine(stackTrace);
            }
            catch
            {

            }


            Prove();
            ReadKey();

        }
     static void Prove()
        {
           
                int[] aa = null;

            Debug.Assert(aa != null, "Values array cannot be null");

        }  
    }
    struct Person
    {
        public string name;
        public int age;
    }
    enum Mounth : short
    {
        September = 9,
        October,
        November,
        December,
        January = 1,
        February,
        March,
        April,
        May,
        June,
        July,
        August
    }
    public abstract class Product
    {

        public abstract int Average { get; set; }
        public Product(int a,int ag,int cost)
        {
            Average = a;
            Age = ag;
            Cost = cost;
        }
        public abstract int Cost { get; set; }
        public virtual void Info()
        {
            WriteLine($"Номер товара:{Average}");
        }
        public abstract int Age { get; set; }

    }
    public class Equipment : Product
    {
        public override int Age { get; set; }
        public override int Average { get; set; }
        public override int Cost { get; set; }
        public Equipment(int a,int ag,int cost, string str) : base(a,ag,cost)
        {
            Average = a;
            Age = ag;
            Name = str;
            Cost = cost;
        }
        public string Name { get; set; }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}");
        }
        public override string ToString()
        {
            Write("Метод ToString():");
            return Name + "  " + base.ToString();
        }
    }
    public class Tablet : Equipment
    {
       
        public Tablet(int a,int ag, int cost, string str ) : base(a,ag,cost, str)
        {
            this.Cost = cost;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}");
        }
        public override string ToString()
        {
            return Name + " " + base.ToString();
        }
    }
    public class PC : Equipment
    {
      
        public PC(int a,int ag, string str, int cost) : base(a,ag,cost, str)
        {
            this.Cost = cost;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}");
        }
        public override string ToString()
        {
            return Average + " " + Cost + " " + base.ToString();
        }
    }
    public class PrintDevice : Equipment
    {

        public PrintDevice(int a,int ag, string str,int cost) : base(a,ag,cost, str)
        {
          
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}");
        }
        public override string ToString()
        {
            return Name + " " + base.ToString();
        }
    }
    sealed class Scaner : PrintDevice
    {
       
        public int Weight { get; set; }
        public Scaner(int a,int ag, int cost, string str,  int weight) : base(a,ag, str,cost)
        {
            this.Cost = cost;
            Weight = weight;
        }
        public override void Info()
        {
            WriteLine($"Номер товара:{Average}||Вид товара:{Name}||Цена:{Cost}||Вес:{Weight}");
        }
        public override string ToString()
        {
            return Weight + " " + base.ToString();
        }
    }
    public partial class Printer : PrintDevice
    {
        
        public int Weight { get; set; }
        public Printer(int a,int ag, string str, int cost, int weight) : base(a,ag, str,cost)
        {
            this.Cost = cost;
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
            return Weight + " " + base.ToString();
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
    class Output : Text, Tuxt
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


        public Client(string name, int sum)
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
    public class Laboratory:IComparer<Equipment>
    {
       public int Compare(Equipment obj, Equipment obj2)
        {
            if (obj.Cost > obj2.Cost)
                return 1;
            else if (obj.Cost < obj2.Cost)
                return -1;
            else
                return 0;
        }
        public List<Equipment> Librariary { get; set; } = new List<Equipment>();
        public void Push(Equipment obj)
        {
            Librariary.Add(obj);
            WriteLine("Объект типа " + obj.Name + " добавлен");

        }
        public void Remove(int x, Equipment obj)
        {
            Librariary.Remove(obj);
        }
        public void Show()
        {
            Write("Все объекты: ");
            for (int i = 0; i < Librariary.LongCount(); i++)
            {
                Write(" " + Librariary[i].Name);
            }
        }
        public void Count()
        {
            int count1 = 0; int count2 = 0; int count3 = 0;
            for (int i = 0; i < Librariary.LongCount(); i++)
            {
                if(Librariary[i].Name == "Принтер")
                {
                    count1++;
                }
                if(Librariary[i].Name == "Компьютер")
                {
                    count2++;
                }
                if(Librariary[i].Name == "Сканер")
                {
                    count3++;
                }
            }
            
                WriteLine("Принтеров: " + count1);
            WriteLine("Компьютеров: " + count2);
            WriteLine("Сканеров: " + count3);
        }
        public void Age(int x)
        {
            for (int i = 0; i < Librariary.LongCount(); i++)
            {
                if (x < Librariary[i].Age)
                    WriteLine(Librariary[i].Name + " Возраст:" + Librariary[i].Age);
            }
        } 
      
    }
   
   
    public class Control: Laboratory
    {

    }

}
  
  

