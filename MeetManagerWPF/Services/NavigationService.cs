using CommunityToolkit.Mvvm.Messaging;

namespace MeetManagerWPF.Services
{

    public interface INavigationService 
    {
        void NavigateTo<TPage>(string frameName = Constants.FrameMainVindow);
    }


    public class NavigationService : INavigationService
    {

        public void NavigateTo<TPage>(string frameName = Constants.FrameMainVindow)
        {
            WeakReferenceMessenger.Default.Send(new NavigateMessage(typeof(TPage), frameName));
        }
    }
}
