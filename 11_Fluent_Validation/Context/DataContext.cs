using _11_Fluent_Validation.Models;
using Microsoft.EntityFrameworkCore;

namespace _11_Fluent_Validation.Context
{
    public class DataContext:DbContext
    {
        //Microsoft.EntityFramework.Core
        //Microsoft.EntityFramework.SqlServer
        //Microsoft.EntityFramework.Tools

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=CategoryProduct; Trusted_Connection=true; TrustServerCertificate=true");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
