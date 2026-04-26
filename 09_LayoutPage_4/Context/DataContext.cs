using _09_LayoutPage_4.Models;
using Microsoft.EntityFrameworkCore;


namespace _09_LayoutPage_4.Context
{
    public class DataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=EdulebDB; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<slider> Sliders { get; set; }

        public DbSet<Counter> Counters { get; set; }
    }
}
