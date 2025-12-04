using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    internal interface IVehicle
    {
        public void Drive(int distance);
        public bool Refuel(int gasoline);
    }
}
