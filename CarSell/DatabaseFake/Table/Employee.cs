using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Employee
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlAttribute("prodejceId")]
        public int ProdejceId { get; set; }

        [XmlAttribute("jmeno")]
        public string Name { get; set; }

        [XmlAttribute("prijmeni")]
        public string Surname { get; set; }
    }
}
