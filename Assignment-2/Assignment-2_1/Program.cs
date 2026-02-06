using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStore<int> intStore = new IntegerStore();
            intStore.Save(100);
            intStore.DisplayType();
            Console.WriteLine("Stored Integer: " + intStore.Load());

            Console.WriteLine();

            DataStore<string> stringStore = new StringStore();
            stringStore.Save("Hello Generics");
            stringStore.DisplayType();
            Console.WriteLine("Stored String: " + stringStore.Load());

            Console.ReadLine();
        }
    }
}
