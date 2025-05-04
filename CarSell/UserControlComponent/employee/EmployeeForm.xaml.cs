using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarSell.UserControlComponent
{
    public partial class EmployeeForm : UserControl
    {
        public string Name
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        public string Surname
        {
            get => SurnameTextBox.Text;
            set => SurnameTextBox.Text = value;
        }

        public int? SelectedSellerId
        {
            get => SellerComboBox.SelectedValue as int?;
            set => SellerComboBox.SelectedValue = value;
        }
        public EmployeeForm()
        {
            InitializeComponent();
        }

    }
}
