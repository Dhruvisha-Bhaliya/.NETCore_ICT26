using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDemos
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public string Name
        {
             get => EmployeeName;
            set => EmployeeName = value;
        }

        public void Display()
        {
            Console.WriteLine("ID: "+EmployeeID+"Name: "+EmployeeName);
        }

        public string GetData()
        {
            return "ID: "+EmployeeID+ "Name: "+EmployeeName;
        }
    }
}
