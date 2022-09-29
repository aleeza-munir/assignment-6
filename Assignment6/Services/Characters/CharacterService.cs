
using Assignment6.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment6.Services.Characters
{
    public class CharacterService : ICrudService<Character, int>
    {
        //Uses dbContext to get acces to database and also manipulate the data 
        private readonly MovieCharactersDBContext _dbContext;
        public CharacterService(MovieCharactersDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Character entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteByIdAsync(int id)
        {
            var character = await _dbContext.Characters.FindAsync(id);
            
            _dbContext.Characters.Remove(character);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<ICollection<Character>> GetAllAsync()
        {
            return await _dbContext.Characters
                .Include(p => p.Movies)
                .ToListAsync();

        }

        public async Task<Character> GetByIdAsync(int id)
        {
            return await _dbContext.Characters
                .Where(p => p.Id == id)
                .Include(d => d.Movies)
                .FirstAsync();
        }

        public async Task UpdateAsync(Character entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
    }
}
