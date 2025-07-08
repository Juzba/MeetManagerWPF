using MeetManagerWPF.Data;
using MeetManagerWPF.Services;
using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using MeetManagerWPF.ViewModel;
using Microsoft.EntityFrameworkCore;
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
                services.AddSingleton<UserStore>();
                services.AddTransient<IDataService ,DataService>();
                services.AddTransient<IHashService,HashService>();

                // DB
                services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MeetingManager; Trusted_Connection=True;"),
                ServiceLifetime.Scoped);


                //  VIEWMODEL
                services.AddTransient<MainViewModel>();
                services.AddTransient<LoginViewModel>();
                services.AddTransient<RegisterViewModel>();
                services.AddTransient<AdminViewModel>();
                services.AddTransient<HomeViewModel>();
                services.AddTransient<ManagerViewModel>();
                services.AddTransient<EventsViewModel>();

                //  WIEV
                services.AddTransient<LoginPage>();
                services.AddTransient<RegisterPage>();
                services.AddTransient<AdminPage>();
                services.AddTransient<HomePage>();
                services.AddTransient<ManagerPage>();
                services.AddTransient<EventsPage>();


            }).Build();

        }

        protected override async void OnStartup(StartupEventArgs e)
        {

            await AppHost.StartAsync();

            //// Open MainWindow
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            /// Open LoginPage on Startup
            var loginPage = AppHost.Services.GetRequiredService<LoginPage>();
            mainWindow.FrameMW.Navigate(loginPage);


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
