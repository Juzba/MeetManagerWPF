using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel(IDataService dataService, UserStore userStore, IHashService hashService, INavigation navigation) : ObservableObject
{
    private readonly IDataService _dataService = dataService;
    private readonly UserStore _userStore = userStore;
    private readonly IHashService _hashService = hashService;
    private readonly INavigation _navigation = navigation;


    // USERNAME //
    [ObservableProperty]
    private string? email;



    // PASSWORD //
    [ObservableProperty]
    private string? password;
  


    // LOGIN COMMAND //
    [RelayCommand]
    private async Task Login()
    {
        // INSTANT LOGIN //
        Email = "Juzba@gmail.com"; // delete this


        var user = await _dataService.GetUser(Email);
        //if (user == null || !_hashService.VerifyPassword(_password, user.PasswordHash))
        //{
        //    Password = "";
        //    return;
        //}

        // LOGIN CONFIRMED
        Email = "";
        Password = "";

        _userStore.User = user;
        _userStore.IsUserLogged = true;

        _navigation.NavigateToPage<HomePage>();

    }
}
