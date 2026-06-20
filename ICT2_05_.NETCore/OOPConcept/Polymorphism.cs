using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept
{
    internal class Admin : Staff
    {
        public override void Work()
        {
            Console.WriteLine("Admin manages School Operations.");
        }
    }
}
