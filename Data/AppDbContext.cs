using Microsoft.EntityFrameworkCore;
using MyTasks.Models;

namespace MyTasks.Data
{
    public class AppDbContext : DbContext
    {   
        public DbSet<User> User { get; set; }
        public DbSet<Todo> Todo { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=mytasksdb;user=root;password=;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }        
        
    }
}