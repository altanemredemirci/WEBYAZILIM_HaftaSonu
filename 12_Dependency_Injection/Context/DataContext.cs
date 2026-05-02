using _12_Dependency_Injection.Models;
using Microsoft.EntityFrameworkCore;

namespace _12_Dependency_Injection.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=SchoolDB; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Student> Student { get; set; }
    }
}
