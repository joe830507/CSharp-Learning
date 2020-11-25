using Microsoft.EntityFrameworkCore;

namespace Example377
{
    public class MyDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasKey(nameof(Activity.ActFlag));
        }
    }
}
