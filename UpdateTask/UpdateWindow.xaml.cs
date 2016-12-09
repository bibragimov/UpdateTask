using System.Windows;

namespace UpdateTask
{
    /// <summary>
    ///     Логика взаимодействия для UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        public UpdateWindow()
        {
            InitializeComponent();
            DataContext = Model;
        }

        private UpdateWindowViewModel Model
        {
            get { return new UpdateWindowViewModel(); }
        }
    }
}