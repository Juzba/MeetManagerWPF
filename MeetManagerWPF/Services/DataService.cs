using MeetManagerWPF.Data;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        //void DataCompare<T>();
        Task<bool> LoginConfirmation();
    }

    public class DataService(AppDbContext db) : IDataService
    {
        private readonly AppDbContext _db = db;

        public async Task<bool> LoginConfirmation()
        {

            return true;
        }
    }
}
