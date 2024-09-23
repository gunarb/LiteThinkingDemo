using InterfaceAdapters_Models;
using Microsoft.EntityFrameworkCore;

namespace InterfaceAdapters_Data
{
    public class AppDbContext : DbContext
    {
        private const string _taskTableName = "tasks";

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().ToTable(_taskTableName);
        }
    }
}
