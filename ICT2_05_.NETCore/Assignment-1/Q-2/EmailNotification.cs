using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.Q_2
{
    class EmailNotification : INotification
    {
        public void Send()
        {
            Console.WriteLine("Email Sent");
        }
    }
}