using System.Windows;

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
    }
}
