using MeetManagerWPF.View;
using MeetManagerWPF.View.Pages;
using MeetManagerWPF.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace MeetManagerWPF.Services
{

    public interface INavigation
    {
        void NavigateToView(string View);
        void NavigateToPage(string Page);
    }


    public class Navigation(IHost host, LoginViewModel loginViewModel) : INavigation
    {
        private readonly IHost _host = host;
        private readonly LoginViewModel _loginViewModel = loginViewModel;




        public void NavigateToView(string View)
        {
            MessageBox.Show($"next View {View}");

        }


        public void NavigateToPage(string Page)
        {
            MessageBox.Show($"next Page {Page}");

            var loginView = new LoginView(_loginViewModel);

            switch (Page)
            {
                case "LoginPage":
                    loginView.FrameLogin.Navigate(new LoginPage(_loginViewModel));
                    break;
                case "RegisterPage":
                    loginView.FrameLogin.Navigate(new RegisterPage(_loginViewModel));
                    break;
                default:
                    break;
            }
        }
    }
}
