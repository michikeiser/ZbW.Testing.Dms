namespace ZbW.DocumentManagementSystem.Client.Views
{
    using System.Windows.Controls;

    using ZbW.DocumentManagementSystem.Client.ViewModels;

    /// <summary>
    /// Interaction logic for SearchView.xaml
    /// </summary>
    public partial class SearchView : UserControl
    {
        public SearchView()
        {
            InitializeComponent();
            DataContext = new SearchViewModel();
        }
    }
}