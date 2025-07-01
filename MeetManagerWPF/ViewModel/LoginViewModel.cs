using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel(INavigation navigation) : ObservableObject
{
    private readonly INavigation _navigation = navigation;


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
        _navigation.NavigateToPage("RegisterPage");
    }

    [RelayCommand]
    private void NavigateToLogin()
    {
        _navigation.NavigateToPage("LoginPage");
    }


}
