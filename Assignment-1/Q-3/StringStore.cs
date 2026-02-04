using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Q_3
{
    class StringStore : IStore<string>
    {
        public void Save(string data)
        {
            Console.WriteLine($"String: {data}");
        }
    }
}