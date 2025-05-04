using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Brand
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("nazev")]
        public string Name { get; set; }
    }
}
