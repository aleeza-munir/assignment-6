using Assignment6.Models;
using Assignment6.Services.Franchises;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Assignment6.Services.Franchises
{
    public class FranchiseService : IFranchiseService
    {
        //Uses dbContext to get acces to database and also manipulate the data
        public readonly MovieCharactersDBContext _dbContext;

        public FranchiseService(MovieCharactersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Franchise entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var franchise = await _dbContext.Franchises.FindAsync(id);

            _dbContext.Franchises.Remove(franchise);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Franchise>> GetAllAsync()
        {
            return await _dbContext.Franchises
                .Include(p => p.Movies)
                .ToListAsync();
        }

        public async Task<Franchise> GetByIdAsync(int id)
        {
            return await _dbContext.Franchises
                .Where(f => f.Id == id)
                .Include(p => p.Movies)
                .FirstAsync();
        }

        public async Task<ICollection<Character>> GetCharactersAsync(int franchiseId)
        {
            return await _dbContext.Characters
                .Where(c => c.Movies.Select(m => m.FranchiseId).Contains(franchiseId))
                .ToListAsync();
        }

        public async Task<ICollection<Movie>> GetMoviesAsync(int franchiseId)
        {
            return await _dbContext.Movies
                .Where(p => p.FranchiseId == franchiseId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Franchise entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMoviesAsync(int[] movieIds, int franchiseId)
        {
            List<Movie> movies = movieIds
                .ToList()
                .Select(mid => _dbContext.Movies
                .Where(s => s.Id == mid).First())
                .ToList();
            
            Franchise franchise = await _dbContext.Franchises
                .Where(f => f.Id == franchiseId)
                .FirstAsync();
            
            franchise.Movies = movies;
            _dbContext.Entry(franchise).State = EntityState.Modified;
            
            await _dbContext.SaveChangesAsync();
        }
    }
}