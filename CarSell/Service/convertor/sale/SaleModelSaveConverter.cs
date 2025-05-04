using CarSell.DatabaseFake;
using CarSell.ModelView;
using System;

namespace CarSell.Service
{
    public class SaleModelSaveConverter : IModelConverter<SalesModel, Sale>
    {

        public Sale Convert(SalesModel input)
        {
            return new Sale()
            {
                Id = input.Id,
                BuyerId = input.kupujiciId,
                Cost = input.Cost,
                DateSale = input.DateSale,
                EmployeeId = input.EmployeeId,
                VersionId = input.VersionId,
                VATId = input.dphId
            };
        }
    }

}