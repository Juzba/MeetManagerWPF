using MeetManagerWPF.ViewModel;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage(LoginViewModel loginViewModel)
        {
            InitializeComponent();
            this.DataContext = loginViewModel;
        }
    }
}
