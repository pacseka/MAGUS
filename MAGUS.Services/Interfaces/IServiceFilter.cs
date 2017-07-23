using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Services.Interfaces
{
    public interface IServiceFilter<T> where T: class
    {
        Expression<Func<T, bool>> Filter { get; set; }
        Expression<Func<T, object>> Sort { get; set; }
        int? Limit { get; set; }
        int? Position { get; set; }
        bool Descending { get; set; }
    }
}
