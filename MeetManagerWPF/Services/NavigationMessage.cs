using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MeetManagerWPF.Services
{
    public class NavigateMessage : ValueChangedMessage<Type>
    {
        public NavigateMessage(Type pageType) : base(pageType) { }
    }
}
