namespace Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car sportCar = new SportCar(0, 20);
            Car truck = new Truck(100, 25);

            sportCar.Drive(10);
            truck.Drive(3);

            if( sportCar.Refuel(500))
            {
                sportCar.Drive(10);
            }
            if(sportCar.Refuel(50))
            {
                truck.Drive(4);
            }
        }
    }
}
