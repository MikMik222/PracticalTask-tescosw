using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class VAT
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("sazba")]
        public double Tax { get; set; }

    }
}
