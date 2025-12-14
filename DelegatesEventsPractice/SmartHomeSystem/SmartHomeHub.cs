using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class HubEvent : EventArgs
    {
        public HubEvent(string type, int severityLevel ) 
        {
            EventType = type;
            EventSeverityLevel = severityLevel;
            EventTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"\tТип события: {EventType}\n" +
                $"\tУровень зажности: {EventSeverityLevel}\n" +
                $"\tВремя возникновения: {EventTime}";
        }

        public string EventType { get; }
        public DateTime EventTime { get; }
        public int EventSeverityLevel { get; }

    }
    public class SmartHomeHub
    {
        public event EventHandler<HubEvent> OnEvent;

        public void TriggerMotion()
        {
            HubEvent args = new HubEvent("Движение", 2);
            Console.WriteLine($"SmartHomeHub сгенерировал событие:\n" +
                $"{args.ToString()}\n");
            RaiseEvent(args);
        }

        public void TriggerFireAlarm()
        {
            HubEvent args = new HubEvent("Возгорание", 5);
            Console.WriteLine($"SmartHomeHub сгенерировал событие:\n" +
                $"{args.ToString()}\n");
            RaiseEvent(args);
        }

        public void TriggerInvasion()
        {
            HubEvent args = new HubEvent("Проникновение", 4);
            Console.WriteLine($"SmartHomeHub сгенерировал событие:\n" +
                $"{args.ToString()}\n");
            RaiseEvent(args);
        }

        public void TriggerIncreaseTemp()
        {
            HubEvent args = new HubEvent("Высокая температура воздуха", 1);
            Console.WriteLine($"SmartHomeHub сгенерировал событие:\n" +
                $"{args.ToString()}\n");
            RaiseEvent(args);
        }

        public void TriggerWaterLeak()
        {
            HubEvent args = new HubEvent("Утечка воды", 3);
            Console.WriteLine($"SmartHomeHub сгенерировал событие:\n" +
                $"{args.ToString()}\n");
            RaiseEvent(args);
        }

        protected virtual void RaiseEvent(HubEvent e) 
        {
            OnEvent?.Invoke(this, e);
        }
    }
}
