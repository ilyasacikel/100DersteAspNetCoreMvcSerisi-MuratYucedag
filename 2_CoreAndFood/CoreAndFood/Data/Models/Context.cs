using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace CoreAndFood.Data.Models
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-GAARB72\\SQLEXPRESS; database=CoreAndFood; integrated security=true; TrustServerCertificate=true");
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
