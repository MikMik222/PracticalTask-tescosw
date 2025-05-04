using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface ICarsService
    {
        List<BrandModel> GetBrands();
        List<Model> GetModelsByBrandId(int znackaId);
        List<DatabaseFake.Version> GetVersionByModelId(int modelId);

        CarModel GetCarModel();
    }
}
