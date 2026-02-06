using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_3
{
    class Library<T> where T : Book
    {

        private List<T> books = new List<T>();

        public void AddBook(T book)
        {
            books.Add(book);
        }

        public T this[string title]
        {
            get
            {
                foreach (T book in books)
                {
                    if (book.Title == title)
                        return book;
                }
                return null;
            }
        }

        public T this[string author, int year]
        {
            get
            {
                foreach (T book in books)
                {
                    if (book.Author == author && book.Year == year)
                        return book;
                }
                return null;
            }
        }
    }
}
