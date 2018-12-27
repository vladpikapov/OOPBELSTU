using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApp16
{
   public class Program
    {
        
        static void Main(string[] args)
        {
            
            Reflector.PrintFile(typeof(Product));
            Reflector.TakeMethod(typeof(object));
            Reflector.TakeField(typeof(Equipment));
            Reflector.TakeInterface(typeof(List<>));
            Reflector.TakeDetermMethod(typeof(Equipment));
            Console.WriteLine("Введите метод: ");
            string method = Console.ReadLine();
            Reflector.ParametersFromFile(typeof(Equipment), method);
            Console.ReadKey();

        }
       
    }
    public class Reflector
    {
        public static void PrintFile(Type type)//1 задание
        {
            StreamWriter streamWriter = new StreamWriter("text.txt", false);
            streamWriter.WriteLine("Имя класса:" + type.FullName + ". Базовый тип:" + type.BaseType + ". Ненаследуемый ли:" + type.IsSealed + ". Является ли классом:" + type.IsClass);
            streamWriter.Close();
        }
        public static void TakeMethod(Type type)//2 задание
        {

            foreach (MethodInfo method in type.GetMethods())
            {
                Console.WriteLine("Методы:");
                string modificator = "";

                if (method.IsPublic)
                {
                    modificator += "public";
                    Console.WriteLine(modificator + " " + method.ReturnType.Name + " " + method.Name + "()");
                }

            }
        }
        public static void TakeField(Type type)//3 task
        {
            Console.WriteLine("Свойства:");
            foreach (PropertyInfo member in type.GetProperties())
            {
                Console.WriteLine(member.PropertyType.Name + " " + member.Name);
            }
            Console.WriteLine("Поля:");
            foreach (FieldInfo field in type.GetFields())
            {
                Console.WriteLine(field.FieldType.Name + " " + field.Name);
            }
        }
        public static void TakeInterface(Type type)//4 task
        {
            Console.WriteLine("Интерфейсы:");
            foreach (Type i in type.GetInterfaces())
                Console.WriteLine(i.Name);
        }
        public static void TakeDetermMethod(Type type)//5 task
        {
            Console.WriteLine("Методы с указанными параметрами:");
            string met = Console.ReadLine();
            
            foreach(MethodInfo method in type.GetMethods())
            {
                ParameterInfo[] parameters = method.GetParameters();
                for(int i = 0; i < parameters.Length; i++)
                {
                    if (parameters[i].ParameterType.Name == met)
                    {
                        Console.Write(" " +method.ReturnType.Name + " " + method.Name + "(");
                        for(int j = 0; j < parameters.Length; j++)
                        {
                            Console.Write(parameters[j].ParameterType.Name + " " + parameters[j].Name);
                            Console.Write(",");
                        }
                        Console.WriteLine(")");
                    }
                }
            }
        }
        public static void ParametersFromFile(Type type,string met)
        {
            StreamReader streamReader = new StreamReader("6laba.txt");
            
            
            var methodInfo = type.GetMethod(met);
            var Count = methodInfo.GetParameters().Count();
            object[] mass = new object[Count];
            int i = 0;
            while(streamReader.EndOfStream == false)
            {
                mass[i] = streamReader.ReadLine();
                
            }
            streamReader.Close();
            string h = (string)methodInfo.Invoke(null,mass);
            Console.WriteLine(h);
        }

    }
    public abstract class Product   
    {

        public abstract int Average { get; set; }
        public Product(int a, int ag, int cost)
        {
            Average = a;
            Age = ag;
            Cost = cost;
        }
        public abstract int Cost { get; set; }
        public virtual void Info()
        {
            Console.WriteLine($"Номер товара:{Average}");
        }
        public abstract int Age { get; set; }

    }
    public class Equipment : Product
    {
        public static string InformationPrint(string a){

            return a;
            }
        public override int Age { get; set; }
        public override int Average { get; set; }
        public override int Cost { get; set; }
        public Equipment(int a, int ag, int cost, string str) : base(a, ag, cost)
        {
            Average = a;
            Age = ag;
            Name = str;
            Cost = cost;
        }
        public int asd;
        public int amd;
        public string Name { get; set; }
        public override void Info()
        {
            Console.WriteLine($"Номер товара:{Average}||Вид товара:{Name}");
        }
        public override string ToString()
        {
            Console.Write("Метод ToString():");
            return Name + "  " + base.ToString();
        }

    }

}   
