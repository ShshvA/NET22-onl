using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesPractice
{
    public class Computer
    {
        public Computer(double currency, string model, RAM ram, HDD hdd )
        {
            this.Currency = currency;
            this.Model = model;
            this.RAM = ram;
            this.HDD = hdd;
        }
        public Computer( double currency, string model)
        {
            this.Currency = currency;
            this.Model = model;
            this.RAM = new RAM();
            this.HDD = new HDD();            
        }

        public double Currency 
        { 
            get => this._currency;
            set => this._currency = value; 
        }

        public string Model
        {
            get => this._model;
            set => this._model = value;
        }

        public RAM RAM
        {
            get => this._ram;
            set => this._ram = value;
        }

        public HDD HDD
        {
            get => this._hdd;
            set => this._hdd = value;
        }

        public void GetInfo(string pcName)
        {
            Console.WriteLine($"Информация о компьютере {pcName}:\n" +
                $"\tСтоимость: {Currency}\n" +
                $"\tМодель: {Model}");
            this.RAM.GetInfo();
            this.HDD.GetInfo();
        }

        private double _currency;
        private string _model;
        private RAM _ram;
        private HDD _hdd;
    }

    public struct RAM
    {
        public RAM(string name, int volume)
        {
            Name = name;
            Volume = volume;
        }
        public RAM() { }

        public string Name 
        {
            get => this._name;
            set => this._name = value;
        }

        public int Volume
        {
            get => this._volume;
            set => this._volume = value;
        }

        public void GetInfo()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Volume != 0)
            {
                Console.WriteLine($"RAM: \n" +
                    $"\tНазвание: {Name}\n" +
                    $"\tОбъем: {Volume}");
            }
            else
            {
                Console.WriteLine($"RAM: Неизвестно.");
            }
        }

        private string _name;
        private int _volume;
    }

    public class HDD
    {
        public HDD(string name, int volume, HDDType type)
        {
            Name = name;
            Volume = volume;
            Type = type;
        }
        public HDD() { }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public int Volume
        {
            get => this._volume;
            set => this._volume = value;
        }

        public HDDType Type
        {
            get => this._type;
            set => this._type = value;
        }

        public void GetInfo()
        {
            if (!string.IsNullOrWhiteSpace(Name) && Volume != 0 && Type != HDDType.HDD_UNKNOWN)
            {
                Console.WriteLine($"HDD: \n" +
                $"\tНазвание: {Name}\n" +
                $"\tОбъем: {Volume}\n" +
                $"\tТип: {GetType(_type)}");
            }
            else
            {
                Console.WriteLine($"HDD: Неизвестно.");
            }
        }

        public string GetType(HDDType type)
        {
            switch (type)
            {
                case HDDType.HDD_EXTERNAL:
                    return "Внешний HDD";
                case HDDType.HDD_INTERNAL:
                    return "Внутренний HDD";
                default:
                    return "Неизвестный HDD";
            }
        }

        public enum HDDType: int
        {
            HDD_UNKNOWN = 0,
            HDD_EXTERNAL = 1,
            HDD_INTERNAL = 2
        }

        private string _name;
        private int _volume;
        private HDDType _type;
    }
}
