using Microsoft.EntityFrameworkCore;

namespace CoreMvcDepartman.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-GAARB72\\SQLEXPRESS; database=CoreMvcDepartman; integrated security=true; TrustServerCertificate=true");
        }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Admin> Adminler { get; set; }
    }
}
