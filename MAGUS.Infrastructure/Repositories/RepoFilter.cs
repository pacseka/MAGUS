using MAGUS.Infrastructure.Interfaces;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Infrastructure.Repositories
{
    public class RepoFilter<T> : IRepoSort<T>, IRepoFilter<T> where T : class
    {
        public Expression<Func<T, bool>> Filter { get; set; }
        public Expression<Func<T, object>> Sort { get; set; }
        public bool Descending { get; set; }
        public int? Position { get; set; }
        public int? Limit { get; set; }
    }
}
