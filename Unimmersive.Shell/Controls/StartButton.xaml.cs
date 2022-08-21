using System.Windows;
using System.Windows.Controls;

namespace Unimmersive.Shell.Controls
{
    /// <summary>
    /// Interaction logic for StartButton.xaml
    /// </summary>
    public partial class StartButton : UserControl
    {
        public static DependencyProperty HostProperty = DependencyProperty.Register("Host", typeof(Taskbar), typeof(StartButton));

        public Taskbar Host
        {
            get { return (Taskbar)GetValue(HostProperty); }
            set { SetValue(HostProperty, value); }
        }

        public StartButton()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Host._start.IsVisible)
            {
                Host._start.Show();
            }
            else
            {
                Host._start.Hide();
            }
        }
    }
}
