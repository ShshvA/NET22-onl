namespace GenericsPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Pair<int, string>> listPair = new List<Pair<int, string>>
        {
            new Pair<int, string>(1, "first"),
            new Pair<int, string>(2, "second"),
            new Pair<int, string>(3, "third")
        };

            foreach (var pair in listPair)
            {
                Console.WriteLine($"listPair element {pair.Key}: {pair[pair.Key]}");
            }

            List<Pair<string, int>> listPair2 = new List<Pair<string, int>>
        {
            new Pair<string, int>("1", 1),
            new Pair<string, int>("2", 2),
            new Pair<string, int>("3", 3)
        };

            foreach (var pair in listPair2)
            {
                Console.WriteLine($"listPair2 element {pair.Key}: {pair[pair.Key]}");
            }

            ComparablePair<int, string> comparablePair1 = new ComparablePair<int, string>(1, "ab");
            ComparablePair<int, string> comparablePair2 = new ComparablePair<int, string>(2, "aa");
            ComparablePair<int, string> comparablePair3 = new ComparablePair<int, string>(1, "cc");
            ComparablePair<int, string> comparablePair4 = new ComparablePair<int, string>(1, "cc");

            string message;
            message = comparablePair1.CompareTo(comparablePair2) switch
            {
                var value when value < 0 => "comparablePair1 < comparablePair2",
                var value when value > 0 => "comparablePair1 > comparablePair2",
                _ => "comparablePair1 = comparablePair2",
            };
            Console.WriteLine(message);

            message = comparablePair1.CompareTo(comparablePair3) switch
            {
                var value when value < 0 => "comparablePair1 < comparablePair3",
                var value when value > 0 => "comparablePair1 > comparablePair3",
                _ => "comparablePair1 = comparablePair3",
            };
            Console.WriteLine(message);

            message = comparablePair2.CompareTo(comparablePair3) switch
            {
                var value when value < 0 => "comparablePair2 < comparablePair3",
                var value when value > 0 => "comparablePair2 > comparablePair3",
                _ => "comparablePair2 = comparablePair3",
            };
            Console.WriteLine(message);

            message = comparablePair3.CompareTo(comparablePair4) switch
            {
                var value when value < 0 => "comparablePair3 < comparablePair4",
                var value when value > 0 => "comparablePair3 > comparablePair4",
                _ => "comparablePair3 = comparablePair4",
            };
            Console.WriteLine(message);

        }
    }
}
