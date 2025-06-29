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


            // Window first Initialize to LoginPage
            var View = ServiceProvider.GetRequiredService<LoginView>();
            var viewModel = ServiceProvider.GetRequiredService<LoginViewModel>();
            var loginPage = new LoginPage();

            // Open MainWindow
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            // Add Content and DataContext to MainVindow
            mainWindow.Content = View;

            // Open LoginPage in Frame for Login
            View.FrameLogin.Navigate(loginPage);
            loginPage.DataContext = viewModel;
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>(); 
            services.AddSingleton<LoginViewModel>(); 
            services.AddSingleton<LoginView>(); 
        }

    }

}
