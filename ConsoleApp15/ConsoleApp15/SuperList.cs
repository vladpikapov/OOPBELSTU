using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class SuperList<T>:List<T> where T: class
    {
        public static SuperList<T> operator +(SuperList<T> m,T obj)
        {
            if (m.Count <= 3)
            {
               
                m.Add(obj);
            }
            else
            {
                throw new IndexOutOfRangeException("БОЛЬШЕ 3!!!");
            }
            return m;
        }
    }
}
