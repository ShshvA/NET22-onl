namespace CompanyEmployees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployee[] employees = new IEmployee[]
                {
                    new Director("Иван"),
                    new Worker("Николай"),
                    new Accountant("Никита"),
                    new Worker("Анна"),
                    new Worker("Петр"),
                    new Accountant("Жанна")
                };

            foreach (var employee in employees)
            {
                employee.PrintPosition();
            }

        }
    }
}
