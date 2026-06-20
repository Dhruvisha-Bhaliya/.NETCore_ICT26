using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPConcept
{
    internal class student
    {
        private int marks;
        public int Marks 
        { 
            get 
            { 
                return marks; 
            } 
            set 
            { 
                if (value >= 0 && value <= 100)
                    marks = value;
            } 
        }

        public void ShowResult()
        {
            Console.WriteLine("Student Marks: " + marks);
        }
    }
}
