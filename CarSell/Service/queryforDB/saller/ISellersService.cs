using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface ISellersService
    {
        List<SellerCompanyModel> GetProdejciList();
    }
}
