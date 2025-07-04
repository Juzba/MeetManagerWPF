using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Data;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using System.Windows;

namespace MeetManagerWPF.ViewModel;

public partial class LoginViewModel() : ObservableObject
{
   

   

	private string? _userName;
	public string? UserName
	{
		get { return _userName; }
		set { _userName = value; }
	}

	private string? _password;

	public string? Password
	{
		get { return _password; }
		set { _password = value; }
	}

	[RelayCommand]
	private void Login()
	{
		MessageBox.Show($"user: {_userName} a pass: {_password}");
	}

}
