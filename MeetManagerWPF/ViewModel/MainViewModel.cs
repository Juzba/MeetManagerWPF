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

        // ON LOGIN //
        private void OnLogin()
        {
            _userStore.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(UserStore.IsUserLogged))
                {
                    // Hide register and login
                    LoginVisibility = _userStore.IsUserLogged;

                    // Show username
                    UserName = $"{_userStore.User?.Name ?? "UserName"}";

                    // Role Admin? Show page for admin
                    if (_userStore.User?.Role.RoleName == "Admin")
                    {
                        AdminPageVisibility = Visibility.Visible;
                        ManagerPageVisibility = Visibility.Visible;
                    }

                    // Role Manager? Show page for manager
                    if (_userStore.User?.Role.RoleName == "Manager") ManagerPageVisibility = Visibility.Visible;

                }
            };
        }

        // USERNAME //
        [ObservableProperty]
        private string? userName;

        // LOGINVISIBILITY //
        [ObservableProperty]
        private bool loginVisibility;

        // ADMIN PAGE VISIBILITY //
        [ObservableProperty]
        private Visibility adminPageVisibility = Visibility.Collapsed;

        // MANAGER PAGE VISIBILITY //
        [ObservableProperty]
        private Visibility managerPageVisibility = Visibility.Collapsed;

        [RelayCommand]
        private void Logout()
        {
            _userStore.IsUserLogged = false;
            _userStore.User = null;
            _navigation.NavigateToPage<LoginPage>();
            AdminPageVisibility = Visibility.Collapsed;
            ManagerPageVisibility = Visibility.Collapsed;
        }


        /// <summary>
        /// NAVIGATION
        /// </summary>

        // TO LOGIN PAGE //
        [RelayCommand]
        private void NavigateToLogin() => _navigation.NavigateToPage<LoginPage>();

        // TO REGISTER PAGE //
        [RelayCommand]
        private void NavigateToRegister() => _navigation.NavigateToPage<RegisterPage>();

        // TO HOME PAGE //
        [RelayCommand]
        private void NavigateToHomePage() => _navigation.NavigateToPage<HomePage>();

        // TO EVENTS PAGE //
        [RelayCommand]
        private void NavigateToEventsPage() => _navigation.NavigateToPage<EventsPage>();
        // TO ADD EVENT PAGE //
        [RelayCommand]
        private void NavigateToAddEventPage() => _navigation.NavigateToPage<ManagerPage>();

        // TO ADMIN PAGE //
        [RelayCommand]
        private void NavigateToAdminPage()
        {
            if (_userStore.User?.Role.RoleName == "Admin")
                _navigation.NavigateToPage<AdminPage>();
        }

        // LOGOUT //
    }
}
