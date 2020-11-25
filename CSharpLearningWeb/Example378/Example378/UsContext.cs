using Microsoft.EntityFrameworkCore;

namespace Example378
{
    public class UsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UID);
        }

        protected void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=(localdb) \\MSSQLLocalDB;database=CustDB");
        }
    }
}
