using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_3
{
    class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Year { get; set; }


        public Book(string iSBN, string title, string author, int year)
        {
            ISBN = iSBN;
            Title = title;
            Author = author;
            Year = year;
        }
    }
}
