namespace Demo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           BankAccount account = new BankAccount();
            int choice;

            do
            {
                Console.WriteLine("\n--Bank Menu--");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Check Balance");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice: ");

                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter deposite amount: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;

                       case 2:
                        Console.WriteLine("Enter withdraw amount: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        account.Withdraw(withdrawAmount);
                        break; 
                    
                       case 3:
                        Console.WriteLine("Current Balance: " + account.GetBalance());
                        break;

                        case 4:
                        Console.WriteLine("Thank You!");
                        break;

                        default:
                        Console.WriteLine("Invalid choice.");
                        break ;
                }

            } while (choice != 4);
        }
    }
}
