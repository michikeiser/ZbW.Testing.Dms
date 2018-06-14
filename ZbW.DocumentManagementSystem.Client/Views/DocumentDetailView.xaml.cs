namespace ZbW.DocumentManagementSystem.Client.Views
{
    using System.Windows.Controls;

    using ZbW.DocumentManagementSystem.Client.ViewModels;

    /// <summary>
    /// Interaction logic for NewDocumentView.xaml
    /// </summary>
    public partial class DocumentDetailView : UserControl
    {
        public DocumentDetailView(string benutzer)
        {
            InitializeComponent();
            DataContext = new DocumentDetailViewModel(benutzer);
        }
    }
}