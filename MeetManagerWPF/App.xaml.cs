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
                services.AddSingleton<INavigation, Navigation>();
                
                //  VIEWMODEL
                services.AddTransient<LoginViewModel>();

                //  WIEV
                //services.AddTransient<LoginView>();
                //services.AddTransient<LoginPage>();


            }).Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await AppHost.StartAsync();

            //// Open MainWindow
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

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
