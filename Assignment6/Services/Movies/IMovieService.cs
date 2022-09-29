using Assignment6.Models;

namespace Assignment6.Services.Movies
{
    public interface IMovieService : ICrudService<Movie, int>
    {
        /// <summary>
        /// Gets all characters in a specific movie
        /// </summary>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task<ICollection<Character>> GetCharactersAsync(int movieId);
        /// <summary>
        /// Updates characters in a specific movie 
        /// </summary>
        /// <param name="characterIds"></param>
        /// <param name="movieId"></param>
        /// <returns></returns>
        Task UpdateCharactersAsync(int[] characterIds, int movieId);
    }
}
