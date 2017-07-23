using MongoDB.Bson;
using System;
using System.Linq.Expressions;

namespace MAGUS.Infrastructure.Interfaces
{
    public interface IRepoSort<T> where T : class
    {
        bool Descending { get; set; }
        Expression<Func<T, object>> Sort { get; set; }
    }
}