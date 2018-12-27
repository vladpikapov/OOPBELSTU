using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    
    class Person
    {
        public delegate void HelpForHandle(string message);
        public event HelpForHandle Temperature;
       
        int _temperature;
        public Person(int temp)
        {
            Temper = temp;
        }
        public int Temper
        {
            get
            {
                return _temperature;
            }
            set
            {
                _temperature = value;
            }
        }
        public Person()
        {

        }
        public void Work(int temper)
        {
            Temper += temper;
            if (Temperature != null)
            {
                Temper -= 5;
               
                Temperature($"Температура была уменьшена");
                
            }
        } 
       
       
    }
   
}
