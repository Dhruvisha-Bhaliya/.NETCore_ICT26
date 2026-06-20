using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Content
    {
        protected int Id;         
        public string Title { get; set; }   
        public Content(int id, string title) 
        {
            Id = id;
            Title = title;
        }

        public virtual void Show() 
        {
            Console.WriteLine($"{Id} - {Title}");
        }
    }
}
