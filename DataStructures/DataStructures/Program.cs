using System.Collections.Generic;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataStructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PrintWelcomeMessage();                

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        DisplayCycleTask();
                        break;
                    case '2':
                        Console.Clear();
                        DisplayMatrixTask();
                        break;
                    case '3':
                        Console.Clear();
                        DisplayListsTask();
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

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Выберите номер задания для отображения:");
            Console.WriteLine("\t1. Циклы");
            Console.WriteLine("\t2. Матрицы");
            Console.WriteLine("\t3. Листы\n");
            Console.WriteLine("Введите 'q' для завершения работы.");
        }

        static void DisplayCycleTask()
        {
            while (true)
            {
                Console.WriteLine("Задание по циклам.\n");

                int n = GetInputValue("Введите число N: ");

                Console.Write("\nВывод чисел в обратном порядке:\n\t");
                for (int i = n; i > 0; i--)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine();

                Console.Write("\nВывод чисел кратных 7:\n\t");
                int result = 0;
                for (int i = 1; i <= n; i++)
                {
                    result += 7;
                    Console.Write($"{result} ");
                }
                Console.WriteLine();

                PrintFibonacciSeq(GetFibonacciInputValue("\nВведите количество чисел Фибоначчи: "));

                Console.WriteLine("\nНажмите любую клавишу для выхода в главное меню, или клавишу 'r', чтобы перезапустить задание.");

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'r':
                    case 'R':
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        return;
                }
            }
        }

        static int GetInputValue(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите целочисленое число!");
                }
            }
        }

        static int GetFibonacciInputValue(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result < 2)
                    {
                        Console.WriteLine("Ошибка ввода! Количество чисел должно быть больше двух!");
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите целочисленое число!");
                }
            }
        }

        static void PrintFibonacciSeq(int totalSize)
        {
            int fibCount = 2;
            Console.Write("Вывод чисел Фибоначчи:\n");
            Console.Write("\t0 1 ");
            CalcFibonacciSeq(0, 1, ref fibCount, totalSize);
            Console.WriteLine();
        }

        static void CalcFibonacciSeq(int firstNum, int secondNum, ref int count, int totalSize)
        {
            if (count == totalSize)
            {  
                return;
            }
            else
            {
                Console.Write($"{firstNum + secondNum} ");
                count++;
                CalcFibonacciSeq(secondNum, firstNum + secondNum, ref count, totalSize);
            }
        }

        static void DisplayMatrixTask()
        {
            Console.WriteLine("Задание по матрицам.\n");

            int rows = GetMatrixInputValue("Введите число строк матрицы, меньше чем 6: ");
            int cols = GetMatrixInputValue("Введите число столбцов матрицы, меньше чем 6: ");

            int[,] matrix = new int[rows, cols];

            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(-9, 9);
                }
            }
            Console.Clear();
            while(true)
            {
                PrintMatrixMenu(rows, cols);

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        PrintMatrix(matrix, rows, cols);
                        WaitFun();
                        break;
                    case '2':
                        Console.Clear();
                        PrintMatrix(matrix, rows, cols);
                        PrintCountPosNegNumbers(matrix, rows, cols);
                        WaitFun();
                        break;
                    case '3':
                        Console.Clear();
                        PrintMatrix(matrix, rows, cols);
                        PrintEvenOddMatrix(matrix, rows, cols);
                        WaitFun();
                        break;
                    case '4':
                        Console.Clear();
                        PrintMatrix(matrix, rows, cols);
                        PrintCountMatrixElement(matrix, rows, cols);
                        WaitFun();
                        break;
                    case 'b':
                    case 'B':
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static int GetMatrixInputValue(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if(result > 5)
                    {
                        Console.WriteLine("Ошибка! Число должно быть меньше 6!");
                    }
                    else
                    {
                        return result;
                    }                        
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите целочисленое число!");
                }
            }
        }

        static void PrintMatrixMenu(int rows, int cols)
        {
            Console.WriteLine($"Количество строк матрицы: {rows}" +
                $"\nКоличество столбцов макрицы: {cols}\n");
            Console.WriteLine("Выберите действие:" +
                "\n\t1. Вывести матрицу на консоль." +
                "\n\t2. Найти количество положительных/отрицательных чисел в матрице." +
                "\n\t3. Вывести матрицу так чтобы в четных строках, отображались только четные элементы, а в нечетных – нечетные. Если элементов нет, пустая строка." +
                "\n\t4. Используя словарь подсчитать и вывести сколько раз, какое число было в матрице.");
            Console.WriteLine("Введите 'b' для выхода в главное меню.\n");
        }

        static void WaitFun()
        {
            while (true)
            {
                Console.WriteLine("\nНажмите любую клавишу чтобы продолжить.");

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    default:
                        Console.Clear();
                        return;
                }
            }
        }

        static void PrintMatrix(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Исходная матрица:\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintCountPosNegNumbers(int[,] matrix, int rows, int cols)
        {
            int positiveCount = 0;
            int negativeCount = 0;

            foreach (int el in matrix)
            {
                if (el >= 0)
                {
                    positiveCount++;
                }
                else
                {
                    negativeCount++;
                }
            }

            Console.WriteLine($"Количество положительных чисел:\t{positiveCount}");
            Console.WriteLine($"Количество отрицательных чисел:\t{negativeCount}");
        }

        static void PrintEvenOddMatrix(int[,] matrix, int rows, int cols)
        {
            Console.WriteLine("Результат:\n");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if( ((i + 1) % 2 == 0 && matrix[i, j] % 2 == 0) || ((i + 1) % 2 == 1 && (matrix[i, j] % 2 == 1 || matrix[i, j] % 2 == -1)))
                        Console.Write($"{matrix[i, j]} \t");
                    else
                        Console.Write("_\t");
                }
                Console.WriteLine();
            }
        }


        static void PrintCountMatrixElement(int[,] matrix, int rows, int cols)
        {
            Dictionary<int, int> countElemDictionary = new Dictionary<int, int>();
            foreach (int el in matrix)
            {
                if (countElemDictionary.ContainsKey(el))
                {
                    if (countElemDictionary.TryGetValue(el, out int value))
                        countElemDictionary[el]++;
                }
                else
                {
                    if (countElemDictionary.TryAdd(el, 1))
                        continue;

                }
            }

            foreach( var (key, value) in countElemDictionary)
            {
                Console.WriteLine($"Число {key} встречается {value} раз.");
            }
        }

        static void DisplayListsTask()
        {
            Console.WriteLine("Задание по листам.\n");

            Random rand = new Random();

            int n = GetInputValue("Введите размер массива: ");

            var list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                list.Add(rand.Next(-9, 9));
            }

            Console.Clear();
            while (true)
            {
                PrintListMenu();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        PrintList(list);
                        WaitFun();
                        break;
                    case '2':
                        Console.Clear();
                        AddListElement(ref list);
                        PrintList(list);
                        WaitFun();
                        break;
                    case '3':
                        Console.Clear();
                        DeleteListElement(ref list);
                        PrintList(list);
                        WaitFun();
                        break;
                    case '4':
                        Console.Clear();
                        PrintList(list);
                        ChangeList(ref list);
                        PrintList(list);
                        WaitFun();
                        break;
                    case '5':
                        Console.Clear();
                        PrintList(list);
                        CreateHashSetByList(list);
                        WaitFun();
                        break;
                    case 'b':
                    case 'B':
                        Console.Clear();
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }

        static void PrintListMenu()
        {
            Console.WriteLine("Выберите действие:" +
                "\n\t1. Вывести массив." +
                "\n\t2. Добавить элемент в массив." +
                "\n\t3. Удалить элемент из массива." +
                "\n\t4. Заменить каждый четный элемент на удвоенное значение (*2), а нечетный на 0." +
                "\n\t5. Cоздать HashSet.");
            Console.WriteLine("Введите 'b' для выхода в главное меню.\n");
        }

        static void PrintList(List<int> list)
        {
            Console.Write("Вывод элементов массива:\n\t");
            foreach (int el in list)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
        }

        static void AddListElement(ref List<int> list)
        {
            int value = GetInputValue("Введите новый элемент массива: ");
            list.Add(value);
            Console.WriteLine();
        }

        static void DeleteListElement(ref List<int> list)
        {
            PrintListByIndex(list);

            int index = GetIndexInputValue("Введите индекс элемента для удаления: ", list.Count);
            list.RemoveAt(index);
        }

        static void PrintListByIndex(List<int> list)
        {
            Console.Write("Вывод элементов массива:\n");
            for(int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"\tИндекс {i}, Значение {list[i]}");
            }
            Console.WriteLine();
        }

        static int GetIndexInputValue(string message, int count)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    if (result < 0 || result >= count)
                    {
                        Console.WriteLine("Ошибка! Нет такого индекса в массиве!");
                    }
                    else
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Введите целочисленое число!");
                }
            }
        }

        static void ChangeList(ref List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list[i] *= 2;
                }
                else
                {
                    list[i] = 0;
                }
            }
        }

        static void CreateHashSetByList(List<int> list)
        {
            var hashset = new HashSet<int>(list);

            Console.Write("Вывод элементов HashSet:\n\t");
            foreach (int el in hashset)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine();
        }
    }
}
