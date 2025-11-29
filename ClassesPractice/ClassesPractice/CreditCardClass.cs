using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPractice
{
    public class CreditCardClass
    {
        public CreditCardClass(string accountNumber, double currentBalance )
        {
            AccountNumber = accountNumber;
            CurrentBalance = currentBalance;
        }

        public string AccountNumber 
        { 
            get => this._accountNumber; 
            set => this._accountNumber = value; 
        }

        public double CurrentBalance
        {
            get => this._currentBalance;
            set => this._currentBalance = value;
        }

        public void TopUpBalance(double amount)
        {
            CurrentBalance += amount;
            Console.WriteLine($"Cчет {AccountNumber}\n\tПополнение +{amount:F2}");
        }

        public void WithdrawMoney(double amount)
        {
            if (amount > CurrentBalance)
            {
                Console.WriteLine($"Cчет {AccountNumber}\n\tНедостаточно средств для списания {amount}");
            }
            else
            {
                CurrentBalance -= amount;
                Console.WriteLine($"Cчет {AccountNumber}\n\tСписание -{amount:F2}");
            }                
        }

        public void GetInfo()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}");
            Console.WriteLine($"\tОстаток средст: {CurrentBalance:F2}");
        }

        private string _accountNumber;
        private double _currentBalance;
    }
}
