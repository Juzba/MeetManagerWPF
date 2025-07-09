using MeetManagerWPF.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace MeetManagerWPF.View.Pages
{
    /// <summary>
    /// Interakční logika pro AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage(AdminViewModel adminViewModel)
        {
            InitializeComponent();
            DataContext = adminViewModel;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is ComboBox combo) combo.IsDropDownOpen = true;
        }
    }
}
