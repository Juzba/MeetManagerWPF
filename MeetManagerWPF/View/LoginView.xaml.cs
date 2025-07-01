using MeetManagerWPF.ViewModel;
using System.Windows.Controls;
using MeetManagerWPF.View.Pages;

namespace MeetManagerWPF.View
{
    /// <summary>
    /// Interakční logika pro LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            DataContext = loginViewModel;
            FrameLogin.Navigate(new LoginPage(loginViewModel));
        }
    }
}
