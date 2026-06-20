using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Course : Content
    {
        public int Duration { get; set; }

        public Course(int id, string title, int duration)
            : base(id, title)
        {
            Duration = duration;
        }

        public override void Show()
        {
            Console.WriteLine($"{Id} - {Title} - {Duration} hrs");
        }
    }
}