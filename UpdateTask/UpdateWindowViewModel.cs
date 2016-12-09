using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using UpdateTask.Utils;

namespace UpdateTask
{
    public class UpdateWindowViewModel : Notifier
    {
        private string _newVersionApp;
        private string _versionApp;

        public UpdateWindowViewModel()
        {
            UpdateCommand = new RelayCommand(UpdateMethod);
            GetVersionApplication();
        }

        public string VersionApp
        {
            get { return _versionApp; }
            set
            {
                _versionApp = value;
                OnPropertyChanged();
            }
        }

        public string NewVersionApp
        {
            get { return _newVersionApp; }
            set
            {
                _newVersionApp = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateCommand { get; set; }

        public event EventHandler ClosedWindow;

        private void GetVersionApplication()
        {
            VersionApp = Assembly.GetExecutingAssembly()
                .GetName().Version.ToString();

            NewVersionApp = FileVersionInfo.GetVersionInfo(Path.GetFullPath(@"new\UpdateTask.exe"))
                .FileVersion;
        }

        private void UpdateMethod()
        {
            var path = Directory.GetCurrentDirectory() + @"\test.exe";
            UpdateFile(path);

            if (ClosedWindow != null)
            {
                ClosedWindow.Invoke(this, EventArgs.Empty);
            }

            Application.Current.Windows.Cast<Window>()
                .Single(w => w.DataContext == this).Close();
        }

        private void UpdateFile(string path)
        {
            File.Copy(Path.GetFullPath(@"new\UpdateTask.exe"), path);
        }
    }
}