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

namespace Unimmersive.Settings.Controls
{
    /// <summary>
    /// Interaction logic for SettingsButton.xaml
    /// </summary>
    public partial class SettingsButton : UserControl
    {
        //public Frame optionsFrame = new MainWindow().OptionsFrame;

        public SettingsButton()
        {
            InitializeComponent();
        }

        private void ButtonClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Unimplemented", "Nope, not implemented.");
        }
    }
}
