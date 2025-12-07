using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    internal class Worker : IEmployee
    {
        public Worker(string name)
        {
            Name = name;
        }

        public void PrintPosition()
        {
            Console.WriteLine($"Имя сотрудника: {Name}\n" +
                $"\t Должность: Рабочий\n");
        }

        public string Name { get; init; }
    }
}
