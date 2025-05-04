using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Model
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("nazev")]
        public string Name { get; set; }

        [XmlAttribute("znackaId")]
        public int ZnackaId { get; set; }
    }
}
