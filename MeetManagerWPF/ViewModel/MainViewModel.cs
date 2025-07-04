using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View.Pages;

namespace MeetManagerWPF.ViewModel
{
    public partial class MainViewModel(INavigation navigation) : ObservableObject
    {
        private readonly INavigation _navigation = navigation;

        [RelayCommand]
        private void NavigateToLogin() => _navigation.NavigateToPage<LoginPage>();



        [RelayCommand]
        private void NavigateToRegister() => _navigation.NavigateToPage<RegisterPage>();






    }
}
