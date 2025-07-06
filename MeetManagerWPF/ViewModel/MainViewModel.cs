using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View.Pages;

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

            _userStore.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(UserStore.IsUserLogged))
                {
                    LoginVisibility = _userStore.IsUserLogged;
                    UserName =  $"{_userStore.User?.Name ?? "UserName"} - {_userStore.User?.Role.RoleName ?? "Role"}";
                }
            };
        }


        [ObservableProperty]
        private string? userName;

        [ObservableProperty]
        private bool loginVisibility;




        [RelayCommand]
        private void NavigateToLogin() => _navigation.NavigateToPage<LoginPage>();


        [RelayCommand]
        private void NavigateToRegister() => _navigation.NavigateToPage<RegisterPage>();


        [RelayCommand]
        private void Logout()
        {
            _userStore.IsUserLogged = false;
            _userStore.User = null;
            _navigation.NavigateToPage<LoginPage>();

        }




    }
}
