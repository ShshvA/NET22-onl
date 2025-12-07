using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Rectangle : Shape
    {
        public Rectangle(double width, double height)
        {
            if (width < 0 || height < 0)
            {
                base.IsValid = false;
                Console.WriteLine($"Прямоугольник: Стороны прямоугольника не могут быть меньше нуля.\n" +
                    $"\t Ширина = {width}, Высота = {height}\n");
            }
            else
            {
                base.IsValid = true;
                base.ShapeName = "Прямоугольник";
                Width = width;
                Height = height;
            }
        }

        public override double AreaCalc()
        {
            return Width * Height;
        }

        public override double PerimeterCalc()
        {
            return 2 * (Width + Height);
        }

        public override void DisplayInfo(int shapeIndex)
        {
            base.DisplayInfo(shapeIndex);
            if (base.IsValid)
            {
                Console.WriteLine($"Стороны: {Width}, {Height}\n");
            }
        }

        public double Width { private get; init; }
        public double Height { private get; init; }
    }
}
