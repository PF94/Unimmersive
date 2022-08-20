using System;
using System.Drawing;
using System.Windows;
using Unimmersive.Shell.Start.Controls;

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
            string[] placeholder = { "squareBracket", "Sangria", "2003page" }; //references to past grkb projects
            foreach (string name in placeholder)
            {
                Tile tile = new Tile();
                tile.TileName.Content = name;
                TilesPanel.Children.Add(tile);
            }
        }
    }
}
