using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public interface ISmartDevice
    { 
        public void ReactToEvent(object? sender, HubEvent eventData);

        public string Name { get; }
    }
    public class SmartLamp : ISmartDevice
    {
        public SmartLamp(SmartHomeHub smartHomeHub) => smartHomeHub.OnEvent += ReactToEvent;

        public void ReactToEvent(object? sender, HubEvent eventData)
        {
            if( eventData.EventType == "Движение" && eventData.EventSeverityLevel == 2)
            {
                Console.WriteLine($"Реагирует: {Name}. Включается освещение.");
            }
        }

        public string Name => "SmartLamp";
    }

    public class SecuritySiren : ISmartDevice
    {
        public SecuritySiren(SmartHomeHub smartHomeHub) => smartHomeHub.OnEvent += ReactToEvent;

        public void ReactToEvent(object? sender, HubEvent eventData)
        {
            if (eventData.EventSeverityLevel >= 4)
            {
                Console.WriteLine($"Реагирует: {Name}. Включается сирена.");
            }
        }

        public string Name => "SecuritySiren";
    }

    public class SmartphoneApp : ISmartDevice
    {
        public SmartphoneApp(SmartHomeHub smartHomeHub) => smartHomeHub.OnEvent += ReactToEvent;

        public void ReactToEvent(object? sender, HubEvent eventData)
        {
            if (eventData.EventSeverityLevel >= 2)
            {
                Console.WriteLine($"Реагирует: {Name}. Рассылается уведомление.");
            }
        }

        public string Name => "SmartphoneApp";
    }

    public class Conditioner : ISmartDevice
    {
        public Conditioner(SmartHomeHub smartHomeHub) => smartHomeHub.OnEvent += ReactToEvent;

        public void ReactToEvent(object? sender, HubEvent eventData)
        {
            if (eventData.EventType == "Высокая температура воздуха")
            {
                Console.WriteLine($"Реагирует: {Name}. Включается кондиционер.");
            }
        }

        public string Name => "Conditioner";
    }

    public class Electrovalves : ISmartDevice
    {
        public Electrovalves(SmartHomeHub smartHomeHub) => smartHomeHub.OnEvent += ReactToEvent;

        public void ReactToEvent(object? sender, HubEvent eventData)
        {
            if (eventData.EventType == "Утечка воды")
            {
                Console.WriteLine($"Реагирует: {Name}. Электроклапаны перекрывают воду.");
            }
        }

        public string Name => "Electrovalves";
    }
}
