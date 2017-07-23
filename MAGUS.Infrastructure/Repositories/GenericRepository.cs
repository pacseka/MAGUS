using AutoMapper;
using MAGUS.Infrastructure.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MAGUS.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMongoDbContext _context;

        public GenericRepository(IMongoDbContext context)
        {
            _context = context;
        }

        public T Add(T t)
        {
            _context.Collection<T>().InsertOne(t);
            return t;
        }

        public bool Update(Expression<Func<T, bool>> filter, T t)
        {
            var result = _context.Collection<T>().ReplaceOne(filter, t);
            return result.IsAcknowledged;
        }

        #region Finds
        public U Find<U>(Expression<Func<T, bool>> filter) where U : class
        {
            var result = _context.Collection<T>().Find(filter).SingleOrDefault();
            var dto = DTOFactory<U>(result);
            return dto;
        }

        public IEnumerable<U> FindAllByDocumentType<U>(IRepoFilter<U> filter) where U : class
        {
            var result = _context.Collection<T, U>().OfType<U>().Find(filter.Filter);
            var sortedResult = SortBy<U>(result, filter).Skip(filter.Position).Limit(filter.Limit).ToList();

            return sortedResult;
        }

        public async Task<IEnumerable<U>> FindAllByDocumentTypeAsync<U>(IRepoFilter<U> filter) where U : class
        {
            var result = _context.Collection<T, U>().OfType<U>().Find(filter.Filter);
            var sortedResult = await SortBy<U>(result, filter).Skip(filter.Position).Limit(filter.Limit).ToListAsync(); ;

            return sortedResult;
        }

        public IEnumerable<U> FindAll<U>(IRepoFilter<T> filter) where U : class
        {
            var result = _context.Collection<T>().Find(filter.Filter);
            var sortedResult = SortBy(result, filter).Skip(filter.Position).Limit(filter.Limit).ToList();

            var rval = ConvertModelListToDTOList<U>(sortedResult);
            return rval;
        }

        public async Task<IEnumerable<U>> FindAllAsync<U>(IRepoFilter<T> filter) where U : class
        {
            var result = _context.Collection<T>().Find(filter.Filter);
            var sortedResult = await SortBy(result, filter).Skip(filter.Position).Limit(filter.Limit).ToListAsync();
            
            var rval = ConvertModelListToDTOList<U>(sortedResult);
            return rval;
        }

        #endregion

        #region GetAll
        public IEnumerable<U> GetAll<U>() where U : class
        {
            var result = _context.Collection<T>().AsQueryable().OfType<U>().ToList();
            return result;
        }
        #endregion

        #region Count methods
        public long Count(Expression<Func<T, bool>> filter)
        {
            return _context.Collection<T>().Count(filter);
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Collection<T>().CountAsync(filter);
        }

        public long Count<U>(Expression<Func<U, bool>> filter)
        {
            return _context.Collection<T, U>().OfType<U>().Count(filter);
        }

        public async Task<long> CountAsync<U>(Expression<Func<U, bool>> filter)
        {
            return await _context.Collection<T, U>().OfType<U>().CountAsync(filter);
        }
        #endregion

        protected U DTOFactory<U>(T t) where U : class
        {
            var rval = Mapper.Map<U>(t);
            return rval;
        }
        
        private IFindFluent<T, T> SortBy(IFindFluent<T, T> t, IRepoSort<T> sort)
        {
            if (sort == null || sort.Sort == null) return t;
            return sort.Descending ? t.Sort(Builders<T>.Sort.Descending(sort.Sort)) : t.Sort(Builders<T>.Sort.Ascending(sort.Sort));
        }

        private IFindFluent<U, U> SortBy<U>(IFindFluent<U, U> t, IRepoSort<U> sort) where U : class
        {
            return sort.Descending ? t.Sort(Builders<U>.Sort.Descending(sort.Sort)) : t.Sort(Builders<U>.Sort.Ascending(sort.Sort));
        }

        private List<U> ConvertModelListToDTOList<U>(List<T> modelList) where U : class
        {
            var rval = new List<U>();

            modelList.ForEach(x => { rval.Add(DTOFactory<U>(x)); });

            return rval;
        }
    }
}
