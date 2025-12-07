namespace Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes = new Shape[]
                {
                    new Triangle(3, 4, 5),
                    new Rectangle(5, 10),
                    new Circle(7),
                    new Triangle(5, 5, 5),
                    new Rectangle(4, 4),
                    new Triangle(1, 2, 3),
                    new Circle(-7),
                    new Rectangle(4, -4)
                };

            int i = 0;
            foreach (var shape in shapes)
            {
                shape.DisplayInfo(i);
                i++;
            }

            double totalArea = 0;
            foreach (var shape in shapes)
            {
                if (shape.IsValid)
                {
                    totalArea += shape.PerimeterCalc();
                }
            }
            Console.WriteLine($"Общий периметр всех фигур: {totalArea:F2}");
        }
    }
}
