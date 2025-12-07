using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAccountingSystem
{
    internal class EmployeeContract : Document
    {
        public EmployeeContract()
        {
            base.Type = "EmployeeContract";
        }

        public EmployeeContract(string name, DateTime dateTime) : this()
        {
            Name = string.IsNullOrWhiteSpace(name) ? "Неизвестно" : name;
            ContractEndDate = dateTime < DateTime.Now ? null : dateTime;
        }

        public override void GetDocInfo()
        {
            base.GetDocInfo();
            Console.WriteLine($"\t Имя сотрудника: {Name} \n" +
                $"\t Дата окончания контракта: {(!ContractEndDate.HasValue ? "Неизвестно" : ContractEndDate.Value.ToString("dd.MM.yyyy HH:mm:ss"))} \n");
        }

        public string Name { get; set; } = "Неизвестно";

        public DateTime? ContractEndDate { get; set; } = null;
    }
}
