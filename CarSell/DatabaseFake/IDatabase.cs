namespace CarSell.DatabaseFake
{
    public interface IDatabase
    {
        public void SaveDataToFile(string filePath);
        CarsData LoadDataFromFile(string filePath);
        CarsData GetCarsData();
        public int GenerateNewId(string collectionName);
        public int GenerateNewId(string collectionName, int idArray);
        public void AddToDatabase<T>(T item);
    }
}
