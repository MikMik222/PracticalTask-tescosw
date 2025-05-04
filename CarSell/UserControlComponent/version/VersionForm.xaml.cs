using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CarSell.UserControlComponent
{
    public partial class VersionForm : UserControl
    {
        public string VersionText
        {
            get { return VersionTextBox.Text; }
            set { VersionTextBox.Text = value; }
        }
        public VersionForm()
        {
            InitializeComponent();
        }


    }
}
