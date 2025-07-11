using CommunityToolkit.Mvvm.Messaging;
using MeetManagerWPF.Services;
using MeetManagerWPF.ViewModel.Manager;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro AddEventPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        private readonly IHost _host;
        public ManagerPage(ManagerViewModel managerViewModel, IHost host)
        {
            InitializeComponent();
            DataContext = managerViewModel;
            _host = host;


            WeakReferenceMessenger.Default.Register<NavigateMessage>(this, (r, m) =>
            {
                if (m.FrameName == Constants.FrameManager)
                {
                    var page = (Page)_host.Services.GetRequiredService(m.PageType)!;
                    FrameManagerWiew.Navigate(page);
                }
            });

        }
    }
}
