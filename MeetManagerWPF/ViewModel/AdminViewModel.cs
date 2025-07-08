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

        public AdminViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadUsersListCommand.Execute(null);
        }


        [ObservableProperty]
        private ObservableCollection<User> users = [];





        [RelayCommand]
        private async Task LoadUsersList()
        {
            var usersData = await _dataService.GetUsersList();
            Users = new ObservableCollection<User>(usersData);

        }


        // SAVE CHANGES //
        [RelayCommand]
        private async Task SaveChanges() => await _dataService.UpdateUsersList();


        // DELETE USER //
        [RelayCommand]
        private async Task DeleteUser()
        {

        }
     









    }
}
