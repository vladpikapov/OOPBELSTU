using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12

{
    class StringEdit
    {
        public static string str;
        public StringEdit(string _str)
        {
            str = _str;
        }
        public static string DeletingPunctuationMarks()
        {
            string[] newArr = str.Split(new char[] { ',', '.', ';', ':', '?', '!', '-' });
            str = null;
            for (int i = 0; i < newArr.Length; i++)
            {
                str += newArr[i];
            }
            Console.WriteLine(str);
            return str;
        }
        public static string NumberAdding()
        {
            str += 1234.ToString();
            Console.WriteLine(str);
            return str;
        }
        public static string ToUpperCase()
        {
            str = str.ToUpper();
            Console.WriteLine(str);
            return str;
        }
        public static string ToLowerCase()
        {
            str = str.ToLower();
            Console.WriteLine(str);
            return str;
        }
        public static string SpaceDeleting()
        {
            string[] words = str.Split(new char[] { ' ' });
            str = null;
            for (int i = 0; i < words.Length; i++)
            {
                str += words[i];
            }
            Console.WriteLine(str);
            return str;
        }
    }
    class PersonEventArgs
    {

        public string Message { get; }
        public int Sum { get; }
        public PersonEventArgs(string mes, int sum)
        {
            Message = mes;
            Sum = sum;
        }
    }
    class Person
    {

        int _sum;
        public Person(int sum)
        {
            _sum = sum;
        }
        public int CurrentSum
        {
            get { return _sum; }
        }
        public void Salary(int sum)
        {
            _sum += sum;
            _salary?.Invoke(this, new PersonEventArgs($"Была получена зарплата {sum}", sum));
        }
        public delegate void PersonStateHandler(object sender, PersonEventArgs e);
        public event PersonStateHandler _payfine;
        public event PersonStateHandler _salary;

        public void PayFine(int sum)
        {
            if (sum < _sum)
            {
                _sum -= sum;
                _payfine?.Invoke(this, new PersonEventArgs($"Вы заплатили штраф {sum}", sum));
            }
        }
        public static void Operation(Func<string> editor)
        {
            if (StringEdit.str != null)
            {
                editor();
            }
        }
        static void Main(string[] args)
        {
            
            Person student = new Person(200);
            Person worker = new Person(200);
            Person teacher = new Person(200);
            worker._salary += (sender, e) => {

                 Console.WriteLine(e.Message);
            };
            worker._payfine += (sender, e) => {
                Console.WriteLine(e.Message);
            };
            teacher._salary += (sender, e) =>
            {
                Console.WriteLine($"ПОЗДРАВЛЯЮ С ЗАРПЛАТОЙ!");
                Console.WriteLine(e.Message);
            };
            Console.WriteLine($"Нынешний баланс студента составляет {student.CurrentSum}");
            worker.Salary(Convert.ToInt32(Console.ReadLine()));
            worker.PayFine(250);
            Console.WriteLine($"Нынешний баланс рабочего составляет {worker.CurrentSum}");
            teacher.Salary(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine($"Нынешний баланс учителя составляет {teacher.CurrentSum}");
            Func<string> editor;

            new StringEdit("И наиболее используемыми, с которыми часто приходится сталкиваться, являются Action, Predicate и Func.");
            editor = StringEdit.DeletingPunctuationMarks;
            editor += StringEdit.ToLowerCase;
            editor += StringEdit.NumberAdding;
            editor += StringEdit.SpaceDeleting;
            editor += StringEdit.ToUpperCase;

            Operation(editor);  
            Console.WriteLine($"Окнончательный результат: {StringEdit.str}");

          

            Console.ReadLine();
        }


    }
}

