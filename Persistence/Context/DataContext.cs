using Microsoft.EntityFrameworkCore;
using TalabatApi.Domain.Model;

namespace TalabatApi.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Restuarant> Restuarants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserData)
                .WithOne(u => u.User)
                .HasForeignKey<UserData>(u => u.UserId);
        }

    }
}