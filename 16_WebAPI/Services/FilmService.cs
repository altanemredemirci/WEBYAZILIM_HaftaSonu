using _16_WebAPI.Models;

namespace _16_WebAPI.Services
{
    public class FilmService : IFilmService
    {
        private readonly List<Movie> _movies;

        public FilmService()
        {
            _movies = new List<Movie>()
            {
                new Movie()
                {
                    Id=1,
                    Title="Esaretin Bedeli",
                    Genre="Crime",
                    ReleaseDate=DateTime.Now.AddYears(-20)
                },

                 new Movie()
                {
                    Id=2,
                    Title="Yeşil Yol",
                    Genre="Crime",
                    ReleaseDate=DateTime.Now.AddYears(-20)
                },

                 new Movie()
                {
                    Id=3,
                    Title="Yüzükler Efendisi",
                    Genre="Fantastic",
                    ReleaseDate=DateTime.Now.AddYears(-20)
                }
            };
        }

        public Movie GetMovie(int id)
        {
            var movie = this._movies.FirstOrDefault(i=> i.Id==id);
            return movie;
        }

        public List<Movie> GetMovies()
        {
            return this._movies;
        }
    }
}
