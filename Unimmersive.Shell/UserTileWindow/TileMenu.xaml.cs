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
using System.Windows.Shapes;
using Unimmersive.Shell.Methods;

namespace Unimmersive.Shell.UserTileWindow
{
    /// <summary>
    /// Interaction logic for UserTileWindow.xaml
    /// </summary>
    public partial class TileMenu : Window
    {
        public TileMenu()
        {
            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            UserTileImage.Source = UserTileMethods.getImage(Environment.UserName);
            Title.Content = Environment.UserName;
        }
    }
}
