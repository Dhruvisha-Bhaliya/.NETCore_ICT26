using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class LiveCourse : Course
    {
        public int LiveStudents { get; set; }

        public LiveCourse(int id, string title, int duration, int students)
            : base(id, title, duration)
        {
            LiveStudents = students;
        }

        public override void Show()
        {
            Console.WriteLine($"{Id} - {Title} - Live: {LiveStudents}");
        }
    }
}