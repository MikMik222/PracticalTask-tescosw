using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class SellerCompany
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("nazev")]
        public string Name { get; set; }

        [XmlAttribute("sidlo")]
        public string Office { get; set; }

        [XmlAttribute("kontakt")]
        public string Contact { get; set; }
    }
}
