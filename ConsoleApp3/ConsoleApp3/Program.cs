using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Abiturient stud1 = new Abiturient(); недоступен из-за уровня защиты
            int[] mst3 = new int[3];
            Random key = new Random();
            Abiturient stud2 = new Abiturient(1, "Ivan", "Ivanov", "Ivanovich", "street Pushkina",mst3);
            Abiturient stud4 = new Abiturient(1, "Ivan", "Ivanov", "Ivanovich", "street Pushkina", mst3);
            Abiturient stud3 = new Abiturient("Vlad","Nester");
            var someType = new { Name = "Egor", Surname = "Egorov" };
            stud2.SumN(stud2.Marks, out stud2.sum);
            WriteLine(stud2.sum);

            Abiturient.InfoClass();
            Person Jonh = new Person();
            Jonh.Eat();
            Jonh.Move();
            WriteLine(stud2.ToString());
            WriteLine(stud2.Equals(stud4));
            
            Abiturient[] stud = new Abiturient[3];

            
                Write("Имя: ");
                
                Write("Фамилия: ");
               
                Write("Отчество: ");
               
                Write("Адрес: ");
               
                Write("Баллы(рандом) ");
               
            for(int i = 0; i < 3; i++)
            {
                int[] mst2 = new int[3];
                for (int k = 0; k < 3; k++)
                {
                    
                    mst2[k] = key.Next(0, 100);
                    
                }
                stud[i] = new Abiturient(i, ReadLine(), ReadLine(), ReadLine(), ReadLine(), mst2);

            }
            for (int j = 0; j < 3; j++)
            {
                

                WriteLine("Имя: " + stud[j].Name);
                WriteLine("Фамилия: " + stud[j].Surname);
                WriteLine("Отчество: " + stud[j].Patronymic);
                for (int i = 0; i < 3; i++)
                {
                    WriteLine("Баллы: " + stud[j].Marks[i]);
                }
                WriteLine("Баллы ниже 20");
              
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (stud[i].Marks[j] < 20)
                    {
                        WriteLine($"У студента {stud[i].Name} отрицательные баллы");
                    }
                }
            }
            int ball = int.Parse(ReadLine());
            for(int i = 0; i < 3; i++)
            {
                if (stud[i].Marks.Sum() > ball)
                {
                    WriteLine($"У студента {stud[i].Name} сумма баллов выше указанного");
                }
            }
            ReadKey();
        }
       
       
    }
    class Abiturient
    {
        
        static int count = 0;
        public const string hi = "Hello";
       public readonly int id;
        private string name;
        private string surname;
        private string patronymic;
        private string address;
        private int[] marks = new int[3];
        public int sum;
        public Abiturient(int i, string n, string sr, string p, string a, int[] z)
        {

            
            Name = n;
            Surname = sr;
            Patronymic = p;
            Address = a;
            Marks = z;
            ++count;
            id = count;
        }
        public Abiturient(string n,string sr)
        {
            name = n;
            surname = sr;
            ++count;
        }
        static Abiturient()
        {
            WriteLine("Вы создали объект");
        }
        private Abiturient()
        {

        }
        public string Name
        {
            set
            {
                
                name = value;
            }
            get
            {
                return name;
            }
        }
        public string Surname {
            set
            {
                surname = value;
            }
            get
            {
                return surname;
            }
        }
        public string Patronymic
        {
            set
            {
                patronymic = value;
            }
            get
            {
                return patronymic;
            }
        }
        public string Address
        {
            set
            {
                address = value;
            }
           private get
            {
                return address;
            }
        }
        public int []Marks
        {
            set
            {
                marks = value;
            }
            get
            {
                return marks;
            }
        }
     public void SumN(int []x,out int a)
        {
            a = x.Sum();
        } 
        public  static void InfoClass()
        {
            WriteLine($"Создано {count} объектов класса");
        }
        public override string ToString()
        {
            return "Type " + base.ToString() + " " + Name + " " + Surname;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            Abiturient stud = (Abiturient)obj;
            return (this.Name == stud.Name && this.Surname == stud.Surname);
        }        public override int GetHashCode()
        {
            
            int hash = 216;
            hash = string.IsNullOrEmpty(Name) ? 0 : Name.GetHashCode();
            hash = (hash * 21) + Name.GetHashCode();
            return hash;
        }
    }
    partial class Person
    {
        public void Eat()
        {
            WriteLine("I`m eating");
        }
    }
    partial class Person
    {
        public void Move()
        {
            WriteLine("I`m going");
        }
    }
}
