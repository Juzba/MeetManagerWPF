using MeetManagerWPF.Data;
using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        Task<User?> GetUser(string userName);
        Task<IEnumerable<User>> GetUsersList();
    }



    public class DataService(AppDbContext db) : IDataService
    {
        private readonly AppDbContext _db = db;



        // GET USER //
        public async Task<User?> GetUser(string userName)
        {
            return await _db.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Name.Equals(userName));
        }

        // GET USERSLIST //
        public async Task<IEnumerable<User>> GetUsersList() => await _db.Users.Include(p => p.Role).ToListAsync();

    }
}
