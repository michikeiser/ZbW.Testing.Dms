namespace ZbW.SoftwareTesting.DocumentManagementSystem.Client.Views
{
    using System.Windows;

    using ZbW.SoftwareTesting.DocumentManagementSystem.Client.ViewModels;

    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel(this);
        }
    }
}