using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal class Truck : Car
    {
        public Truck(int iniFuel, int consumption) : base(iniFuel, consumption)
        {
        }

        public override void Drive(int distance)
        {
            int fuelLost = distance * Consumption;
            if (Fuel >= fuelLost)
            {
                Console.WriteLine("Truck движется.");
                Fuel -= fuelLost;
            }
            else
            {
                Console.WriteLine($"Truck не движется. Не хватит топлива для прохождения {distance} растояния.");
            }
        }

        public override bool Refuel(int gasoline)
        {
            if (gasoline > 0)
            {
                Console.WriteLine($"Truck дозаправился на {gasoline}.");
                Fuel += gasoline;
                return true;
            }
            else
            {
                Console.WriteLine($"Truck не может заправится на {gasoline}.");
                return false;
            }
        }
    }
}
