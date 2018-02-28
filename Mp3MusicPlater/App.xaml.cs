using Mp3.Core;
using System.Windows;

namespace Mp3MusicPlater
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();

            Current.MainWindow = new MainWindow();

            Current.MainWindow.Show();
        }

        private static void ApplicationSetup()
        {
            IoC.Setup();
        }
    }
}
