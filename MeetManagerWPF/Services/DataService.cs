using MeetManagerWPF.Data;
using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        Task AddUser(User user);
        Task DeleteUser(User user);
        Task<User?> GetUser(string email);
        Task<IEnumerable<User>> GetUsersList();
        Task UpdateUsersList();
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

        // DELETE USER //
        public async Task DeleteUser(User user)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }


        // GET USER //
        public async Task<User?> GetUser(string email)
        {
            return await _db.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Email == email);
        }


        // GET USERS LIST //
        public async Task<IEnumerable<User>> GetUsersList()
        {
            return await _db.Users.Include(p => p.Role).ToListAsync();
        }


        // UPDATE USERS LIST //
        public async Task UpdateUsersList()
        {
            await _db.SaveChangesAsync();
        }


    }
}
