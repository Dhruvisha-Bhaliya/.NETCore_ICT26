using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Q_3
{
    interface IStore<T>
    {
        void Save(T data);
    }
}