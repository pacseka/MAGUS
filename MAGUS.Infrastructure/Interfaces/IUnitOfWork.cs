using System;

namespace MAGUS.Infrastructure.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}