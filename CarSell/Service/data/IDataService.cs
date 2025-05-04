using CarSell.DatabaseFake;

namespace CarSell.Service
{
    public interface IDataService
    {
        CarsData Load(string filePath);
        void Save(string filePath, CarsData data);
    }
}
