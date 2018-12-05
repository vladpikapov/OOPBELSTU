using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    class ProgramArray
    {
       public delegate void SomeArrayHandler();
        static void Main(string[] args)
        {
            
            SomeArrayHandler someArrayHandler = PrintArray;
            someArrayHandler += PrintSortedList;
            someArrayHandler += PrintSomeClass;
            someArrayHandler += PrintObservList;
            someArrayHandler();
            Console.ReadKey();
        }
        public static void PrintObservList()
        {
            ObservableCollection<Printer> SomeObserv = new ObservableCollection<Printer>();
               
          
            SomeObserv.CollectionChanged += PrinterCollectionChanged;
            SomeObserv.Add(new Printer { Age = 20, Cost = 45000 });
            SomeObserv.Add(new Printer { Age = 10, Cost = 5000 });
            SomeObserv.Add(new Printer { Age = 50, Cost = 4000 });
            SomeObserv.Add(new Printer { Age = 5, Cost = 4520 });
            foreach (Printer p in SomeObserv)
            {
                Console.WriteLine("Age: " + p.Age + "--" + "Cost: " + p.Cost);
            }
            SomeObserv.RemoveAt(0);
            foreach (Printer p in SomeObserv)
            {
                Console.WriteLine("Age: " + p.Age + "--" + "Cost: " + p.Cost);
            }
        }
        public static void PrinterCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action) {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine("Был добавлен объект");
                    
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine("Был удалён объект");
                    break;

            }
        }
        public static void PrintSomeClass()
        {
           
            SortedList<int, Printer> keyPrinter = new SortedList<int, Printer>();
            keyPrinter.Add(1, new Printer());
            keyPrinter.Add(2, new Printer());
            keyPrinter.Add(3, new Printer());
            foreach(KeyValuePair<int,Printer> element in keyPrinter)
            {
                Console.WriteLine("Введите возраст устройства: ");
                element.Value.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите цену устройства: ");
                element.Value.Cost = Convert.ToInt32(Console.ReadLine());
            }

            foreach (KeyValuePair < int,Printer> element in keyPrinter)
            {
                Console.WriteLine("Ключ: " + element.Key);
                Console.WriteLine("Возраст: " + element.Value.Age + " Цена: "+ element.Value.Cost);
            }

            Console.WriteLine("Введите количество элементов для удаления: ");
            int del = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < del; i++)
            {
                keyPrinter.Remove(i + 1);
            }
            foreach (KeyValuePair<int, Printer> element in keyPrinter)
            {
                Console.WriteLine("Ключ: " + element.Key);
                Console.WriteLine("Возраст: " + element.Value.Age + " Цена: " + element.Value.Cost);
            }
            List<Printer> listOfPrinter = new List<Printer>();
            for(int i = 0; i < keyPrinter.Count; i++)
            {
                listOfPrinter.Add(keyPrinter.Values[i]);
            }
            Console.WriteLine("Элементы листа с объектами: ");
            foreach(Printer p in listOfPrinter)
            {
                Console.WriteLine("Возраст: " + p.Age + " Цена: " + p.Cost);
            }
            listOfPrinter.Sort();
            Console.WriteLine("Элементы листа после сортировки: ");
            foreach (Printer p in listOfPrinter)
            {
                Console.WriteLine("Возраст: " + p.Age + " Цена: " + p.Cost);
            }

        }
        public static void PrintSortedList()
        {
            SortedList<int, char> keyValues = new SortedList<int, char>
            {
                { 1, 'a' },
                { 2, 'b' },
                { 3, 'c' },
                { 4, 'd' },
                { 5, 'e' }
            };
            Console.WriteLine("Элементы: ");
            for(int i = 0; i < keyValues.Count; i++)
            {
                Console.Write(keyValues[i+1] + " ");
                
            }
            Console.WriteLine();
            Console.WriteLine("Введите количество элементов для удаления: ");
            int x = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < x ; i++)
            {
                keyValues.Remove(i+1);

            }
            Console.WriteLine("Элементы: ");
            for (int i = 0; i < keyValues.Count; i++)
            {
                Console.Write(keyValues.Values[i] + " ");

            }
            Console.WriteLine();
            keyValues.Add(6,'f');
            keyValues.Add(7, 'g');
            keyValues.Add(8, 'h');
            for(int i = 0; i < keyValues.Count; i++)
            {
                Console.Write(keyValues.Values[i] + " ");
            }
            Console.WriteLine();
            List<char> list = new List<char>();
            for (int i = 0; i < keyValues.Count; i++)
                list.Add(keyValues.Values[i]);
            Console.WriteLine("Элементы списка: ");
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Присутствует ли данный элемент: " + list.Contains('g'));

        }
        public static void PrintArray()
        {
            ArrayList arrayList = new ArrayList();
            Console.WriteLine("Введите 5 чисел:");
            arrayList.Add(Convert.ToInt32(Console.ReadLine()));
            arrayList.Add(Convert.ToInt32(Console.ReadLine()));
            arrayList.Add(Convert.ToInt32(Console.ReadLine()));
            arrayList.Add(Convert.ToInt32(Console.ReadLine()));
            arrayList.Add(Convert.ToInt32(Console.ReadLine()));
            Console.Write("Введите строку: ");
            arrayList.Add(Console.ReadLine());
            Student student = new Student();
            arrayList.Add(student);
            Console.WriteLine("Удаление элемента: ");
            arrayList.Remove(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Количество элементов: " + arrayList.Count);
            for (int i = 0; i < arrayList.Count; i++)
            {
                Console.Write(arrayList[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Нахождение элемента: ");
            if (arrayList.Contains(Convert.ToInt32(Console.ReadLine())))
            {
                Console.WriteLine("Элемент присутствует!");
            }
            else
            {
                Console.WriteLine("Увы, но такого элемента нет.");
            }

        }
    }
    class Student
    {
        
    }
    class Printer: IComparable<Printer>
    {
        public int CompareTo(Printer obj)
        {
            if (this.Age > obj.Age)
                return 1;
            if (this.Age < obj.Age)
                return -1;
            else
                return 0;
        }
        private int _cost;
        private int _age;
        public int Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
            }
        }
    }
}
