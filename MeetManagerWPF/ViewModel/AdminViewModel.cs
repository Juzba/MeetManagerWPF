﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Model;
using MeetManagerWPF.Services;
using System.Collections.ObjectModel;
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
            RemoveUserCmd = new AsyncRelayCommand<object?>(RemoveUser);
        }



        [ObservableProperty]
        public ObservableCollection<Role> roleList = [new Role { Id = "AdminRoleId-51sa9-sdd18", RoleName = "Admin" }, new Role { Id = "UserRoleId-54sa9-sda87", RoleName = "User" }, new Role { Id = "ManagerRoleId-21ga5-sda13", RoleName = "Manager" }];



        [ObservableProperty]
        private ObservableCollection<User> users = [];

        // LOAD DATA //
        [RelayCommand]
        private async Task LoadUsersList()
        {
           var usersData = await _dataService.GetUsersList();
        
            Users = new ObservableCollection<User>(usersData);

        }


        // SAVE CHANGES //
        [RelayCommand]
        private async Task SaveChanges()
        {
            await _dataService.UpdateUsersList();
        }



        // REMOVE USER //
        [RelayCommand]
        private async Task RemoveUser(object? param)
        {
            if (param is not User user) return;

            await _dataService.DeleteUser(user);
            LoadUsersListCommand.Execute(null);
        }










    }
}
