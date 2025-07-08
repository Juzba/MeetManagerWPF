using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Model;
using MeetManagerWPF.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace MeetManagerWPF.ViewModel
{
    public partial class AdminViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        public AdminViewModel(IDataService dataService)
        {
            _dataService = dataService;
            LoadUsersListCommand.Execute(null);
            Users.CollectionChanged += Users_CollectionChanged;
        }


        [ObservableProperty]
        private ObservableCollection<User> users = [];





        [RelayCommand]
        private async Task LoadUsersList()
        {
            var usersData = await _dataService.GetUsersList();
            Users = new ObservableCollection<User>(usersData);

        }



        private void Users_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs? e)
        {
            MessageBox.Show("");
        }










    }
}
