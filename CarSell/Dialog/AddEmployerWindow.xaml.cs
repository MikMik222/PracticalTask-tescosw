using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddEmployerWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private readonly IMessegeService _messegeService;


        public AddEmployerWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SellerModel newSeller = new SellerModel
            {
                Contact = EmployerFormControl.Contact,
                Name = EmployerFormControl.Name,
                Office = EmployerFormControl.Office,
            };
            var validationErrors = _validator.Validate(newSeller);
            if (validationErrors.Any())
            {
                return;
            }
            newSeller.Id = _database.GenerateNewId(new TypyEntitService().Brand);
            var convertor = _convertor.GetConverter<SellerModel, SellerCompany>();
            _database.AddToDatabase(convertor.Convert(newSeller));

            _messegeService.ShowInfoSucces("Prodejce byl úspěšně přidán.");
            this.Close();
        }

    }
}