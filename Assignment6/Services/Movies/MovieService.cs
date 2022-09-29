using Assignment6.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Assignment6.Services.Movies
{
    public class MovieService : IMovieService
    {
        //Uses dbContext to get acces to database and also manipulate the data 
        private readonly MovieCharactersDBContext _dbContext;
        public MovieService(MovieCharactersDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Movie entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _dbContext.Movies
                .Include(p => p.Characters)
                .ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _dbContext.Movies
                .Where(p => p.Id == id)
                .Include(c => c.Characters)
                .FirstAsync();
        }

        public async Task<ICollection<Character>> GetCharactersAsync(int movieId)
        {
            return await _dbContext.Characters
                .Where(p => p.Movies.Select(s => s.Id).Contains(movieId))
                .ToListAsync();

        }

        public async Task UpdateAsync(Movie entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCharactersAsync(int[] characterIds, int movieId)
        {
            List<Character> characters = characterIds
                .ToList()
                .Select(cid => _dbContext.Characters
                .Where(s => s.Id == cid).First())
                .ToList();
           
            Movie movie = await _dbContext.Movies
                .Where(m => m.Id == movieId)
                .FirstAsync();
            
            movie.Characters = characters;
            _dbContext.Entry(movie).State = EntityState.Modified;
            
            await _dbContext.SaveChangesAsync();

        }
    }
}
