using System.Windows;

namespace UpdateTask
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Model;
        }

        private MainPageViewModel Model
        {
            get { return new MainPageViewModel(); }
        }
    }
}