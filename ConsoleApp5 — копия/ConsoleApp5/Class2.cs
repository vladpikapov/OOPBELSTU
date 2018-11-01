using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
   class MoneyException : Exception
    {
        
        public int Money { get; set; }
        public MoneyException(string message,int value)
       : base(message)
        {
            Money = value;
        }
    }
    class StrException : Exception
    {
        public StrException(string message)
       : base(message)
        { }
    }
    class ManException : Exception
    {
        public ManException(string message)
       : base(message)
        { }
    }
    class Man
    {
        private int money;
        private string name;
        private int age;
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 18)
                    throw new ManException("Too small!");
                else
                    age = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                if (value.Length <2)
                    throw new StrException("Enter name!");
                else
                    name = value;
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value < 100)
                {
                    throw new MoneyException("Poor", value);
                }
                else
                    money = value;
            }
        }
    }
    
    }
