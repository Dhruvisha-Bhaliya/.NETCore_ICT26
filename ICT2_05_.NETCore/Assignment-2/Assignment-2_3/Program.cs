using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library<Book> library = new Library<Book>();

            library.AddBook(new Book("101", "C# Basics", "John", 2020));
            library.AddBook(new Book("102", "ASP.NET Core", "Smith", 2021));
            library.AddBook(new Book("103", "Data Structures", "John", 2022));

            Book b1 = library["C# Basics"];
            Console.WriteLine("Search by Title:");
            Console.WriteLine($"{b1.ISBN}  {b1.Title}  {b1.Author}  {b1.Year}");

            Console.WriteLine();

            Book b2 = library["John", 2022];
            Console.WriteLine("Search by Author and Year:");
            Console.WriteLine($"{b2.ISBN}  {b2.Title}  {b2.Author}  {b2.Year}");

            Console.ReadLine();
        }
    }
}
