using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Model;
using MeetManagerWPF.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MeetManagerWPF.ViewModel
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        public ICommand RemoveUserCmd { get; } = default!;

        public AdminViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadUsersListCommand.Execute(null);
            RemoveUserCmd = new RelayCommand<object?>(RemoveUser);
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




        [RelayCommand]
        private void RemoveUser(object? param)
        {
            if (param is not User user) return;

            MessageBox.Show(user.Name);


        }
     









    }
}
