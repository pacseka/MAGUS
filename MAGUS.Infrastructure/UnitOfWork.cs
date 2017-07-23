using MAGUS.Infrastructure.Interfaces;
using MAGUS.Infrastructure.Repositories;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IMongoDbContext _context;
        private Dictionary<Type, object> _repositories;
        private bool _disposed = false;

        public UnitOfWork(IMongoDbContext context)
        {

            _context = context;
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity: class
        {
            if(_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            var repository = new GenericRepository<TEntity>(_context);

            _repositories.Add(typeof(TEntity), repository);

            return repository;
        }

        protected virtual void Dispose(bool disposing)
        {
            if(!this._disposed)
            {
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
