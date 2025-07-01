using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using MeetManagerWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Windows;

namespace MeetManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; } = default!;


        public App()
        {

            AppHost = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<INavigation, Navigation>();
                
                //  VIEWMODEL
                services.AddTransient<LoginViewModel>();

                //  WIEV
                services.AddTransient<LoginView>();
                services.AddTransient<LoginPage>();


            }).Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await AppHost.StartAsync();

            // Window first Initialize to LoginPage
            var View = AppHost.Services.GetRequiredService<LoginView>();
            var loginPage = AppHost.Services.GetRequiredService<LoginPage>();

            //// Open MainWindow
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            //// Add Content to MainVindow
            mainWindow.Content = View;

            //// Open LoginPage in Frame for Login
            View.FrameLogin.Navigate(loginPage);

            base.OnStartup(e);
        }


        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            AppHost.Dispose();

            base.OnExit(e);
        }
    }

}
