using CarSell.DatabaseFake;
using CarSell.ModelView;

namespace CarSell.Service
{
    public class EmployeeSaveConvertor : IModelConverter<EmployeeModel, Employee>
    {
        public Employee Convert(EmployeeModel input)
        {
            return new Employee
            {
                Id = input.Id,
                Surname = input.Surname,
                Name = input.Name,
                ProdejceId = input.SellerId,
            };
        }
    }

}