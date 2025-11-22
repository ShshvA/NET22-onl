using System.Text;
using System.Text.RegularExpressions;

namespace StringsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "Wow! This is my 1st tsest. Do you see number42? Yes! \r\n" +
                "Otto ran to room101. Anna loves level99. \r\n" +
                "Are you ready? No, I am not! \r\n" +
                "This sentence has no comma. But this one, definitely has a comma, right? \r\n" +
                "Hey! Look at Bob — he found 777 coins! \r\n" +
                "Is 12345 the longest digit-word? Maybe! \r\n" +
                "Otto said: \"Wow!\" Anna replied: \"Yes!\" \r\n" +
                "Final test. Done!";

            while (true)
            {
                PrintText(text);
                PrintWelcomeMessage();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        PrintText(text);
                        PrintMaxDigitsWord(text);
                        WaitFun();
                        break;
                    case '2':
                        Console.Clear();
                        PrintText(text);
                        PrintLongestWordAndEntries(text);
                        WaitFun();
                        break;
                    case '3':
                        Console.Clear();
                        PrintText(text);
                        PrintReplacedText(text);
                        WaitFun();
                        break;
                    case '4':
                        Console.Clear();
                        PrintText(text);
                        PrintQuestionsAndExclamatory(text);
                        WaitFun();
                        break;
                    case '5':
                        Console.Clear();
                        PrintText(text);
                        PrintWithoutComma(text);
                        WaitFun();
                        break;
                    case '6':
                        Console.Clear();
                        PrintText(text);
                        PrintStartEndSameLetterWords(text);
                        WaitFun();
                        break;
                    case '7':
                        Console.Clear();
                        PrintText(text);
                        SearchByPart(text);
                        WaitFun();
                        break;
                    case '8':
                        Console.Clear();
                        PrintText(text);
                        PrintPalindromes(text);
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

        static void PrintText(string text)
        {
            Console.WriteLine($"Исходный текст:\n\n{text}\n");
        }
        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Выберите действие над текстом:\n" +
                "\t1. Найти слова, содержащие максимальное количество цифр.\n" +
                "\t2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте.\n" +
                "\t3. Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять».\n" +
                "\t4. Вывести на экран сначала вопросительные, а затем восклицательные предложения.\n" +
                "\t5. Вывести на экран только предложения, не содержащие запятых.\n" +
                "\t6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.\n" +
                "\t7. Добавить возможность поиска по части ввода. (не учитывать регистр)\n" +
                "\t8. Вывести палиндромы, если они есть.");
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

        static void PrintMaxDigitsWord(string text)
        {
            var words = GetWordsFromText(text);

            var digitsWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                int digitCount = 0;
                foreach (char ch in word)
                {
                    if (char.IsDigit(ch))
                    {
                        digitCount++;
                    }
                }
                if (digitCount > 0)
                {
                    digitsWords.Add(word, digitCount);
                }
            }

            var maxDigitsWord = digitsWords.MaxBy(x => x.Value);

            Console.WriteLine($"Слово, содержащее максильное количество цифр: {maxDigitsWord.Key}");
        }

        static List<string> GetWordsFromText(string text)
        {
            string res = Regex.Replace(text, @"[^\w\s-]|(?<!\w)-(?!\w)", " ");
            res = Regex.Replace(res, @"\s+", " ");
            return res.Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        static void PrintLongestWordAndEntries(string text)
        {
            var words = GetWordsFromText(text);

            var sizeWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                sizeWords.TryAdd(word, word.Length);
            }

            var maxWordLen = sizeWords.Max(x => x.Value);

            var maxLenWordsCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (word.Length == maxWordLen)
                {
                    if (maxLenWordsCount.ContainsKey(word))
                    {
                        maxLenWordsCount[word]++;
                    }
                    else
                    {
                        maxLenWordsCount.Add(word, 1);
                    }
                }           
            }

            foreach( var (key, value) in maxLenWordsCount)
            {
                Console.WriteLine($"Слово {key} длинной {key.Length}, встретилось {value} раз.");
            }
        }

        static void PrintReplacedText(string text)
        {
            var sb = new StringBuilder();
            foreach(char ch in text)
            {
                switch (ch)
                {
                    case '0':
                        sb.Append("ноль");
                        break;
                    case '1':
                        sb.Append("один");
                        break;
                    case '2':
                        sb.Append("два");
                        break;
                    case '3':
                        sb.Append("три");
                        break;
                    case '4':
                        sb.Append("черыре");
                        break;
                    case '5':
                        sb.Append("пять");
                        break;
                    case '6':
                        sb.Append("шесть");
                        break;
                    case '7':
                        sb.Append("семь");
                        break;
                    case '8':
                        sb.Append("восемь");
                        break;
                    case '9':
                        sb.Append("девять");
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }

            Console.WriteLine($"Измененный текск:\n{sb.ToString()}");
        }

        static void PrintQuestionsAndExclamatory(string text)
        {
            var sentences = SplitTextIntoSentences(text);

            var sb = new StringBuilder();

            foreach(var sentence in sentences)
            {
                if (sentence.Contains('?'))
                {
                    sb.Insert(0, $"\n{sentence}");
                }
                else if(sentence.Contains('!'))
                {
                    sb.Append($"\n{sentence}");
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine($"Вывод на экран сначала вопросительных, а затем восклицательных предложений:{sb.ToString()}");
        }

        static List<string> SplitTextIntoSentences(string text)
        {
            text = Regex.Replace(text, @"\s+", " ").Trim();

            var result = new List<string>();
            var sb = new StringBuilder();
            char[] endings = { '.', '!', '?' };

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                sb.Append(ch);

                if (Array.IndexOf(endings, ch) >= 0)
                {
                    int nextIndex = i + 1;

                    if (nextIndex < text.Length && !IsInsideQuotes(text, nextIndex))
                    {
                        sb.Append(text[nextIndex]);
                        i = nextIndex;
                        nextIndex++;
                    }

                    while (nextIndex < text.Length && text[nextIndex] == ' ')
                    {
                        nextIndex++;
                    }

                    if (!IsInsideQuotes(text, i) ||
                        nextIndex >= text.Length ||
                        (nextIndex < text.Length && char.IsUpper(text[nextIndex])))
                    {
                        result.Add(sb.ToString().Trim());
                        sb.Clear();
                    }
                }
            }

            if (sb.Length > 0)
                result.Add(sb.ToString().Trim());

            return result;
        }

        static bool IsInsideQuotes(string text, int position)
        {
            int quoteCount = 0;
            for (int i = 0; i <= position; i++)
            {
                if (text[i] == '"')
                {
                    quoteCount++;
                }
            }
            return quoteCount % 2 != 0;
        }

        static void PrintWithoutComma(string text)
        {
            var sentences = SplitTextIntoSentences(text);

            var sb = new StringBuilder();

            foreach (var sentence in sentences)
            {
                if (!sentence.Contains(','))
                {
                    sb.Append($"\n{sentence}");
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine($"Вывод на экран только предложений, не содержащих запятые:{sb.ToString()}");
        }

        static void PrintStartEndSameLetterWords(string text)
        {
            var words = GetWordsFromText(text);
            var hs = new HashSet<string>();
            
            foreach (var word in words)
            {
                if (word.Length > 0 && word.ToLower()[0] == word.ToLower()[word.Length - 1])
                {
                    hs.Add(word);
                }               
            }

            if (hs.Count == 0)
            {
                Console.WriteLine($"Слов, начинающихся и заканчивающихся на одну и ту же букву не найдено.");
            }
            else
            {
                Console.WriteLine($"Найдено слов, начинающихся и заканчивающихся на одну и ту же букву: {hs.Count}");
                foreach (var word in hs)
                {
                    Console.WriteLine($"- {word}");
                }
            }
        }

        static void SearchByPart(string text)
        {
            string inputStr = GetInputString("Введите слово или его часть для поиска: ");

            var words = GetWordsFromText(text);
            var hs = new HashSet<string>();

            foreach (var word in words)
            {
                if (word.ToLower().Contains(inputStr))
                {
                    hs.Add(word);
                }
            }

            if(hs.Count == 0)
            {
                Console.WriteLine($"Слов, содержащих '{inputStr}' не найдено.");
            }
            else
            {
                Console.WriteLine($"Найдено слов, содержащих '{inputStr}': {hs.Count}");
                foreach (var word in hs)
                {
                    Console.WriteLine($"- {word}");
                }
            }
        }

        static string GetInputString(string message)
        {
            while (true)
            {
                Console.Write("Введите слово или его часть для поиска: ");

                string inputStr = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputStr))
                {
                    Console.WriteLine("Запрос не может быть пустым");
                }
                else
                {
                    return inputStr;
                }
            }
        }

        static void PrintPalindromes(string text)
        {
            var words = GetWordsFromText(text);
            var hs = new HashSet<string>();

            foreach (var word in words)
            {
                if (isPalindrome(word.ToLower()))
                {
                    hs.Add(word);
                }
            }

            if (hs.Count == 0)
            {
                Console.WriteLine($"Слов - палиндромов не найдено.");
            }
            else
            {
                Console.WriteLine($"Найдено слов - палиндромов: {hs.Count}");
                foreach (var word in hs)
                {
                    Console.WriteLine($"- {word}");
                }
            }
        }

        static bool isPalindrome(string word)
        {
            return word.SequenceEqual(word.Reverse());
        }
    }
}
