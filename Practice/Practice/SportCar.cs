using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class SportCar : Car
    {
        public SportCar(int iniFuel, int consumption) : base(iniFuel, consumption)
        {
        }

        public override void Drive(int distance)
        {
            int fuelLost = distance * Consumption;
            if (Fuel >= fuelLost)
            {
                Console.WriteLine("SportCar движется.");
                Fuel -= fuelLost;
            }
            else
            {
                Console.WriteLine($"SportCar не движется. Не хватит топлива для прохождения {distance} растояния.");
            }
        }

        public override bool Refuel(int gasoline)
        {
            if (gasoline > 0)
            {
                Console.WriteLine($"SportCar дозаправился на {gasoline}.");
                Fuel += gasoline;
                return true;
            }
            else
            {
                Console.WriteLine($"SportCar не может заправится на {gasoline}.");
                return false;
            }
        }
    }
}
