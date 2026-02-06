using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    class IntegerStore : DataStore<int>
    {
        public override void Save(int value)
        {
            data = value;
        }

        public override int Load()
        {
            return data;
        }
    }
}