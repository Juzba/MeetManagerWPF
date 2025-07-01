using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        // viewmodel nesmi obsahovat di na view!!!

        [ObservableProperty]
        private string? userNameLogin;


        [RelayCommand]
        private void Login()
        {

            MessageBox.Show(UserNameLogin);
        }



        [RelayCommand]
        private void NavigateToRegister()
        {
        }

        [RelayCommand]
        private void NavigateToLogin()
        {
        }


    }
}
