using CarSell.DatabaseFake;
using System.IO;
using System.Xml.Serialization;

namespace CarSell.Service
{
    public class XmlDataService : IDataService
    {
        public CarsData Load(string filePath)
        {
            var serializer = new XmlSerializer(typeof(CarsData));
            using var fs = new FileStream(filePath, FileMode.Open);
            return (CarsData)serializer.Deserialize(fs);
        }

        public void Save(string filePath, CarsData data)
        {
            var serializer = new XmlSerializer(typeof(CarsData));
            using var writer = new StreamWriter(filePath);
            serializer.Serialize(writer, data);
        }
    }
}
