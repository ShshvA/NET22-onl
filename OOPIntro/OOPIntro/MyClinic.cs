using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class Surgeon : IDoctor
    {
        public Surgeon(string name) 
        {
            this._name = name;
        }

        public Surgeon() { }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public void Treat()
        {
            Console.WriteLine($"Хирург {Name} проводит операции.");
        }

        private string _name;
    }

    public class Dentist : IDoctor
    {
        public Dentist(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public void Treat()
        {
            Console.WriteLine($"Дантист {Name} лечит зубы.");
        }

        private string _name;
    }

    public class Therapist : IDoctor
    {
        public Therapist(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public void Treat()
        {
            Console.WriteLine($"Терапевт {Name} проводит осмотры.");
        }

        private string _name;
    }

    public class TreatmentPlan
    {
        public TreatmentPlan(int code, string description)
        {
            this._code = code;
            this._description = description;
        }

        public int Code 
        { 
            get => this._code; 
            set => this._code = value; 
        }

        public string Description
        {
            get => this._description;
            set => this._description = value;
        }

        private int _code;
        private string _description;
    }

    public class Patient
    {
        public Patient(string name)
        {
            this._name = name;
        }

        public string Name
        {
            get => this._name;
            set => this._name = value;
        }

        public IDoctor Doctor
        {
            get => this._doctor;
            set => this._doctor = value;
        }

        public TreatmentPlan Plan
        {
            get => this._plan;
            set => this._plan = value;
        }

        public void AddPlan( TreatmentPlan plan)
        {
            Plan = plan;
            Console.WriteLine($"Пациенту {Name} назначен план лечения:\n" +
                $"\t {plan.Description}, код: {plan.Code}\n");
        }

        public void AppointDoctor()
        {
            if (Plan == null)
            {
                Console.WriteLine($"Пациенту {Name} план лечения не назначен.\n");
            }
            else
            {
                switch (Plan.Code)
                {
                    case 1:
                        _doctor = new Surgeon("Доктор Хирургин");
                        break;
                    case 2:
                        _doctor = new Dentist("Доктор Зубов");
                        break;
                    default:
                        _doctor = new Therapist("Доктор Осталкин");
                        break;
                }

                Console.WriteLine($"Пациенту {Name} назначен {Doctor.Name}\n");
            }            
        }

        public void PerformTreatment()
        {
            if (Doctor == null)
            {
                Console.WriteLine($"Пациенту {Name} не назначен врач!");
                return;
            }

            Console.Write($"Пациент {Name}: \n\t");
            Doctor.Treat();
        }

        private IDoctor _doctor;
        private TreatmentPlan _plan;

        private string _name;
    }
}
