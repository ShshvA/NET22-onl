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

            }

            static void AdditionalTask2()
            {

            }
        }
    }
}
