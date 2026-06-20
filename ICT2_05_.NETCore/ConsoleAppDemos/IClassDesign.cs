using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemos
{
    internal interface IClassDesign
    {
        string Name { get; set; }
        void Display();
        string GetData();
    }
}
