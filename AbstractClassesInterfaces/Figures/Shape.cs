using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal abstract class Shape
    {
        public abstract double AreaCalc();

        public abstract double PerimeterCalc();

        public virtual void DisplayInfo(int shapeIndex)
        {
            if (IsValid)
            {
                Console.WriteLine($"Фигура: {ShapeName}");
                Console.WriteLine($"Периметр: {PerimeterCalc()}");
                Console.WriteLine($"Площадь: {AreaCalc()}");
            }
            else
            {
                Console.WriteLine($"Фигура {shapeIndex} не может существовать.\n");
            }
        }

        public string ShapeName { get; protected set; }
        public bool IsValid { get; protected set; }
    }
}
