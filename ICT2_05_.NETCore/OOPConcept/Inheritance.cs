using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept
{
    internal class Teacher : Staff
    {
        public override void Work()
        {
            Console.WriteLine("Teacher teaches Students");
        }
    }
}
