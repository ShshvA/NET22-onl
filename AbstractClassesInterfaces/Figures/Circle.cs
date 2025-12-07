using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Circle : Shape
    {
        public Circle(double radius)
        {
            if (radius < 0)
            {
                base.IsValid = false;
                Console.WriteLine($"Круг: Радиус не может быть меньше нуля.\n" +
                    $"\t Радиус = {radius}\n");
            }
            else
            {
                base.IsValid = true;
                base.ShapeName = "Круг";
                Radius = radius;
            }
        }

        public override double AreaCalc()
        {
            return Math.PI * Radius * Radius;
        }

        public override double PerimeterCalc()
        {
            return 2 * Math.PI * Radius;
        }

        public override void DisplayInfo(int shapeIndex)
        {
            base.DisplayInfo(shapeIndex);
            if (base.IsValid)
            {
                Console.WriteLine($"Радиус = {Radius}\n");
            }
        }

        public double Radius { private get; init; }
    }
}
