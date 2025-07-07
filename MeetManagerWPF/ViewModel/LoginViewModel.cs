using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel(IDataService dataService, UserStore userStore, IHashService hashService) : ObservableObject
{
    private readonly IDataService _dataService = dataService;
    private readonly UserStore _userStore = userStore;
    private readonly IHashService _hashService = hashService;


    // USERNAME //
    private string _userName = "";
    public string UserName
    {
        get { return _userName; }
        set { SetProperty(ref _userName, value); }
    }

    // PASSWORD //
    private string _password = "";
    public string Password
    {
        get => _password;
        set { SetProperty(ref _password, value); }
    }


    [RelayCommand]
    private async Task Login()
    {

        var user = await _dataService.GetUser(_userName);
        if (user == null || !_hashService.VerifyPassword(_password, user.PasswordHash))
        {
            Password = "";
            return;
        }

        // LOGIN CONFIRMED
        UserName = "";
        Password = "";

        _userStore.User = user;
        _userStore.IsUserLogged = true;

    }
}
