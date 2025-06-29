using MeetManagerWPF.View.Pages;
using MeetManagerWPF.ViewModel;
using MeetManagerWPF.View;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MeetManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = default!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            // Otevření MainWindow
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            mainWindow.DataContext = ServiceProvider.GetRequiredService<LoginViewModel>();

            var loginView = new LoginView();
            mainWindow.Content = loginView;
            loginView.FrameLogin.Navigate(new LoginPage());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>(); // Registrace MainWindow jako služby
            services.AddSingleton<LoginViewModel>(); 
        }

    }

}
