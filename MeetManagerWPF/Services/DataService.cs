using MeetManagerWPF.Data;
using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace MeetManagerWPF.Services
{
    public interface IDataService
    {
        //void DataCompare<T>();
        Task<User?> LoginConfirmation(string userName, string password);
    }

    public class DataService(AppDbContext db) : IDataService
    {
        private readonly AppDbContext _db = db;




        public async Task<User?> LoginConfirmation(string userName, string password)
        {
            var user = await _db.Users.Include(p=>p.Role).FirstOrDefaultAsync(p => p.Name.ToLower() == userName.ToLower());

            if (user == null || user.Password != password) return null;

            return user;
        }
    }
}
