using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddEmployeeWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly IEmployeeService _employeeService;
        private readonly IMessegeService _messegeService;


        public AddEmployeeWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _employeeService = serviceFactory.GetService<IEmployeeService>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
            FillComboBox();
        }

        private void FillComboBox()
        {
            var employee = _employeeService.GetEmployeeModel();
            if (employee == null || employee.Employer == null) return;
            EmployeeFormControl.SellerComboBox.ItemsSource = employee.Employer;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {


            EmployeeModel newEmployee = new EmployeeModel
            {
                SellerId = Convert.ToInt32(EmployeeFormControl.SelectedSellerId),
                Name = EmployeeFormControl.Name,
                Surname = EmployeeFormControl.Surname
            };
            var validationErrors = _validator.Validate(newEmployee);
            if (validationErrors.Any())
            {
                return;
            }
            newEmployee.Id = _database.GenerateNewId(new TypyEntitService().Employee);
            var convertor = _convertor.GetConverter<EmployeeModel, Employee>();
            _database.AddToDatabase(convertor.Convert(newEmployee));

            _messegeService.ShowInfoSucces("Zaměstnanec byl úspěšně přidán.");
            this.Close();
        }
    } 
}