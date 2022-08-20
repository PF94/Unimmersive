using ManagedShell;
using ManagedShell.AppBar;
using ManagedShell.Common.Enums;
using System.Windows;

namespace Unimmersive.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Taskbar _appBar;
        private readonly ShellManager _shellManager;

        public App()
        {
            // Initialize the default configuration.
            ShellConfig config = ShellManager.DefaultShellConfig;

            // Customize tasks service options.
            config.EnableTasksService = true; // controls whether the tasks objects are instantiated in ShellManager, true by default
            config.AutoStartTasksService = false; // controls whether the tasks service is started as part of ShellManager instantiation, true by default
            config.TaskIconSize = IconSize.Medium; // sets the size of window icon to fetch, small (16pt) by default

            // Initialize the shell manager.
            _shellManager = new ShellManager(config);

            // Initialize the tasks service, since we disabled auto-start above.
            _shellManager.Tasks.Initialize();

            _appBar = new Taskbar(_shellManager, AppBarScreen.FromPrimaryScreen(), AppBarEdge.Bottom, 30);
            _appBar.Show();
        }

        public void ExitGracefully()
        {
            _shellManager.AppBarManager.SignalGracefulShutdown();
            Current.Shutdown();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            ExitApp();
        }

        private void App_OnSessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            ExitApp();
        }

        private void ExitApp()
        {
            _appBar.Dispose();
        }
    }
}
