using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Triangle : Shape
    {
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < 0 || sideB < 0 || sideC < 0)
            {
                base.IsValid = false;
                Console.WriteLine($"Треугольник: Стороны треугольника не могут быть меньше нуля.\n" +
                    $"\t Сторона A = {sideA}, Сторона A = {sideB}, Сторона A = {sideC}\n");
            }
            else if(!IsValidTriangle(sideA, sideB, sideC))
            {
                base.IsValid = false;
                Console.WriteLine($"Треугольник: Стороны треугольника не удовлетворяют неравенству треугольника.\n" +
                    $"\t Сторона A = {sideA}, Сторона A = {sideB}, Сторона A = {sideC}\n");
            }
            else
            {
                base.IsValid= true;
                base.ShapeName = "Треугольник";
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
            }
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        public override double AreaCalc()
        {
            double p = this.PerimeterCalc() / 2;
            return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
        }

        public override double PerimeterCalc()
        {
            return SideA + SideB + SideC;
        }

        public override void DisplayInfo(int shapeIndex)
        {
            base.DisplayInfo(shapeIndex);
            if (base.IsValid)
            {
                Console.WriteLine($"Стороны: {SideA}, {SideB}, {SideC}\n");
            }
        }

        public double SideA { private get; init; }
        public double SideB { private get; init; }
        public double SideC { private get; init; }
    }
}
