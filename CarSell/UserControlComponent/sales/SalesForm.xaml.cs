using CarSell.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CarSell.UserControlComponent
{
    public partial class SalesForm : UserControl
    {
        public string CostText
        {
            get { return CostTextBox.Text; }
            set { CostTextBox.Text = value; }
        }
        public SalesForm()
        {
            InitializeComponent();
        }

    }
}
