using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp4
{
    class Lab4
    {
        static void Main(string[] args)
        {
            Random key = new Random();
            int size = int.Parse(ReadLine());
            Mass mass = new Mass(size);
            Mass mass2 = new Mass(6);
            for(int i = 0; i<mass.length;i++)
            {
                mass[i] = key.Next(-50, 100);
                Write("|{0}|", mass[i]);
            }
            WriteLine("");
            for(int i = 0; i < mass2.length; i++)
            {
                mass2[i] = key.Next(-50, 100);
                Write("|{0}|", mass2[i]);
            }
            Mass mass3 = new Mass(6);
            mass3 = mass * mass2;
            WriteLine("");
            for(int i = 0; i < mass3.length; i++)
            {
                Write("|{0}|", mass3[i]);
            }
            WriteLine("");
            if (mass)
                WriteLine(true);
            else
                WriteLine(false);
           
            WriteLine("Размер массива:" + (int)mass);
            WriteLine("Равенство:" + (mass == mass2));
            if (mass > mass2)
                WriteLine(true);
            else
                WriteLine(false);
            int x = int.Parse(ReadLine());
            mass.Search(x);
            //MathOperation.Del(mass);
            for (int i = 0; i < mass.length; i++)
            {
                Write("|{0}|", mass[i]);
            }
            string a = "abc";
            WriteLine(a.CountStr('a'));
            WriteLine("");
            Mass.Owner owner = new Mass.Owner(1, "Vlad", "BELSTU");
            owner.InfoOwner();
            Mass.Date date = new Mass.Date(9,10,2018);
            date.InfoDate();
            WriteLine(MathOperation.Max(mass));
            WriteLine(MathOperation.Min(mass));
            WriteLine(MathOperation.Count(mass));
            ReadKey();
        }
        
    }
  public class Mass
    {
       public class Owner
        {
           public int id;
            public string name;
            public string org;
            public Owner(int i,string n,string o)
            {
                id = i;
                name = n;
                org = o;
            }
            public void InfoOwner()
            {
                WriteLine("ID:" + this.id + " Name:" + this.name + " Organization:" + this.org);
            }
        }
        public class Date
        {
            int day;
            int month;
            int year;
            public Date(int d,int m,int y)
            {
                day = d;
                month = m;
                year = y;
            }
            public void InfoDate()
            {
                WriteLine("Year:" + this.year + " Month:" + this.month + " Day:" + this.day);
            }
        }
        public int[] arr;
        public string[] strarr;
        public int length;
        public Mass(int n)
        {
            arr = new int[n];
            length = n;
        
       
        
            strarr = new string[n];
        }
        public int this[int index]
        {
            set
            {
              
                arr[index] = value;
            }
            get
            {
              
                return arr[index];
            }
        }
      
       public static Mass operator * (Mass m1,Mass m2)
        {
            
           
            
                Mass a = new Mass (m1.length);
               for(int i = 0; i < m1.length; i++)
                {
                    a[i] = m1[i] * m2[i];
                }


            return a;
           
        }
      public static bool operator true(Mass m)
        {
            for(int i = 0; i < m.length; i++)
            {
                if(m[i] < 0)
                {
                    return false;
                }
                
            }
            return true;
            
        }
        public static bool operator false(Mass m)
        {
            for(int i = 0; i < m.length; i++)
            {
                if (m[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static explicit operator int(Mass m1)
        {
            return m1.length;
        }
        public static bool operator ==(Mass m1,Mass m2)
        {
            if (m1.length != m2.length)
                return false;
            return true;
        }
        public static bool operator !=(Mass m1, Mass m2)
        {
            if (m1.length != m2.length)
                return false;
            return true;
        }
        public static bool operator <(Mass m1, Mass m2)
        {
            if (m1.arr.Sum() < m2.arr.Sum())
                return true;
            return false;
        }
        public static bool operator >(Mass m1, Mass m2)
        {
            if (m1.arr.Sum() > m2.arr.Sum())
                return true;
            return false;
        }

      
      
    }
    public static class MathOperation
    {
        public static void Search(this Mass m,int x)
        {
            for (int i = 0; i < m.length; i++)
            {
                if (m[i] == x)
                {
                    WriteLine("Число присутствует!");
                }

            }
        }
        public static void Del(Mass m)
        {
            for (int i = 0; i < m.length; i++)
            {
                if (m[i] < 0)
                    m[i] = 0;
            }
        }
        public static int Max(Mass m)
        {
            int max = 0;
            for(int i = 0; i < m.length; i++)
            {
                if (m[i] > max)
                    max = m[i];
            }
            return max;
        }
        public static int Min(Mass m)
        {
            int min = 999;
            for(int i = 0; i < m.length; i++)
            {
                if (m[i] < min)
                    min = m[i];
            }
            return min;
        }
        public static int Count(Mass m)
        {
            int count = 0;
            for(int i = 0; i < m.length; i++)
            {
                count ++;
            }
            return count;
        }
        public static int CountStr(this string str,char a)
        {
            int count = 0;
            for(int i =0; i < str.Length; i++)
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
