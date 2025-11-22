namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int operation = GetOperationType();

                double firstNumber = GetInputValue("Введите первое число: ");
                double secondNumber = GetInputValue("Введите второе число: ");

                PrintOperationResult(operation, firstNumber, secondNumber);

                Console.WriteLine("Нажмите любую клавишу для нового расчета или клавишу 'q' чтобы завершить работу...");
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
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

        static int GetOperationType()
        {
            Console.WriteLine("Приложение SimpleCalculator, выполняет основные арифметические операции:");
            Console.WriteLine("\t1. Сложение");
            Console.WriteLine("\t2. Вычитание");
            Console.WriteLine("\t3. Деление");
            Console.WriteLine("\t4. Умножение");
            Console.WriteLine("\t5. Процент от числа");
            Console.WriteLine("\t6. Квадратный корень числа\n");

            while (true)
            {
                Console.Write("Выберите действие (ввод номера действия): ");
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                    Console.WriteLine("Ошибка ввода. Введите целочисленное число.");
            }
        }

        static double GetInputValue(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double result))
                    return result;
                else
                    Console.WriteLine("Ошибка ввода. Введите число.");
            }
        }

        static void PrintOperationResult(int operation, double firstNumber, double secondNumber)
        {
            Console.WriteLine($"\nПервое число - {firstNumber}.\nВторое число - {secondNumber}.");
            switch (operation)
            {
                case 1:
                    Console.WriteLine("Операция - Сложение.\nРезультат операции:");
                    Console.WriteLine($"\t{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");
                    break;
                case 2:
                    Console.WriteLine("Операция - Вычитание.\nРезультат операции:");
                    Console.WriteLine($"\t{firstNumber} - {secondNumber} = {firstNumber - secondNumber}");
                    break;
                case 3:
                    Console.WriteLine("Операция - Деление.\nРезультат операции:");
                    Console.WriteLine($"\t{firstNumber} / {secondNumber} = {((secondNumber == 0) ? "Ошибка, деление на нуль!" : firstNumber / secondNumber)}");
                    break;
                case 4:
                    Console.WriteLine("Операция - Умножение.\nРезультат операции:");
                    Console.WriteLine($"\t{firstNumber} * {secondNumber} = {firstNumber * secondNumber}");
                    break;
                case 5:
                    Console.WriteLine("Операция - Процент от числа.\nРезультат операции:");
                    CalcPercentageOf(firstNumber, secondNumber);
                    CalcPercentageOf(secondNumber, firstNumber);
                    break;
                case 6:
                    Console.WriteLine("Операция - Квадратный корень числа.\nРезультат операции:");
                    CalcSquareRootOf(firstNumber);
                    CalcSquareRootOf(secondNumber);
                    break;
                default:
                    break;
            }
        }

        static void CalcPercentageOf(double firstNumber, double secondNumber)
        {
            Console.WriteLine($"\tЧисло {firstNumber} от числа {secondNumber} составляет {((secondNumber == 0) ? " - Ошибка! Деление на нуль." : (firstNumber / secondNumber) * 100 + "%")}");
        }

        static void CalcSquareRootOf(double number)
        {
            Console.WriteLine($"\t√{number} = {((number < 0) ? $"Ошибка! Квадратный корень из отрицательного числа {number} не вычисляется" : Math.Sqrt(number))}");
        }
    }
}
