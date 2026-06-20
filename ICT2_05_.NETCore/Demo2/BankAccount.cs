using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    internal class BankAccount
    {
        private double balance;


        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposit Successful.");
            }
            else
            {
                Console.WriteLine("Invalid Deposte amount");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine("Withdraw Successful");
            }
            else
            {
                Console.WriteLine("Invalid Balace");
            }
        }

        public double GetBalance() { return balance; }
    }
}
