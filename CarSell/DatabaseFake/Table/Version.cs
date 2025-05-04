using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Version
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("modelId")]
        public int ModelId { get; set; }

        [XmlAttribute("typ")]
        public string Type { get; set; }

        [XmlElement("Parametr")]
        public List<Parametr> Parametrs { get; set; }
    }
}
