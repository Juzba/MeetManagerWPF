using MeetManagerWPF.Services;
using MeetManagerWPF.ViewModel.Manager;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro AddEventPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage(ManagerViewModel managerViewModel)
        {
            InitializeComponent();
            DataContext = managerViewModel;

        }
    }
}
