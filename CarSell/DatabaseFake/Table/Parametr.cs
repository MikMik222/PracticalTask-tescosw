using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Parametr
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("nazev")]
        public string Nazev { get; set; }

        [XmlAttribute("hodnota")]
        public string Hodnota { get; set; }

        [XmlAttribute("jednotka")]
        public string Jednotka { get; set; }
    }
}
