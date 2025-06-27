using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    
     public class LoginViewModel : ObservableObject
    {
        private readonly Login _login;

        public LoginViewModel(Login login)
        {
            _login = login;
            BtnToRegisterPage = new RelayCommand(ToRegisterPage);
        }




        public IRelayCommand BtnToRegisterPage { get; }
        public void ToRegisterPage()
        {
            MessageBox.Show("register page");
           _login.loginFrame.Navigate(new RegisterPage());
        }

    }
}
