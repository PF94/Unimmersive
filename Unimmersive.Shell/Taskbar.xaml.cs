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
using ManagedShell;
using ManagedShell.AppBar;
using ManagedShell.Interop;

namespace Unimmersive.Shell
{
    /// <summary>
    /// Interaction logic for Taskbar.xaml
    /// </summary>
    public partial class Taskbar : AppBarWindow
    {
        public Taskbar(ShellManager shellManager, AppBarScreen screen, AppBarEdge edge, double desiredHeight)
            : base(shellManager.AppBarManager, shellManager.ExplorerHelper, shellManager.FullScreenHelper, screen, edge, desiredHeight)
        {
            InitializeComponent();

            _explorerHelper.HideExplorerTaskbar = true;
        }

        protected override void CustomClosing()
        {
            if (AllowClose)
            {
                _explorerHelper.HideExplorerTaskbar = false;
            }
        }

        private void Taskbar_OnLocationChanged(object? sender, EventArgs e)
        {
            // primarily for win7/8, they will set up the appbar correctly but then put it in the wrong place
            double desiredTop = Screen.Bounds.Bottom / DpiScale - Height;

            if (Top != desiredTop) Top = desiredTop;
        }

        public override void SetPosition()
        {
            base.SetPosition();

            // Do stuff on startup and when displays change (when running as shell)
        }

        public override void AfterAppBarPos(bool isSameCoords, NativeMethods.Rect rect)
        {
            base.AfterAppBarPos(isSameCoords, rect);

            // Do stuff when Explorer tells us where to move our AppBar, such as on display change
        }

        public void Dispose() // don't think this works
        {
            _explorerHelper.HideExplorerTaskbar = false;
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            ((App)Application.Current).ExitGracefully();
        }
    }
}
