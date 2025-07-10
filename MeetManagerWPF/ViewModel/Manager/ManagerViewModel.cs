using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Services;
using MeetManagerWPF.View.Pages;
using MeetManagerWPF.View.Pages.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetManagerWPF.ViewModel.Manager
{
    public partial class ManagerViewModel(INavigation navigation) : ObservableObject
    {
        private readonly INavigation _navigation = navigation;

        [RelayCommand]
        private void NavigateToNewEvent()
        {
            _navigation.NavigateToPageTwo<CreateEventPage>();
        }

        [RelayCommand]
        private void NavigateToSeznam()
        {
            _navigation.NavigateToPageTwo<CreateEventPage>();
        }







    }
}
