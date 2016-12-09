using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using UpdateTask.Utils;

namespace UpdateTask
{
    public class MainPageViewModel : Notifier
    {
        private string _version;

        public MainPageViewModel()
        {
            UpdateAppCommand = new RelayCommand(UpdateAppMethod);

            Unit();
        }

        public ICommand UpdateAppCommand { get; set; }

        public string VersionFile
        {
            get { return _version; }
            set
            {
                _version = value;
                OnPropertyChanged();
            }
        }

        private void UpdateAppMethod()
        {
            var window = new UpdateWindow();
            window.Show();

            var viewModel = window.DataContext as UpdateWindowViewModel;
            viewModel.ClosedWindow += UpdateWindow_Closed;
        }

        private void UpdateWindow_Closed(object sender, EventArgs e)
        {
            var path = Directory.GetCurrentDirectory() + @"\test.exe";
            Process.Start(path);

            Application.Current.Shutdown();
        }

        private void Unit()
        {
            var res = Process.GetCurrentProcess().MainModule.ModuleName.Replace(".vshost", "");

            VersionFile = Assembly.GetExecutingAssembly()
                .GetName().Version.ToString();

            switch (res)
            {
                case "UpdateTask.exe":
                    new UpdaterService().StrategyOne();
                    break;

                case "test.exe":
                    new UpdaterService().StrategyTwo();
                    break;
            }
        }
    }
}