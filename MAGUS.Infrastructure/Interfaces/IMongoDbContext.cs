using MongoDB.Driver;

namespace MAGUS.Infrastructure.Interfaces
{
    public interface IMongoDbContext
    {
        IMongoCollection<TContext> Collection<TEntity, TContext>();
        IMongoCollection<TEntity> Collection<TEntity>();
    }
}