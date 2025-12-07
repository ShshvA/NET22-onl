using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAccountingSystem
{
    internal class FinancialInvoice : Document
    {

        public FinancialInvoice()
        {
            base.Type = "EmployeeContract";
        }

        public FinancialInvoice(double monthAmount, int code) : this()
        {
            TotalMonthAmount = double.IsNegative(monthAmount) ? 0 : monthAmount;
            DepartmentCode = int.IsNegative(code) ? 0 : code;
        }

        public override void GetDocInfo()
        {
            base.GetDocInfo();
            Console.WriteLine($"\t Итоговая сумма за месяц: {TotalMonthAmount} \n" +
                $"\t Код департамента: {(DepartmentCode == 0 ? "Отсутствует" : DepartmentCode)} \n");
        }

        public double TotalMonthAmount { get; set; } = 0;

        public int DepartmentCode { get; set; } = 0;
    }
}
