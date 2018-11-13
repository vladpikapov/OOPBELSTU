using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public interface ICommon<T>
    {
        void Add(T obj);
        void Delete(T obj);
        void Show();

    }
    class Person
    {
        public string name;
        public Person(string n)
        {
            name = n;
        }
    }
    public class Mass<T> : ICommon<T> 
    {
       public List<T> _someobj = new List<T>();
        public void Add(T obj) 
        {
            _someobj.Add(obj);

        }
        public void Show() 
        {
            for (int i = 0; i < _someobj.Count; i++)
                Console.Write(_someobj[i] + " ");
            Console.WriteLine();
        }
       
        public class Owner
        {
            public int id;
            public string name;
            public string org;
            public Owner(int i, string n, string o)
            {
                id = i;
                name = n;
                org = o;
            }
            public void InfoOwner()
            {
                Console.WriteLine("ID:" + this.id + " Name:" + this.name + " Organization:" + this.org);
            }
        }
        public class Date
        {
            int day;
            int month;
            int year;
            public Date(int d, int m, int y)
            {
                day = d;
                month = m;
                year = y;
            }
            public void InfoDate()
            {
                Console.WriteLine("Year:" + this.year + " Month:" + this.month + " Day:" + this.day);
            }
        }
        public void Delete(T obj)
        {
            _someobj.Remove(obj);
            Console.WriteLine($"Элемент {obj} удалён");
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator true(Mass<T> m1) 
        {
            T[] mass1 = m1._someobj.ToArray();
            for(int i = 0; i < m1._someobj.Count; i++)
            {
                if (double.Parse(mass1[i].ToString()) < 0)
                    return true;
               
            }
            return false;
        }
        public static bool operator false(Mass<T> m1)
        {
            T[] mass1 = m1._someobj.ToArray();
            for (int i = 0; i < m1._someobj.Count; i++)
            {
                if (double.Parse(mass1[i].ToString()) < 0)
                    return true;

            }
            return false;
        }
        public static explicit operator int(Mass<T> m1)
        {
            return m1._someobj.Count;
        }
        public static bool operator ==(Mass<T> m1, Mass<T> m2)
        {
            return m1.Equals(m2);
        }
        public static bool operator !=(Mass<T> m1, Mass<T> m2)
        {
            return m1.Equals(m2);
        }
        public static bool operator <(Mass<T> m1, Mass<T> m2)
        {
            if (m1._someobj.Count < m2._someobj.Count)
                return true;
            return false;
        }
        public static bool operator >(Mass<T> m1, Mass<T> m2)
        {
            if (m1._someobj.Count > m2._someobj.Count)
                return true;
            return false;
        }
        public static double operator *(Mass<T> m1, Mass<T> m2)
        {
            T[] mass1 = m1._someobj.ToArray();
            T[] mass2 = m2._someobj.ToArray();
            double[] mass3 = new double[m1._someobj.Count];
            double x;
            if (mass1.Length != mass2.Length)
                throw new Exception("Разная длина массивов!");
            for(int i = 0; i < m1._someobj.Count; i++)
            {
                mass3[i] = double.Parse(mass1[i].ToString()) * double.Parse(mass2[i].ToString());
            }
            x = mass3.Sum();
            return x;
        }
       
    }
    public static class MathOperation
    {
        public static void Search (this Mass<int> m, int x)
        {
            for (int i = 0; i < m._someobj.Count; i++)
            {
                if (m._someobj[i] == x)
                {
                    Console.WriteLine("Число присутствует!");
                }

            }
        }
        public static void Del<T>(this Mass<T> m) where T : struct
        {
            T[] mass1 = m._someobj.ToArray();
            for (int i = 0; i < m._someobj.Count; i++)
            {
                if (double.Parse(mass1[i].ToString()) < 0)
                    m._someobj.Remove(m._someobj[i]);

            }
           
        }
        public static int Max(this Mass<int> m)
        {
            
            return m._someobj.Max();
        }
        public static int Min(this Mass<int> m)
        {
            return m._someobj.Min();
        }
        public static int Count(this Mass<int> m)
        {
            return m._someobj.Count;
        }
        public static int CountStr(this string str, char a)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == a)
                    count++;
            }
            return count;
        }
        public static bool DelOnTwo(this int x)
        {
            if (x % 2 == 0)
                return true;
            else
                return false;
        }
    }
}