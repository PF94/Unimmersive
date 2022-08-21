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
using Unimmersive.Settings.Controls;

namespace Unimmersive.Settings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OptionsPanelListLoaded(object sender, EventArgs e)
        {
            string[] pets = { "dog", "cat", "bird" }; //placeholder until i make proper settings
            foreach (string value in pets)
            {
                SettingsButton button = new SettingsButton();
                button.buttonName.Content = value;
                OptionsPanelList.Children.Add(button);
            }
        }
    }
}
