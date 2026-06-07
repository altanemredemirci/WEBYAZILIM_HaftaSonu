using _16_WebAPI.Models;

namespace _16_WebAPI.Services
{
    public interface IFilmService
    {
        List<Movie> GetMovies();
        Movie GetMovie(int id);
    }
}
