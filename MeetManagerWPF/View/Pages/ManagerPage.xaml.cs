using MeetManagerWPF.ViewModel;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro AddEventPage.xaml
    /// </summary>
    public partial class ManagerPage : Page
    {
        public ManagerPage(ManagerViewModel addEventViewModel)
        {
            InitializeComponent();
            DataContext = addEventViewModel;
        }
    }
}
