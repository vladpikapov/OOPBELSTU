using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.String;

namespace ConsoleApp1
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //1.Типы
            //a
            sbyte sbyteValue = 10;
            short shortValue = 21;
            int intValue = 124;
            long longValue = 12521;
            byte byteValue = 12;
            ushort ushortValue = 126;
            uint uintValue = 1256;
            ulong ulongValue = 1853;
            char charValue = 'B';
            bool boolValue = true;
            float floatValue = 19212421.48552F;
            double doubleValue = 1241287.59812;
            decimal decimalValue = 12451287598127598;
            string stringValue = "hello";
            //b
            //явное
            shortValue = (short)intValue;
            intValue = (int)longValue;
            ulongValue = (ulong)longValue;
            uintValue = (uint)floatValue;
            shortValue = (short)charValue;
            //неявное
            shortValue = byteValue;
            longValue = intValue;
            floatValue = longValue;
            ushortValue = charValue;
            decimalValue = sbyteValue;
            //c
            int box = 12;
            object obj = box;//упаковка
            int unbox = (int)obj;//распаковка
            
            //e
            var varValue = box + unbox;
            WriteLine(varValue.GetType());
            //f
            int? nullablevalue1 = null;
            int? nullablevalue2 = 14;
            WriteLine(nullablevalue1.HasValue);
            WriteLine(nullablevalue2.HasValue);
            int v = nullablevalue1 ?? 1;
            WriteLine(v);
            //2. Строки
            //a
            string a = "aaa";
            string b = "bbb";
            WriteLine(a == b);
            string part1 = "hello ";
            string part2 = "world ";
            string part3 = "!!!";
            string all_parts = Concat(part1, part2, part3);
            string copy_all_parts = Copy(all_parts);
            WriteLine(all_parts);
            WriteLine(copy_all_parts);
            string substring = copy_all_parts.Substring(0, 5);
            WriteLine(substring);

            string[] masstr = all_parts.Split(' ');
            foreach (string c in masstr)
            {
                Write(c + " ");
            }
            WriteLine(all_parts.Insert(int.Parse(ReadLine()), ". "));
            WriteLine(all_parts.Remove(int.Parse(ReadLine()), 5));
            string emptystring = "";
            string nullstring = null;
            try
            {

                nullstring.Equals(emptystring);

            }
            catch (Exception error)
            {
                WriteLine(error.Message);
            }
            WriteLine(emptystring.Equals(nullstring));
            StringBuilder stringbuilder = new StringBuilder("HELLO", 50);
            stringbuilder.Remove(int.Parse(ReadLine()), 1);
            WriteLine(stringbuilder);
            stringbuilder.Insert(0, 'H');
            WriteLine(stringbuilder);
            stringbuilder.Append("!!!");
            WriteLine(stringbuilder);
            int[,] intmass = new int [3,4];
            for(int i = 0; i < 3; i++)
            {

                for(int j = 0; j < 4; j++)
                {
                    Write(" ");
                    intmass[i, j] = int.Parse(ReadLine());
                    
                }
                WriteLine();
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Write(intmass[i, j]+" ");
                }
                WriteLine();
            }
            string[] strmass = new string[4];
            for(int i = 0; i < strmass.Length; i++)
            {
                strmass[i] = ReadLine();
                    
            }
            for(int i = 0; i < strmass.Length; i++)
            {
                Write(strmass[i] + " ");
            }
            WriteLine("Длина:" + strmass.Length);
            WriteLine("Введите какое слово хотите удалить: ");
            string oldValue = ReadLine();
            WriteLine("На какое заменить: ");
            string newValue = ReadLine();
            for(int i = 0; i < strmass.Length; i++)
            {
                if (strmass[i] == oldValue)
                {
                    strmass[i] = newValue;
                }
                Write(strmass[i] + " ");
            }
            WriteLine();
            int [][] zubmass = { new int[3], new int[5], new int[6] };
           for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < zubmass[i].Length; j++)
                {
                    zubmass[i][j] = int.Parse(ReadLine());
                }
            }
           foreach(int[]x in zubmass)
            {
                foreach(int b2 in x)
                {
                    Write(b2 + " ");
                }
                WriteLine();
            }
            var new_mass = new []{  new int[3] };
            var second_mass = new[] { "hello", "world" };
            //кортежи
            (int tupleInt, string tupleStr, char tupleChar, string tupleStr2, ulong tupleUlong) tuple = (10,"hello",'a',"world",100);
            WriteLine(tuple);//весь кортеж
            WriteLine(tuple.tupleInt + " " + tuple.tupleChar + " " + tuple.tupleStr2);
            (int NewTupleInt,string NewTupleStr,char newTupleChar, string SecondTupleStr,ulong NewTupleUlong) = tuple;
            var tuple2 = (name: "Vlad", age: "18");
            var tuple3 = (name: "asd", age: "124");
            WriteLine(Equals(tuple2, tuple3));
            
            int []mymass = { 1, 2, 3, 4, 5, 6, 7 };
             (int, int, int, string) MassAndStr(int[] mass, string str)
            {
                int ate = mass.Max();
                int bte = mass.Min();
                int sum = mass.Sum();
                string symbol = str.Substring(0, 1);
                return (ate, bte, sum, symbol);
            }
            WriteLine(MassAndStr(mymass, part1));
            ReadKey();
        }
       
    }
    
}

