using System.Diagnostics;
using System.IO;
using System.Windows;

namespace UpdateTask
{
    public class UpdaterService
    {
        public void StrategyOne()
        {
            RemoveFile(Directory.GetCurrentDirectory() + @"\test.exe");
        }

        public void StrategyTwo()
        {
            var path = Directory.GetCurrentDirectory() + @"\UpdateTask.exe";
            RemoveFile(path);

            File.Copy(Directory.GetCurrentDirectory() + @"\test.exe", path);

            if (File.Exists(path))
            {
                Process.Start(path);
            }

            Application.Current.Shutdown();
        }

        private void RemoveFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}