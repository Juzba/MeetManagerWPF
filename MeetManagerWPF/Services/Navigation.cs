using System.Windows;

namespace MeetManagerWPF.Services
{

    public interface INavigation
    {
        void NavigateToView(string View);
        void NavigateToPage(string View);
    }


    public class Navigation : INavigation
    {
        public void NavigateToView(string View)
        {
            MessageBox.Show($"next View {View}");
        }


        public void NavigateToPage(string View)
        {
            MessageBox.Show($"next Page {View}");
        }
    }
}
