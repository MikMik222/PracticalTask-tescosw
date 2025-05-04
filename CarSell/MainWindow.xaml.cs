using Microsoft.Win32;
using System.Windows;
using CarSell.Dialog;
using CarSell.DatabaseFake;
using CarSell.ModelView;
using CarSell.Service;

namespace CarSell
{
    public partial class MainWindow : Window
    {
        private readonly IModelConverterFactory _converterFactory;
        private readonly IDatabase _database;
        private readonly ISalesService _salesService;
        private readonly IServiceFactory _serviceFactory;

        public MainWindow(IModelConverterFactory converterFactory, IDatabase fakeDatabase, ISalesService salesService, IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _converterFactory = converterFactory;
            _database = fakeDatabase;
            _salesService = salesService;
            _serviceFactory = serviceFactory;
        }

        private void BtnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadDataFromFile();
        }

        private void BtnAddData_Click(object sender, RoutedEventArgs e)
        {
            ShowAddDataDialog();
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            SaveDataToFile();
        }

        private void BtnSouhrn_Click(object sender, RoutedEventArgs e)
        {
            ShowSalesSummary();
        }


        private void LoadDataFromFile()
        {
            var dialog = new OpenFileDialog { Filter = "XML soubory (*.xml)|*.xml|Všechny soubory (*.*)|*.*" };
            if (dialog.ShowDialog() != true) return;

            var data = _database.LoadDataFromFile(dialog.FileName);
            if (data == null) return;

            dataGridProdeje.ItemsSource = _salesService.GetListSales();
        }

        private void SaveDataToFile()
        {
            var data = _database.GetCarsData();
            if (data == null)
            {
                MessageBox.Show("Žádná data nebyla načtena.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var saveFileDialog = new SaveFileDialog { Filter = "XML soubory (*.xml)|*.xml" };
            if (saveFileDialog.ShowDialog() == true)
            {
                _database.SaveDataToFile(saveFileDialog.FileName);
            }
        }

        private void ShowAddDataDialog()
        {
            var data = _database.GetCarsData();
            if (data == null)
            {
                MessageBox.Show("Data nejsou načtená", "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var dialog = new ModelSelect();
            if (dialog.ShowDialog() != true) return;

            HandleAddDialogSelection(dialog.selectType);
        }

        private void HandleAddDialogSelection(string? selectedType)
        {
            if (string.IsNullOrEmpty(selectedType))
            {
                MessageBox.Show("Vyberte typ záznamu k přidání.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            switch (selectedType)
            {
                case "DPH":
                    new AddVATWindow(_serviceFactory).ShowDialog();
                    break;

                case "Zaměstnanec":
                    new AddEmployeeWindow(_serviceFactory).ShowDialog();
                    break;

                case "Model":
                    new AddModelWindow(_serviceFactory).ShowDialog();
                    break;

                case "Značka":
                    new AddBrandWindow(_serviceFactory).ShowDialog();
                    break;
                case "Verze":
                    OpenSelectModelAndAddType();
                    break;
                case "Parametr":
                    OpenAddParametrWindow();
                    break;
                case "Prodej":
                    OpenSeleectCar();
                    break;
                case "Prodejce":
                    new AddEmployerWindow(_serviceFactory).ShowDialog();
                    break;
                default:
                    MessageBox.Show("Neznámý typ záznamu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        private void OpenSelectModelAndAddType()
        {
            var selectModel = new SelectModelWindow(_serviceFactory);
            if (selectModel.ShowDialog() == true && selectModel.SelectedModelId.HasValue)
            {
                new AddVersionWindow(_serviceFactory, selectModel.SelectedModelId.Value).ShowDialog();
            }
        }


        private void OpenAddParametrWindow()
        {
            var vyberAuta = new SelectCarWindow(_serviceFactory);
            if (vyberAuta.ShowDialog() == true && vyberAuta.SelectedModelId.HasValue)
            {
                new AddParametrWindow(_serviceFactory, vyberAuta.SelectedModelId.Value).ShowDialog();
            }
        }

        private void OpenSeleectCar()
        {
            var vyberAuta = new SelectCarWindow(_serviceFactory);
            if (vyberAuta.ShowDialog() == true && vyberAuta.SelectedModelId.HasValue)
            {
                new AddSalesWindow(_serviceFactory, vyberAuta.SelectedModelId.Value).ShowDialog();
                dataGridProdeje.ItemsSource = _salesService.GetListSales();
            }
        }

        private void ShowSalesSummary()
        {
            var vikendOnly = checkVikend.IsChecked == true;
            var od = dateOd.SelectedDate ?? DateTime.MinValue;
            var do_ = dateDo.SelectedDate ?? DateTime.MaxValue;

            var summary = _salesService.GetSalesSummary(od, do_, vikendOnly);
            MessageBox.Show(summary.ToString(), "Souhrn prodejů", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
