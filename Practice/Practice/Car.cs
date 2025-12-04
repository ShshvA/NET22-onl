using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal abstract class Car: IVehicle
    {
        public Car(int iniFuel, int consumption)
        {
            Fuel = iniFuel;
            Consumption = int.IsNegative(consumption) ? 0 : consumption;
        }

        public virtual void Drive(int distance)
        {
            Fuel = distance * Consumption;
        }

        public virtual bool Refuel(int gasoline)
        {
            if (gasoline > 0)
            {
                Fuel += gasoline;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Fuel { get; set; }
        public int Consumption { get; set; }
    }
}
