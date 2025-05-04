using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface IBrandService
    {
        List<BrandModel> GetZnacky();
    }
}
