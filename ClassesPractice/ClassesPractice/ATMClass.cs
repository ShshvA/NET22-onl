using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPractice
{
    public class ATMClass
    {
        public ATMClass(int amountBancnotes20, int amountBancnotes50, int amountBancnotes100)
        {
            _amountBancnotes20 = amountBancnotes20;
            _amountBancnotes50 = amountBancnotes50;
            _amountBancnotes100 = amountBancnotes100;
        }

        public int AmountBancnotes20
        {
            get => _amountBancnotes20;
        }

        public int AmountBancnotes50
        {
            get => _amountBancnotes50;
        }

        public int AmountBancnotes100
        {
            get => _amountBancnotes100;
        }


        public void AddMoney(int bancnote)
        {
            switch(bancnote)
            {
                case 20:
                    _amountBancnotes20++;
                    break;
                case 50:
                    _amountBancnotes50++;
                    break;
                case 100:
                    _amountBancnotes100++;
                    break;
                default:
                    Console.WriteLine($"Номинал {bancnote} не принимается. Заберите купюру из купюроприемника");
                    break;
            }
        }

        public bool IsAvailableAmount(int amount)
        {
            int count20, count50, count100;
            count20 = _amountBancnotes20;
            count50 = _amountBancnotes50;
            count100 = _amountBancnotes100;

            while (amount > 0)
            {
                if (amount >= 100 && count100 > 0)
                {
                    amount -= 100;
                    count100--;
                }
                else if (amount >= 50 && count50 > 0)
                {
                    amount -= 50;
                    count50--;
                }
                else if (amount >= 20 && count20 > 0)
                {
                    amount -= 20;
                    count20--;
                }
                else
                {
                    return false;
                }

                if (amount == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public (bool isSuccess, int count20, int count50, int count100 ) WithdrawMoney(int amount)
        {
            int count20, count50, count100;
            count20 = count50 = count100 = 0;
            bool isSuccess = false;
            while (amount > 0)
            {
                if (amount >= 100 && _amountBancnotes100 > 0)
                {
                    amount -= 100;
                    count100++;
                    _amountBancnotes100--;
                }
                else if (amount >= 50 && _amountBancnotes50 > 0)
                {
                    amount -= 50;
                    count50++;
                    _amountBancnotes50--;
                }
                else if (amount >= 20 && _amountBancnotes20 > 0)
                {
                    amount -= 20;
                    count20++;
                    _amountBancnotes20--;
                }
                else
                {
                    isSuccess = false;
                    break;
                }

                if (amount == 0)
                {
                    isSuccess = true;
                    break;
                }
            }

            return (isSuccess, count20, count50, count100);
        }

        private int _amountBancnotes20;
        private int _amountBancnotes50;
        private int _amountBancnotes100;
    }
}
