using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    [XmlRoot("VozidlaData")]
    public class CarsData
    {
        [XmlArray("Znacky")]
        [XmlArrayItem("Znacka")]
        public List<Brand> Brands { get; set; }

        [XmlArray("Modely")]
        [XmlArrayItem("Model")]
        public List<Model> Models { get; set; }

        [XmlArray("Parametry")]
        [XmlArrayItem("Verze")]
        public List<Version> Parametrs { get; set; }

        [XmlArray("DPH")]
        [XmlArrayItem("Sazba")]
        public List<VAT> VAT { get; set; }

        [XmlArray("Prodejci")]
        [XmlArrayItem("Prodejce")]
        public List<SellerCompany> Sellers { get; set; }

        [XmlArray("Zamestnanci")]
        [XmlArrayItem("Zamestnanec")]
        public List<Employee> Employees { get; set; }

        [XmlArray("Kupujici")]
        [XmlArrayItem("Kupujici")]
        public List<Buyer> Buyers { get; set; }

        [XmlArray("Prodeje")]
        [XmlArrayItem("Prodej")]
        public List<Sale> Sales { get; set; }



    }
}
