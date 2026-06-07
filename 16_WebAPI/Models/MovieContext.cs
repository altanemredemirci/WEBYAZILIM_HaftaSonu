using Microsoft.EntityFrameworkCore;

namespace _16_WebAPI.Models
{
    public class MovieContext:DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=202-3\\SQLEXPRESS; Database=MovieDB; Trusted_Connection=true; TrustServerCertificate=true");
        //}

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
