using MeetManagerWPF.ViewModel;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage(HomeViewModel homeViewModel)
        {
            InitializeComponent();
            DataContext = homeViewModel;
        }
    }
}
