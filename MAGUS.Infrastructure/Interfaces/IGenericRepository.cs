using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MAGUS.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T t);
        long Count(Expression<Func<T, bool>> filter);
        long Count<U>(Expression<Func<U, bool>> filter);
        Task<long> CountAsync(Expression<Func<T, bool>> filter);
        Task<long> CountAsync<U>(Expression<Func<U, bool>> filter);
        U Find<U>(Expression<Func<T, bool>> filter) where U : class;
        IEnumerable<U> FindAll<U>(IRepoFilter<T> filter) where U : class;
        Task<IEnumerable<U>> FindAllAsync<U>(IRepoFilter<T> filter) where U : class;
        IEnumerable<U> FindAllByDocumentType<U>(IRepoFilter<U> filter) where U : class;
        Task<IEnumerable<U>> FindAllByDocumentTypeAsync<U>(IRepoFilter<U> filter) where U : class;
        IEnumerable<U> GetAll<U>() where U : class;
        bool Update(Expression<Func<T, bool>> filter, T t);
    }
}