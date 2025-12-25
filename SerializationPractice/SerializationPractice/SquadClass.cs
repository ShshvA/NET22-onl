using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationPractice
{
    [XmlRoot("SquadClass")]
    public class SquadClass
    {
        [XmlAttribute("name")]
        public string SquadName { get; set; }

        [XmlElement("town")]
        public string HomeTown { get; set; }

        [XmlElement("formed")]
        public int Formed { get; set; }

        [XmlElement("base")]
        public string SecretBase { get; set; }

        [XmlAttribute("active")]
        public bool Active { get; set; }

        [XmlElement("members")]
        public List<SquadMember> Members { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"squadName: {SquadName}\n" +
                $"homeTown: {HomeTown}\n" +
                $"formed: {Formed}\n" +
                $"secretBase: {SecretBase}\n" +
                $"active: {Active}\n" +
                $"members:");

            foreach(var member in Members)
            {
                member.GetInfo();
            }
        }
    }

    [XmlRoot("member")]
    public class SquadMember
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlElement("secretIdentity")]
        public string SecretIdentity { get; set; }

        [XmlArray("powers")]
        [XmlArrayItem("power")]
        public string[] Powers { get; set; }

        public void GetInfo()
        {
            Console.WriteLine($"\tname: {Name}\n" +
                $"\tage: {Age}\n" +
                $"\tsecretIdentity: {SecretIdentity}\n" +
                $"\tpowers:");
            foreach(var power in  Powers)
            {
                Console.WriteLine($"\t\t{power}");
            }
            Console.WriteLine();
        }
    }
}
