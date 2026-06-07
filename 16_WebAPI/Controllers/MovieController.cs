using _16_WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _16_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MovieContext _context;
        public MovieController(MovieContext context)
        {
            _context = context;
        }

        //WEBAPI 5 Ana metot vardır. 
        //GET: Liste olarak okuma yaptığımız metot.
        //GET(int id): Belirli bir entity okuma yaptığımız metot.
        //POST: Kayıt yapmamızı sağlayan metot.
        //PUT: Güncelleme yaptığımız metot.
        //DELETE: Silme işlemini yaptığımız metot.

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            return await _context.Movies.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            return await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);

            //return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }

            if (!MovieExists(id))
            {
                return NotFound();
            }

            Movie movie = await _context.Movies.FirstOrDefaultAsync(i => i.Id == id);

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool MovieExists(int id)
        {
            //AsNoTracking(): Databaseden alınan datayı takip etme çünkü işlem tek yönlü olacak.
            return (_context.Movies?.AsNoTracking().Any(i => i.Id == id)).GetValueOrDefault();
        }
    }
}
