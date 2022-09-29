using Assignment6.Models;

namespace Assignment6.Services.Franchises
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        /// <summary>
        /// Gets all characters within the specific franchise. 
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        Task<ICollection<Character>> GetCharactersAsync(int franchiseId);
        /// <summary>
        /// Gets all movies within the specific franchise 
        /// </summary>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        Task<ICollection<Movie>> GetMoviesAsync(int franchiseId);
        /// <summary>
        /// Updates movies in a franchise 
        /// </summary>
        /// <param name="movieIds"></param>
        /// <param name="franchiseId"></param>
        /// <returns></returns>
        Task UpdateMoviesAsync(int[] movieIds, int franchiseId);
    }
}
