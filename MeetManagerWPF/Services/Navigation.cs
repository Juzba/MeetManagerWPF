using MeetManagerWPF.View.Pages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MeetManagerWPF.Services
{

    public interface INavigation
    {
        /// <summary>
        /// Navigate to page in Frame in Main Window
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        void NavigateToPage<TPage>() where TPage : Page;
        void NavigateToPageTwo<TPage>() where TPage : Page;

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

        public void NavigateToPageTwo<TPage>() where TPage : Page
        {
            var mainWindow = _host.Services.GetRequiredService<ManagerPage>();
            var page = _host.Services.GetRequiredService<TPage>();
            mainWindow.FrameManagerWiew.Navigate(page);
        }

    }
}


//public class NavigationService
//{
//    private ManagerPage? _currentManagerPage;

//    public void SetCurrentManagerPage(ManagerPage page)
//    {
//        _currentManagerPage = page;
//    }

//    public void NavigateInManager<TSubPage>(IServiceProvider provider) where TSubPage : Page
//    {
//        if (_currentManagerPage == null)
//            throw new InvalidOperationException("ManagerPage not set");

//        var page = provider.GetRequiredService<TSubPage>();
//        _currentManagerPage.InnerFrame.Navigate(page);
//    }
//}

//protected override void OnNavigatedTo(NavigationEventArgs e)
//{
//    var navigationService = ... // z DI nebo přes App.Current
//    navigationService.SetCurrentManagerPage(this);
//    base.OnNavigatedTo(e);
//}