namespace OOPConcept
{
    internal class Program
    {
        static void Main(string[] args)
        {
         student s = new student();
            s.Marks = 85;
            s.ShowResult();

            // Polymorphism + Abstraction + Inheritance
            Staff staff1 = new Teacher();
            Staff staff2 = new Admin();

            staff1.Work();
            staff2.Work();
        
    }
    }
}
