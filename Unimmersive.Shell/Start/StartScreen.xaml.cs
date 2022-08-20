using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Diagnostics;
using System.Windows;
using System.Xml.Linq;
using Unimmersive.Shell.Start.Controls;
using Unimmersive.Shell.Methods;
using System.Windows.Media;

namespace Unimmersive.Shell.Start
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class StartScreen : Window
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        // closing the window and then clicking start button will crash app, so do this.
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            return;
        }

        // add tiles when panel is loaded
        private void onPanelLoaded(object sender, RoutedEventArgs e)
        {
            var FOLDERID_AppsFolder = new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}"); // FIXME: this doesn't work on windows 7 apparantly?
            ShellObject appsFolder = (ShellObject)KnownFolderHelper.FromKnownFolderId(FOLDERID_AppsFolder);
            foreach (var app in (IKnownFolder)appsFolder)
            {
                Tile tile = new Tile();
                tile.TileIcon.Source = app.Thumbnail.MediumBitmapSource;
                System.Drawing.Color colorBG = ColorMethods.GetDominantColor(app.Thumbnail.SmallBitmap);
                System.Drawing.Color colorBR = ColorMethods.ChangeColorBrightness(colorBG, -0.5f);
                System.Drawing.Color colorFG = ColorMethods.IdealTextColor(colorBG);
                tile.TileBox.Fill = new SolidColorBrush(ColorMethods.SDColorToWMColor(colorBG));
                tile.TileBox.Stroke = new SolidColorBrush(ColorMethods.SDColorToWMColor(colorBR));
                tile.TileName.Foreground = new SolidColorBrush(ColorMethods.SDColorToWMColor(colorFG));
                tile.TileName.Text = app.Name;
                TilesPanel.Children.Add(tile);
            }
        }
    }
}
