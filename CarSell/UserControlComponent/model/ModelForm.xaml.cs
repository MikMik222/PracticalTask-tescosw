using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
namespace CarSell.UserControlComponent
{
    public partial class ModelForm : UserControl
    {
        public string ModelNazev
        {
            get => ModelNazevTextBox.Text;
            set => ModelNazevTextBox.Text = value;
        }

        public int? SelectedZnackaId
        {
            get => BrandComboBox.SelectedValue as int?;
            set => BrandComboBox.SelectedValue = value;
        }

        public ModelForm()
        {
            InitializeComponent();
        }

    }
}
