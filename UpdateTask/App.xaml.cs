using System.Linq;
using System.Reflection;
using System.Windows;

namespace UpdateTask
{
    /// <summary>
    ///     Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Contains("ShowVersion") || e.Args.Contains("-ShowVersion"))
            {
                MessageBox.Show("Версия программы: " + Assembly.GetExecutingAssembly()
                    .GetName().Version);

                Current.Shutdown();
            }
            else
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
        }
    }
}