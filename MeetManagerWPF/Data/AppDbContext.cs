using MeetManagerWPF.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetManagerWPF.Data
{
   public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=MeetingManager; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Role>().HasData
            (
                new Role() { Id = "AdminRoleId-51sa9-sdd18", RoleName = "Admin" },
                new Role() { Id = "ManagerRoleId-21ga5-sda13", RoleName = "Manager" },
                new Role() { Id = "UserRoleId-54sa9-sda87", RoleName = "User" }
            );

            modelBuilder.Entity<User>().HasData
            (
                new User() { Id = 1, Name = "Juzba", Password = "123456", RoleId = "AdminRoleId-51sa9-sdd18" },
                new User() { Id = 2, Name = "Katka", Password = "123456", RoleId = "ManagerRoleId-21ga5-sda13" },
                new User() { Id = 3, Name = "Karel", Password = "123456", RoleId = "UserRoleId-54sa9-sda87" }
            );

            modelBuilder.Entity<User>().HasKey("Id");

        }
    }
}
