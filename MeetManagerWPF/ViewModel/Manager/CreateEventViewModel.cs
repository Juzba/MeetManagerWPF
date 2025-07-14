using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MeetManagerWPF.Model;
using MeetManagerWPF.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MeetManagerWPF.ViewModel.Manager;

public partial class CreateEventViewModel : ObservableObject
{

    private readonly IDataService _dataService;



    public CreateEventViewModel(IDataService dataService)
    {
        _dataService = dataService;
        GetEventTypeListCommand.Execute(null);
    }

  



    // COMBOBOX EVENTTYPES AND ROOMS LISTS FROM DB//
    [RelayCommand]
    private async Task GetEventTypeList()
    {
        var eventTypes = await _dataService.GetEventTypeList();
        EventTypeList = new ObservableCollection<EventType>(eventTypes);

        var roomsList = await _dataService.GetRoomList();
        RoomList = new ObservableCollection<Room>(roomsList);
    }



    // COMBOBOX EVENTTYPE AND ROOMS

    [ObservableProperty]
    private ObservableCollection<EventType> eventTypeList = [];

    [ObservableProperty]
    private EventType? selectedEventType;

    [ObservableProperty]
    private ObservableCollection<Room> roomList = [];

    [ObservableProperty]
    private Room? selectedRoom;






    [ObservableProperty]
    private string? errorMessage;

    [ObservableProperty]
    private string? name;

    [ObservableProperty]
    private DateTime startEvent = DateTime.Now.AddDays(7);

    [ObservableProperty]
    private DateTime endEvent = DateTime.Now.AddDays(8);

    [ObservableProperty]
    private string? description;




    [RelayCommand]
    public async Task CreateEvent()
    {
        if (Name == null || Description == null || SelectedEventType == null || SelectedRoom == null)
        {
            ErrorMessage = "Chybí údaje!";
            return;
        }

        var newEvent = new Event() { Name = Name, Description = Description, EndDate = EndEvent, StartDate = StartEvent, EventTypeId = SelectedEventType.Id, RoomID = SelectedRoom.ID };
        await _dataService.AddEvent(newEvent);

    }


    [RelayCommand]
    public void DeleteEvent()
    {

    }














}
