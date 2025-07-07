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

            OnLogin();
        }

        private void OnLogin()
        {
            _userStore.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(UserStore.IsUserLogged))
                {
                    // Hide register and login
                    LoginVisibility = _userStore.IsUserLogged;
                    // Delete strings username and password in textbox
                    UserName = $"{_userStore.User?.Name ?? "UserName"}";
                    // Role Admin? Show page for admin
                    if (_userStore.User?.Role.RoleName == "Admin") AdminPageVisibility = Visibility.Visible;
                }
            };
        }


        [ObservableProperty]
        private string? userName;

        [ObservableProperty]
        private bool loginVisibility;

        [ObservableProperty]
        private Visibility adminPageVisibility = Visibility.Collapsed;

        [RelayCommand]
        private void NavigateToLogin() => _navigation.NavigateToPage<LoginPage>();


        [RelayCommand]
        private void NavigateToRegister() => _navigation.NavigateToPage<RegisterPage>();

        [RelayCommand]
        private void NavigateToHomePage() => _navigation.NavigateToPage<HomePage>();

        [RelayCommand]
        private void NavigateToAdminPage()
        {
            if (_userStore.User?.Role.RoleName == "Admin")
                _navigation.NavigateToPage<AdminPage>();
        }


        [RelayCommand]
        private void Logout()
        {
            _userStore.IsUserLogged = false;
            _userStore.User = null;
            _navigation.NavigateToPage<LoginPage>();
            AdminPageVisibility = Visibility.Collapsed;

        }




    }
}
