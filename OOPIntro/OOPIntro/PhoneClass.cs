using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class PhoneClass
    {
        public PhoneClass(string number, string model, string weigth) : this(number, model)
        {
            Weigth = weigth;
        }

        public PhoneClass(string number, string model)
        {
            Number = number;
            Model = model;
        }

        public PhoneClass()
        {
        }
        public string Number 
        {
            get => _number;
            set
            {
                var reg1 = new Regex(@"\D");
                string res = reg1.Replace(value, "");
                if(res.Length != 12)
                {
                    this._number = "Неизветный номер";
                }
                else
                {
                    var reg2 = new Regex(@"^375(\d{2})(\d{3})(\d{2})(\d{2})$");
                    Match match = reg2.Match(res);
                    if (match.Success)
                    {
                        if (Array.Exists(new string[] { "29", "44", "25", "17" }, el => el == match.Groups[1].Value))
                        {
                            this._number = $"+375({match.Groups[1].Value}){match.Groups[2].Value}-{match.Groups[3].Value}-{match.Groups[4].Value}";
                        }
                        else
                        {
                            this._number = "Неизветный номер";
                        }
                    }
                    else
                    {
                        this._number = "Неизветный номер";
                    }
                }
            }
        }

        public string Model
        {
            get => _model;
            set => _model = string.IsNullOrEmpty(value) ? " " : value;
        }

        public string Weigth
        {
            get => _weight;
            set => _weight = string.IsNullOrEmpty(value) ? " " : value;
        }

        public void RecieveCall(string callerName)
        {
            Console.WriteLine($"Звонит {callerName}");
        }

        public void RecieveCall(string callerName, string callerNumber)
        {
            Console.WriteLine($"Звонит {callerName} с номера {callerNumber}");
        }

        public string GetNumber()
        {
            return this._number;
        }

        public void SendMessage(params string[] numbers)
        {
            Console.Write("\tПолучатели сообщений: ");
            Array.ForEach(numbers, number => Console.Write(number + "; "));
        }

        #region private

        private string _number;
        private string _model;
        private string _weight;

        #endregion
    }
}
