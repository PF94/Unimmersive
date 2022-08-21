using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Unimmersive.Shell.Start.Controls
{
    /// <summary>
    /// Interaction logic for Tile.xaml
    /// </summary>
    public partial class Tile : UserControl
    {
        public string Executable { get; internal set; }

        public Tile()
        {
            InitializeComponent();
        }

        private void TileClick(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Clicked Tile, Executable: " + Executable);
            Process.Start("explorer.exe", @" shell:appsFolder\" + Executable);
            Window.GetWindow(this).Hide();
        }
    }
}
