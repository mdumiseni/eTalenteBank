namespace OnlineBanking.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    Task<bool> SaveChangesAsync();
}