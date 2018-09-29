namespace ZbW.Testing.Dms.Client.ViewModels
{
    using System.Windows;

    using Prism.Commands;
    using Prism.Mvvm;

    using ZbW.Testing.Dms.Client.Views;

    internal class LoginViewModel : BindableBase
    {
        private readonly LoginView _loginView;

        private MainView _mainView;
        private string _benutzername;

        public LoginViewModel()
        {
            this.CmdLogin = new DelegateCommand(OnCmdLogin, OnCanLogin);
            this.CmdAbbrechen = new DelegateCommand(OnCmdAbbrechen);
        }

        public LoginViewModel(LoginView loginView)
        {
            _loginView = loginView;
            this.CmdLogin = new DelegateCommand(OnCmdLogin, OnCanLogin);
            this.CmdAbbrechen = new DelegateCommand(OnCmdAbbrechen);
        }

        public DelegateCommand CmdAbbrechen { get; }

        public DelegateCommand CmdLogin { get; }

        public MainView MainView
        {
            get
            {
                return _mainView;
            }
        }

        public string Benutzername
        {
            get
            {
                return _benutzername;
            }

            set
            {
                if (SetProperty(ref _benutzername, value))
                {
                    CmdLogin.RaiseCanExecuteChanged();
                }
            }
        }

        private bool OnCanLogin()
        {
            return !string.IsNullOrEmpty(Benutzername);
        }

        private void OnCmdAbbrechen()
        {
            Application.Current.Shutdown();
        }

        private void OnCmdLogin()
        {
            if (string.IsNullOrEmpty(Benutzername))
            {
                if (_loginView != null)
                {
                    MessageBox.Show("Bitte tragen Sie einen Benutzernamen ein...");
                }
                return;
            }

            this._mainView = new MainView(Benutzername);


            if (_loginView != null)
            {
                this._mainView.Show();
                _loginView.Close();
            }
        }
    }
}