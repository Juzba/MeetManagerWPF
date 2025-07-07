using MeetManagerWPF.Data;
using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        Task<User?> GetUser(string userName);
    }

    public class DataService(AppDbContext db) : IDataService
    {
        private readonly AppDbContext _db = db;




        public async Task<User?> GetUser(string userName)
        {
            return await _db.Users.Include(p => p.Role).FirstOrDefaultAsync(p => p.Name.ToLower() == userName.ToLower());
        }
    }
}
