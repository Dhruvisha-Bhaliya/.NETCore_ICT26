using Assignment_1.Q_2;
using Assignment_1.Q_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static void Main1(string[] args)
        {
            List<Content> list = new List<Content>();
            int choice;

            do
            {
                Console.WriteLine("\n1. Add Course");
                Console.WriteLine("2. Add Live Course");
                Console.WriteLine("3. Display All");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Course ID: ");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string ctitle = Console.ReadLine();
                        Console.Write("Enter Duration (hrs): ");
                        int dur = Convert.ToInt32(Console.ReadLine());

                        list.Add(new Course(cid, ctitle, dur));
                        Console.WriteLine("Course Added");
                        break;

                    case 2:
                        Console.Write("Enter Course ID: ");
                        int lid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        string ltitle = Console.ReadLine();
                        Console.Write("Enter Duration (hrs): ");
                        int ldur = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Live Students: ");
                        int students = Convert.ToInt32(Console.ReadLine());

                        list.Add(new LiveCourse(lid, ltitle, ldur, students));
                        Console.WriteLine("Live Course Added");
                        break;

                    case 3:
                        Console.WriteLine("\n--- Stored Courses ---");
                        foreach (Content c in list)
                        {
                            c.Show();
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }

            } while (choice != 4);
        }

        static void Main2(string[] args)
        {
            INotification notify;

            notify = new EmailNotification();
            notify.Send();  

            notify = new SmsNotification();
            notify.Send();  
        }
        static void Main(string[] args) { 

        IStore<int> intStore;
        IStore<string> stringStore;

        intStore = new IntStore();
        intStore.Save(10);    

        stringStore = new StringStore();
        stringStore.Save("C#");

        }
    }
}
