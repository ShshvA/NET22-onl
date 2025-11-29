namespace ClassesPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите номер задания:\n" +
                    "\t1. Основное задание.\n" +
                    "\t2. Дополнительное задание 1.\n" +
                    "\t3. Дополнительное задание 2.\n" +
                    "Нажмите 'q' чтобы завершить работу.");

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        MainTask();
                        WaitFun();
                        break;
                    case '2':
                        Console.Clear();
                        AdditionalTask1();
                        WaitFun();
                        break;
                    case '3':
                        Console.Clear();
                        AdditionalTask2();
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

            static void MainTask()
            {
                CreditCardClass card1 = new CreditCardClass("BY01XXXX111000111", 32.30);
                CreditCardClass card2 = new CreditCardClass("BY02XXXX222000222", 54.22);
                CreditCardClass card3 = new CreditCardClass("BY03XXXX333000333", 6.23);

                card1.GetInfo();
                card2.GetInfo();
                card3.GetInfo();

                Console.WriteLine();

                card1.TopUpBalance(23.1);
                card2.TopUpBalance(12.33);
                card3.WithdrawMoney(32.2);
                card3.WithdrawMoney(1.42);

                Console.WriteLine();

                card1.GetInfo();
                card2.GetInfo();
                card3.GetInfo();
            }

            static void AdditionalTask1()
            {
                RAM ram1 = new RAM("Samsung", 32);
                ram1.GetInfo();
                Console.WriteLine();

                RAM ram2 = new RAM("Kingston", 64); 
                ram2.GetInfo();
                Console.WriteLine();

                HDD hdd1 = new HDD("Wester Digital", 1024, HDD.HDDType.HDD_EXTERNAL);
                hdd1.GetInfo();
                Console.WriteLine();

                HDD hdd2 = new HDD("Seagate", 2048, HDD.HDDType.HDD_INTERNAL);
                hdd2.GetInfo();
                Console.WriteLine();

                Computer pc1 = new Computer(2142.4, "FLD", ram1, hdd1);
                pc1.GetInfo(nameof(pc1));
                Console.WriteLine();

                Computer pc2 = new Computer(4211.54, "JDG", ram2, hdd2);
                pc2.GetInfo(nameof(pc2));
                Console.WriteLine();

                Computer pc3 = new Computer(4242.2, "SKK");
                pc3.GetInfo(nameof(pc3));
                Console.WriteLine();
            }

            static void AdditionalTask2()
            {

            }
        }
    }
}
