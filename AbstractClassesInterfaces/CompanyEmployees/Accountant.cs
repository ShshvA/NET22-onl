using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    internal class Accountant : IEmployee
    {
        public Accountant(string name)
        {
            Name = name;
        }

        public void PrintPosition()
        {
            Console.WriteLine($"Имя сотрудника: {Name}\n" +
                $"\t Должность: Бухгалтер\n");
        }

        public string Name { get; init; }
    }
}
