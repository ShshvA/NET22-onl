namespace SmartHomeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartHomeHub smartHomeHub = new SmartHomeHub();

            SmartLamp smartLamp = new SmartLamp(smartHomeHub);
            SecuritySiren securitySiren = new SecuritySiren(smartHomeHub);
            SmartphoneApp smartphoneApp = new SmartphoneApp(smartHomeHub);
            Conditioner conditioner = new Conditioner(smartHomeHub);
            Electrovalves electrovalves = new Electrovalves(smartHomeHub);

            smartHomeHub.TriggerFireAlarm();
            Console.WriteLine("");
            smartHomeHub.TriggerInvasion();
            Console.WriteLine("");
            smartHomeHub.TriggerWaterLeak();
            Console.WriteLine("");
            smartHomeHub.TriggerMotion();
            Console.WriteLine("");
            smartHomeHub.TriggerIncreaseTemp();
        }
    }
}
