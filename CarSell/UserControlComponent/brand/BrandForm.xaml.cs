using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CarSell.UserControlComponent
{
    public partial class BrandForm : UserControl
    {
        public string BrandText
        {
            get { return NameTextBox.Text; }
            set { NameTextBox.Text = value; }
        }
        public BrandForm()
        {
            InitializeComponent();
        }


    }
}
