namespace ZbW.SoftwareTesting.DocumentManagementSystem.Client.Views
{
    using System.Windows;

    using ZbW.SoftwareTesting.DocumentManagementSystem.Client.ViewModels;

    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView(string benutzername)
        {
            InitializeComponent();
            DataContext = new MainViewModel(benutzername);
        }
    }
}