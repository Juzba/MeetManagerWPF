using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    public partial class LoginViewModel: ObservableObject
    {
        private readonly LoginView _loginView;
        public LoginViewModel(LoginView loginView)
        {
            _loginView = loginView;
        }

        //[ObservableProperty]
        //private string? loginUserName;

        //[ObservableProperty]
        //private string? loginPassword;

        private string? _loginUserName;

        public string? LoginUserName
        {
            get { return _loginUserName; }
            set { _loginUserName = value; }
        }





        [RelayCommand]
        private void Login()
        {
            MessageBox.Show(_loginUserName);
        }



        [RelayCommand]
        private void NavigateToRegister()
        {
            var registerPage = new RegisterPage();
            _loginView.FrameLogin.Navigate(registerPage);
            registerPage.DataContext = this;
        }

        [RelayCommand]
        private void NavigateToLogin()
        {
            var loginPage = new LoginPage();
            _loginView.FrameLogin.Navigate(loginPage);
            loginPage.DataContext = this;
        }


    }
}
