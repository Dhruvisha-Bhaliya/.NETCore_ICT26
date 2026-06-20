using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Q_3
{
    class IntStore : IStore<int>
    {
        public void Save(int data)
        {
            Console.WriteLine($"Int: {data}");
        }
    }
}