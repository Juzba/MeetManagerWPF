using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    
    partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel()
        {
            BtnToRegisterPage = new RelayCommand(ToRegisterPage);
        }




        public IRelayCommand BtnToRegisterPage { get; }
        public void ToRegisterPage()
        {
            MessageBox.Show("register page");
            loginFrame.Navigate(new RegisterPage());
        }

    }
}
