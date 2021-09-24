using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.Entities;
using Task = NLayerApp.DAL.Entities.Task;

namespace NLayerApp.DAL.EF
{
    class SqlContext: DbContext
    {
        
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=testDb;Trusted_Connection=True;");
        }
    }
}
