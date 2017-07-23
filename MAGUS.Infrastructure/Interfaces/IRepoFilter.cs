using System;
using System.Linq.Expressions;

namespace MAGUS.Infrastructure.Interfaces
{
    public interface IRepoFilter<T> : IRepoSort<T> where T : class  
    {
        Expression<Func<T, bool>> Filter { get; set; }
        int? Limit { get; set; }
        int? Position { get; set; }
    }
}