using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAccountingSystem
{
    internal abstract class Document
    {
        public virtual void GetDocInfo()
        {
            Console.WriteLine($"Информация о документе:\n" +
                $"\t Тип: {Type} \n" +
                $"\t Номер: {DocNumber} \n" +
                $"\t Дата: {Date.ToLocalTime().ToString("dd.MM.yyyy HH:mm:ss")}");
        }

        public string DocNumber { get; protected set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; protected set; } = DateTime.UtcNow;

        public string Type { get; protected set; }
    }
}
