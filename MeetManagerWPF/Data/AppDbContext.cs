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
                new User() { Id = 1, Name = "Juzba", PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$+g3wENe8VfgrJvTd4E9YNQ$zvtCx0lwFdXwvR6DLKTOH6FJzm8rB6y54wSEpXbIkJk", RoleId = "AdminRoleId-51sa9-sdd18" },
                new User() { Id = 2, Name = "Katka", PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$VSs65qBpJTKEJSTb7qXkAw$fBlpCgya4Z9LRmKnhUFzXh7tqnXrWSl2vyHkNCwEKCg", RoleId = "ManagerRoleId-21ga5-sda13" },
                new User() { Id = 3, Name = "Karel", PasswordHash = "$argon2id$v=19$m=65536,t=3,p=1$tyqbuA8MlWrR6ZE7pWMioA$wjo5b2y+qFdDrbr23ymFvKi9xv2W55g1uvX/3T0z9/s", RoleId = "UserRoleId-54sa9-sda87" }
            );

            modelBuilder.Entity<User>().HasKey("Id");

        }
    }
}
