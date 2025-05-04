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
    public partial class EmployerForm : UserControl
    {
        public string Name
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        public string Office
        {
            get => OfficeTextBox.Text;
            set => OfficeTextBox.Text = value;
        }

        public string Contact
        {
            get => ContactTextBox.Text;
            set => ContactTextBox.Text = value;
        }

        public EmployerForm()
        {
            InitializeComponent();
        }

    }
}
