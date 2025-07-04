using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using MeetManagerWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using System.Windows.Controls;

namespace MeetManagerWPF.Services
{

    public interface INavigation
    {
        void NavigateToPage<TPage>() where TPage : Page;
    }

    public class Navigation(IHost host) : INavigation
    {
        private readonly IHost _host = host;

        public void NavigateToPage<TPage>() where TPage : Page
        {
            var mainWindow = _host.Services.GetRequiredService<MainWindow>();
            var page = _host.Services.GetRequiredService<TPage>();
            mainWindow.FrameMW.Navigate(page);
        }

    }
}
