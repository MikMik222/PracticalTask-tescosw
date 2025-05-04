using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public interface ISalesService
    {
        string GetSalesSummary(DateTime from, DateTime to, bool weekendsOnly);
        public List<SalesModel> GetListSales();
        public int GetRandomIdForSales(); // TODO this function exist beacause now i dont make login and register
    }

}
