using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Model;
using MeetManagerWPF.Services;
using System.Collections.ObjectModel;

namespace MeetManagerWPF.ViewModel
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly IDataService _dataService;


        [ObservableProperty]
        private ObservableCollection<User> users = [];


        public AdminViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadUsersListCommand.Execute(null);
        }


        [RelayCommand]
        private async Task LoadUsersList()
        {
            var usersData = await _dataService.GetUsersList();
            Users = new ObservableCollection<User>(usersData);
        }


       











    }
}
