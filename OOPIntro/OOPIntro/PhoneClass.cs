using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class PhoneClass
    {
        public PhoneClass(string number, string model, string weigth) : this(number, model)
        {
            this._weight = weigth;
        }

        public PhoneClass(string number, string model)
        {
            this._number = number;
            this._model = model;
        }

        public PhoneClass()
        {
        }
        public string Number 
        {
            get => _number;
            set => _number = string.IsNullOrEmpty(value) ? " " : value;
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
