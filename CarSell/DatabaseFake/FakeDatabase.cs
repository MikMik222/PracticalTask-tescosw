using CarSell.Type;
using Microsoft.Win32;
using System.IO;
using System.Reflection.Metadata;
using System.Windows;
using System.Xml.Serialization;

namespace CarSell.DatabaseFake
{
    public class FakeDatabase : IDatabase
    {
        private CarsData _data;

        public void SaveDataToFile(string filePath)
        {
            if (_data == null)
            {
                MessageBox.Show("Žádná data nebyla načtena.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CarsData));
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    serializer.Serialize(writer, _data);
                }
                MessageBox.Show("Data byla úspěšně uložena.", "Uloženo", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Chyba při ukládání souboru: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public CarsData LoadDataFromFile(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("Soubor nebyl nalezen.", filePath);
                }

                XmlSerializer serializer = new XmlSerializer(typeof(CarsData));

                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    _data = (CarsData)serializer.Deserialize(fs);
                }

                return GetCarsData();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"Chyba: {ex.Message}", "Chyba při načítání souboru", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Chyba při deserializaci souboru: {ex.Message}", "Chyba při načítání dat", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Došlo k neznámé chybě: {ex.Message}", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        public CarsData GetCarsData()
        {
            return _data;
        }

        private int GetMaxId(IEnumerable<dynamic> list)
        {
            return list?.Max(x => x.Id) ?? 0;
        }


        public int GenerateNewId(string collectionName)
        {
            int maxId = 0;
            switch (collectionName)
            {
                case "DPH":
                    maxId = GetMaxId(_data.VAT);
                    break;
                case "Zaměstnanec":
                    maxId = GetMaxId(_data.Employees);
                    break;
                case "Značka":
                    maxId = GetMaxId(_data.Brands);
                    break;
                case "Model":
                    maxId = GetMaxId(_data.Models);
                    break;
                case "Prodejce":
                    maxId = GetMaxId(_data.Sellers);
                    break;
                case "Prodej":
                    maxId = GetMaxId(_data.Sales);
                    break;
                case "Verze":
                    maxId = GetMaxId(_data.Parametrs);
                    break;
                default:
                    throw new ArgumentException("Neznámá kolekce");
            }

            return maxId + 1;
        }

        public int GenerateNewId(string collectionName, int idArray)
        {
            int maxId = 0;
            switch (collectionName)
            {
                case "Parametr":
                    maxId = GetMaxId(_data.Parametrs.Where(o => o.ModelId == idArray).ToList());
                    break;
                default:
                    throw new ArgumentException("Neznámá kolekce");
            }

            return maxId + 1;
        }

        public void AddToDatabase<T>(T item)
        {
            if (_data == null)
                _data = new CarsData();

            if (item is Brand znacka)
            {
                _data.Brands ??= new List<Brand>();
                _data.Brands.Add(znacka);
            }
            else if (item is Model model)
            {
                _data.Models ??= new List<Model>();
                _data.Models.Add(model);
            }
            else if (item is SellerCompany prodejce)
            {
                _data.Sellers ??= new List<SellerCompany>();
                _data.Sellers.Add(prodejce);
            }
            else if (item is Version verze)
            {
                _data.Parametrs ??= new List<Version>();
                _data.Parametrs.Add(verze);
            }
            else if (item is VAT dph)
            {
                _data.VAT ??= new List<VAT>();
                _data.VAT.Add(dph);
            }
            else if (item is Employee zamestnanec)
            {
                _data.Employees ??= new List<Employee>();
                _data.Employees.Add(zamestnanec);
            }
            else if (item is Buyer kupujici)
            {
                _data.Buyers ??= new List<Buyer>();
                _data.Buyers.Add(kupujici);
            }
            else if (item is Sale prodej)
            {
                _data.Sales ??= new List<Sale>();
                _data.Sales.Add(prodej);
            }
            else
            {
                throw new InvalidOperationException($"Nepodporovaný typ: {typeof(T).Name}");
            }
        }

    }
}


