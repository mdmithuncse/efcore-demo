using EFCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sqlserver;Database=efcoredemo-db;User Id=sa;Password=Passw0rd;");
        }

        public void ApplyMigrations()
        {
            Database.Migrate();
        }
    }
}
