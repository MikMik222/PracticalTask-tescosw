using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;
using CarSell.Type;
using CarSell.Validation;
using System.Runtime.InteropServices;
using System.Windows;


namespace CarSell.Dialog
{
    public partial class AddSalesWindow : Window
    {
        private readonly IDatabase _database;
        private readonly IModelValidator _validator;
        private readonly IModelConverterFactory _convertor;
        private IBuyerService _buyerService;
        private int _selectedCar;
        private IVATService _vatService;
        private Buyer _buyer;
        private ISalesService _salesService;
        private readonly IMessegeService _messegeService;
        public AddSalesWindow(IServiceFactory serviceFactory, int selectedCar)
        {
            InitializeComponent();
            _database = serviceFactory.GetService<IDatabase>();
            _validator = serviceFactory.GetService<IModelValidator>();
            _convertor = serviceFactory.GetService<IModelConverterFactory>();
            _vatService = serviceFactory.GetService<IVATService>();
            _selectedCar = selectedCar;
            _salesService = serviceFactory.GetService<ISalesService>();
            _buyerService = serviceFactory.GetService<IBuyerService>();
            _messegeService = serviceFactory.GetService<IMessegeService>();
            InitUI();
        }

        private void InitUI()
        {
            var data = _database.GetCarsData();
            var car = data.Parametrs.FirstOrDefault(o => o.Id == _selectedCar);
            var model = data.Models.FirstOrDefault(m => m.Id == car?.ModelId);
            var znacka = data.Brands.FirstOrDefault(z => z.Id == model?.ZnackaId);

            if (model == null || znacka == null)
            {
                MessageBox.Show("Nepodařilo se načíst informace o voze.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                this.Close();
                return;
            }
            SalesFormControler.AutoInfoTextBlock.Text = "nevybrán";
            SalesFormControler.ModelNazevTextBlock.Text = $"{znacka.Name} {model.Name} {car?.Type}";
            var itemsVAT = _vatService.GetVATList();
            SalesFormControler.BrandComboBox.ItemsSource = itemsVAT;
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            var dialog = new SelectBuyerDialog(_buyerService);
            if (dialog.ShowDialog() != true || dialog.SelectBuyer == null) return;
            _buyer = dialog.SelectBuyer;
            SalesFormControler.AutoInfoTextBlock.Text = $"{_buyer.Name} {_buyer.Surname}";
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            double cost;
            if (Double.TryParse(SalesFormControler.CostText, out cost))
            {
                SalesModel newSales = new SalesModel()
                {
                    Cost = cost,
                    kupujiciId = _buyer?.Id ?? 0,
                    dphId = Convert.ToInt32(SalesFormControler.BrandComboBox.SelectedValue),

                };
                var validationErrors = _validator.Validate(newSales);
                if (validationErrors.Any())
                {
                    return;
                }
                newSales.VersionId = _selectedCar;
                newSales.DateSale = DateTime.Now;
                newSales.EmployeeId = _salesService.GetRandomIdForSales();
                newSales.Id = _database.GenerateNewId(new TypyEntitService().Sale);
                var convertor = _convertor.GetConverter<SalesModel, Sale>();
                _database.AddToDatabase(convertor.Convert(newSales));
                _messegeService.ShowInfoSucces("Prodej byl úspěšně přidán.");
                this.Close();
            }else
            {
                _messegeService.ShowError("Neplatný formát ceny.");
            }
        }

    }
}