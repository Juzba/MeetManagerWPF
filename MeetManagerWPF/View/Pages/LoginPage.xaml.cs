using MeetManagerWPF.ViewModel;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    public partial class LoginPage : Page
    {
        public LoginPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.DataContext = loginViewModel;
        }
    }
}
