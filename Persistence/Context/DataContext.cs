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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserData)
                .WithOne(u => u.User)
                .HasForeignKey<UserData>(u => u.UserId);
        }
    }
}