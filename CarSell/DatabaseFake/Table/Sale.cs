using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class Sale
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("verzeId")]
        public int VersionId { get; set; }

        [XmlAttribute("datum")]
        public DateTime DateSale { get; set; }

        [XmlAttribute("cena")]
        public double Cost { get; set; }

        [XmlAttribute("dphId")]
        public int VATId { get; set; }

        [XmlAttribute("prodejceZamestnanecId")]
        public int EmployeeId { get; set; }

        [XmlAttribute("kupujiciId")]
        public int BuyerId { get; set; }
    }
}
