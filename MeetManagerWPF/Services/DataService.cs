using MeetManagerWPF.Data;
using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        Task AddUser(User user);
        Task<User?> GetUser(string userName);
        Task<IEnumerable<User>> GetUsersList();
    }



    public class DataService(AppDbContext db) : IDataService
    {
        private readonly AppDbContext _db = db;


        // ADD USER //
        public async Task AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();
        }


        // GET USER //
        public async Task<User?> GetUser(string userName)
        {
            return await _db.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Name.Equals(userName));
        }


        // GET USERSLIST //
        public async Task<IEnumerable<User>> GetUsersList() => await _db.Users.Include(p => p.Role).ToListAsync();






    }
}
