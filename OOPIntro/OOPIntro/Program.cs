using static System.Net.Mime.MediaTypeNames;

namespace OOPIntro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите номер задания:\n" +
                    "\t1. Задание 1.\n" +
                    "\t2. Задание 2.\n" +
                    "Нажмите 'q' чтобы завершить работу.");

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Task1();
                        WaitFun();
                        break;
                    case '2':
                        Console.Clear();
                        Task2();
                        WaitFun();
                        break;
                    case 'q':
                    case 'Q':
                        Console.WriteLine("Завершение работы.");
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void WaitFun()
        {
            Console.WriteLine("\n\nНажмите любую клавишу чтобы продолжить.");

            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                default:
                    Console.Clear();
                    return;
            }
        }

        static void Task1()
        {
            PhoneClass phone1 = new PhoneClass();
            phone1.Number = "+375 (29) 111-00-11";
            phone1.Model = "iPhone 17";
            phone1.Weigth = "177г";

            PhoneClass phone2 = new PhoneClass();
            phone2.Number = "+375 (29) 222-00-22";
            phone2.Model = "Samsung S25";
            phone2.Weigth = "162г";

            PhoneClass phone3 = new PhoneClass();
            phone3.Number = "+375 (29) 333-00-33";
            phone3.Model = "Xiaomi 15T";
            phone3.Weigth = "194г";

            PrintPhoneParams(phone1, nameof(phone1));
            PrintPhoneParams(phone2, nameof(phone2));
            PrintPhoneParams(phone3, nameof(phone3));

            PrintByBaseMethods(phone1, nameof(phone1));
            PrintByBaseMethods(phone2, nameof(phone2));
            PrintByBaseMethods(phone3, nameof(phone3));

            PhoneClass phone4 = new PhoneClass("+375 (29) 444-00-44", "POCO F7", "215.7г");
            PrintPhoneParams(phone4, nameof(phone4));

            PrintByOverloadedMethod(phone1, nameof(phone1), phone2);
            PrintByOverloadedMethod(phone2, nameof(phone2), phone3);
            PrintByOverloadedMethod(phone3, nameof(phone3), phone4);
            PrintByOverloadedMethod(phone4, nameof(phone4), phone1);

            Console.WriteLine($"\n{nameof(phone1)}:");
            phone1.SendMessage(phone2.GetNumber(), phone3.GetNumber(), phone4.GetNumber());
        }
        static void PrintPhoneParams(PhoneClass phone, string objectName)
        {
            Console.WriteLine($"{objectName}:\n" +
                $"\tМодель: {phone.Model}\n" +
                $"\tВес: {phone.Weigth}\n" +
                $"\tНомер телефона: {phone.Number}");
        }

        static void PrintByBaseMethods(PhoneClass phone, string objectName)
        {
            Console.Write($"{objectName}, номер телефона {phone.GetNumber()}: ");
            phone.RecieveCall("Антон");
        }

        static void PrintByOverloadedMethod(PhoneClass userPhone, string objectName, PhoneClass callerPhone)
        {
            Console.Write($"{objectName}: ");
            userPhone.RecieveCall("Антон", callerPhone.GetNumber());
        }

        static void Task2()
        {
            Patient patient1 = new Patient("Алексей");
            Patient patient2 = new Patient("Николай");
            Patient patient3 = new Patient("Иван");
            Patient patient4 = new Patient("Даниил");

            TreatmentPlan plan1 = new TreatmentPlan(1, "Хирургическое вмешательство");
            TreatmentPlan plan2 = new TreatmentPlan(2, "Стоматологическое лечение");
            TreatmentPlan plan3 = new TreatmentPlan(3, "Выполнить осмотр");
            TreatmentPlan plan4 = new TreatmentPlan(999, "Неизвестное лечение");

            patient1.AddPlan(plan1);
            patient2.AddPlan(plan2);
            patient3.AddPlan(plan3);
            patient4.AddPlan(plan4);

            patient1.AppointDoctor();
            patient2.AppointDoctor();
            patient3.AppointDoctor();
            //patient4.AppointDoctor();

            patient1.PerformTreatment();
            patient2.PerformTreatment();
            patient3.PerformTreatment();
            patient4.PerformTreatment();
        }
    }
}
