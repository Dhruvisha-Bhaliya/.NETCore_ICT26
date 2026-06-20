using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    abstract class DataStore<T>
    {
        protected T data;

        public abstract void Save(T value);
        public abstract T Load();

        public void DisplayType()
        {
            Console.WriteLine("Data type is : " + typeof(T));
        }
    }
}
