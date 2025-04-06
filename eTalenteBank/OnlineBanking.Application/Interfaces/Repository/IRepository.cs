using System.Linq.Expressions;

namespace OnlineBanking.Application.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <typeparam name="TId">The type of the entity's ID.</typeparam>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>A task representing the asynchronous operation, with the entity as the result.</returns>
    Task<TEntity?> GetByIdAsync<TId>(TId id);
    /// <summary>
    /// Retrieves an entity that matches a given expression asynchronously.
    /// </summary>
    /// <param name="expression">The expression to filter entities by.</param>
    /// <returns>A task representing the asynchronous operation, with the matching entity as the result.</returns>
    Task<TEntity?> GetByExpression(Expression<Func<TEntity, bool>> expression);
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a list of all entities as the result.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task AddAsync(TEntity entity);
    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    void Update(TEntity entity);
    /// <summary>
    /// Deletes an existing entity.
    /// </summary>
    /// <param name="entity">The entity to delete.</param>
    void Delete(TEntity entity);
    /// <summary>
    /// Saves changes to the database asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, with a boolean indicating if changes were successfully saved.</returns>
    Task<bool> SaveChangesAsync();
}