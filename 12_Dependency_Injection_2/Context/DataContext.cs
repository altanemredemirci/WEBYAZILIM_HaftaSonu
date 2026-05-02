using _12_Dependency_Injection_2.Models;
using Microsoft.EntityFrameworkCore;

namespace _12_Dependency_Injection_2.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=SchoolDB; Trusted_Connection=true; TrustServerCertificate=true");
        }
        public DbSet<Product> Products { get; set; }
    }
}
