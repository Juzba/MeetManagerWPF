using MeetManagerWPF.Model;
using MeetManagerWPF.Services;

namespace MeetManagerWPF.Tests;



[TestFixture]
public class DataServiceTest
{
    private IDataService _dataService;

    public DataServiceTest(IDataService dataService)
    {
        _dataService = dataService;
    }

    //[SetUp]
    //public void SetUp()
    //{
    //    var mock = new Moq.Mock<IDataService>();
    //    _dataService = mock.Object;
    //}

    [Test]
    public void TestAddUser_ValidUser_DoesNotThrow()
    {
        var user = new User { Name = "Pepa" };
        _dataService.AddUser(user);
    }

    [Test]
    public void TestAddUser_ValidUser_DoesNotThrow2()
    {
        _dataService.AddUser(null!); 
    }
}