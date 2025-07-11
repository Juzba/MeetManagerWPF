using CommunityToolkit.Mvvm.Messaging;

namespace MeetManagerWPF.Services
{

    public interface INavigationService
    {
        void NavigateTo<TPage>();
    }


    public class NavigationService : INavigationService
    {
        public void NavigateTo<TPage>()
        {
            WeakReferenceMessenger.Default.Send(new NavigateMessage(typeof(TPage)));
        }
    }
}
