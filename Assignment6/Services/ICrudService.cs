namespace Assignment6.Services
{
    public interface ICrudService<T, ID>
    {
        /// <summary>
        /// Gets all Entities of the type
        /// </summary>
        /// <returns></returns>
        Task<ICollection<T>> GetAllAsync();
        /// <summary>
        /// Gets one specific entity of the type by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(ID id);
        /// <summary>
        /// Creates new entity item and adds it to db
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);
        /// <summary>
        /// Updates existing entity item in database
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
        /// <summary>
        /// Deletes an entity item in db by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteByIdAsync(ID id);
    }
}
