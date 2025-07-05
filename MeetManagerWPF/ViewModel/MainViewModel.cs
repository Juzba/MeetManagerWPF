using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly INavigation _navigation;
        private readonly UserStore _userStore;

        public MainViewModel(INavigation navigation, UserStore userStore)
        {
            _navigation = navigation;
            _userStore = userStore;
            loginVisibility = _userStore.IsUserLogged;
        }



        [ObservableProperty]
        private bool loginVisibility; 




        [RelayCommand]
        private void NavigateToLogin() => _navigation.NavigateToPage<LoginPage>();


        [RelayCommand]
        private void NavigateToRegister() => _navigation.NavigateToPage<RegisterPage>();






    }
}
