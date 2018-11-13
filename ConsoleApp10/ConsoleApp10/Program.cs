using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
            Mass<int> someClass = new Mass<int>();
            someClass.Add(1);
            someClass.Add(8);
            someClass.Add(4);
            someClass.Add(-5);
            someClass.Show();
            Mass<int> mass = new Mass<int>();
            mass.Add(1);
            mass.Add(4);
            mass.Add(-5);
            try
            {
                WriteLine(someClass * mass);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                WriteLine("Ошибка исправлена!");
                mass.Add(42);
                WriteLine(someClass * mass);
            }
            Mass<Person> PersonMass = new Mass<Person>();
            Person sasha = new Person("Sasha");
            Person pasha = new Person("Pasha");
            PersonMass.Add(sasha);
            PersonMass.Add(pasha);
            PersonMass.Show();
            string write = @"D:\lab10.txt";
            using (StreamWriter sw = new StreamWriter(write, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < someClass._someobj.Count; i++)
                {
                    sw.Write(someClass._someobj[i] + " ");
                }
            }
            using (StreamReader sr = new StreamReader(write))
            {
                WriteLine(sr.ReadToEnd());
            }
            mass.Show();
            mass.Del();
            mass.Show();
            ReadLine();
        }
    }
}
