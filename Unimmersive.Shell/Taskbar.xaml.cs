using ManagedShell;
using ManagedShell.AppBar;
using ManagedShell.Interop;
using System;
using System.Windows;
using Unimmersive.Shell.Start;
using Unimmersive.Shell.UserTileWindow;

namespace Unimmersive.Shell
{
    /// <summary>
    /// Interaction logic for Taskbar.xaml
    /// </summary>
    public partial class Taskbar : AppBarWindow
    {
        public StartScreen _start;
        public TileMenu _tilemenu;

        public Taskbar(ShellManager shellManager, AppBarScreen screen, AppBarEdge edge, double desiredHeight)
            : base(shellManager.AppBarManager, shellManager.ExplorerHelper, shellManager.FullScreenHelper, screen, edge, desiredHeight)
        {
            InitializeComponent();

            _explorerHelper.HideExplorerTaskbar = true;

            // Initalize start screen, needed for start button.
            _start = new StartScreen();

            // Initalize user tile window, needed for user tile button.
            _tilemenu = new TileMenu();
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
