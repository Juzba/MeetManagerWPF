using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Data;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Threading.Tasks;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel(IDataService dataService, UserStore userStore) : ObservableObject
{
	private readonly IDataService _dataService = dataService;
	private readonly UserStore _userStore = userStore;

   

	private string _userName ="";
	public string UserName
	{
		get { return _userName; }
		set { SetProperty(ref _userName, value); }
	}

	private string _password = "";
	public string Password
	{
		get { return _password; }
		set { SetProperty(ref _password, value); }
	}


	[RelayCommand]
	private async Task Login()
	{
		var user = await _dataService.LoginConfirmation(_userName, _password);
		if (user == null)
		{
			Password = "";
			return;
		}

		UserName = "";
		Password = "";

		_userStore.User = user;
		_userStore.IsUserLogged = true;

	}



}
