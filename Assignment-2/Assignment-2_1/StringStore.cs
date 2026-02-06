using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_1
{
    class StringStore : DataStore<string>
    {
        public override void Save(string value)
        {
            data = value;
        }

        public override string Load()
        {
            return data;
        }
    }
}
