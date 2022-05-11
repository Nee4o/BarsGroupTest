using Microsoft.EntityFrameworkCore;

namespace WebApiApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Hero> Heroes { get; set; }
    }
}