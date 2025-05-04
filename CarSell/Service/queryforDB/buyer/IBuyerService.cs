using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface IBuyerService
    {
        public List<Buyer> GetTenBuyerWithFilter(string Name, string Surname);
    }
}
