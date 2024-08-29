using ExpenseManagement.Shared;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movement> Movements { get; set; }
    }
}
