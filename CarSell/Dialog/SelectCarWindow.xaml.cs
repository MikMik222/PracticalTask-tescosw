using CarSell.Service;
using System.Windows;
using System.Windows.Controls;


namespace CarSell.Dialog
{

    public partial class SelectCarWindow : Window
    {
        private readonly ICarsService _carService;

        public int? SelectedModelId { get; private set; }

        public SelectCarWindow(IServiceFactory serviceFactory)
        {
            InitializeComponent();
            _carService = serviceFactory.GetService<ICarsService>();
            InitComboBox();
        }

        private void InitComboBox()
        {
            BrandComboBox.ItemsSource = _carService.GetBrands();
            BrandComboBox.SelectedIndex = -1;
        }

        private void BrandComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BrandComboBox.SelectedValue is int znackaId)
            {
                ModelComboBox.ItemsSource = _carService.GetModelsByBrandId(znackaId);
                ModelComboBox.SelectedIndex = -1;
                VersionComboBox.ItemsSource = null;
            }
        }

        private void ModelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ModelComboBox.SelectedValue is int modelId)
            {
                VersionComboBox.ItemsSource = _carService.GetVersionByModelId(modelId);
                VersionComboBox.SelectedIndex = -1;
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (VersionComboBox.SelectedItem is DatabaseFake.Version verze)
            {
                SelectedModelId = verze.Id;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Vyberte značku, model a verzi.");
            }
        }
    }

}