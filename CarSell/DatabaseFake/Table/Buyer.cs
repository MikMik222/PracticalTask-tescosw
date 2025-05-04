using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Buyer
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("jmeno")]
        public string Name { get; set; }

        [XmlAttribute("prijmeni")]
        public string Surname { get; set; }

        [XmlAttribute("adresa")]
        public string Adress { get; set; }

        [XmlAttribute("telefon")]
        public string Phone { get; set; }
    }
}
