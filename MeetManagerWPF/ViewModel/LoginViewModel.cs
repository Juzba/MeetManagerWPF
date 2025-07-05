using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Data;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Threading.Tasks;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel(IDataService dataService, INavigation navigation, UserStore userStore) : ObservableObject
{
	private readonly IDataService _dataService = dataService;
	private readonly INavigation _navigation = navigation;
	private readonly UserStore _userStore = userStore;

   

	private string _userName ="";
	public string UserName
	{
		get { return _userName; }
		set { _userName = value; }
	}

	private string _password = "";

	public string Password
	{
		get { return _password; }
		set { _password = value; }
	}

	[RelayCommand]
	private async Task Login()
	{
		var user = await _dataService.LoginConfirmation(_userName, _password);
		if (user == null) return;

		_userStore.IsUserLogged = true;
		_userStore.User = user;

		MessageBox.Show($"user: {_userName} a pass: {_password} a : {user.Role.RoleName}");
	}

}
