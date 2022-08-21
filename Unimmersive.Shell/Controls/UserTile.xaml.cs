using System;
using System.Collections.Generic;
using System.Drawing;
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
using Unimmersive.Shell.Methods;
using Image = System.Drawing.Image;

namespace Unimmersive.Shell.Controls
{
    /// <summary>
    /// Interaction logic for UserTile.xaml
    /// </summary>
    public partial class UserTile : UserControl
    {
        public static DependencyProperty HostProperty = DependencyProperty.Register("Host", typeof(Taskbar), typeof(UserTile));

        public Taskbar Host
        {
            get { return (Taskbar)GetValue(HostProperty); }
            set { SetValue(HostProperty, value); }
        }

        public UserTile()
        {
            InitializeComponent();
        }

        private void TileClick(object sender, MouseButtonEventArgs e)
        {
            if (!Host._tilemenu.IsVisible)
            {
                Host._tilemenu.Show();
            }
            else
            {
                Host._tilemenu.Hide();
            }
        }

        private void OnInitalized(object sender, EventArgs e)
        {
            UserTileImage.Source = UserTileMethods.getImage(Environment.UserName);
        }
    }
}
