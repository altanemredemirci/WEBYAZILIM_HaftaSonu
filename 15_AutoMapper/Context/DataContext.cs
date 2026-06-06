using _15_AutoMapper.Models;
using Microsoft.EntityFrameworkCore;

namespace _15_AutoMapper.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=SchoolDB; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Student> Students { get; set; }
    }
}
