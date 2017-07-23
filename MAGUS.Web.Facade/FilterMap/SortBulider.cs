using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.FilterMap
{
    internal class SortBulider
    {
        public Expression<Func<TDestination, object>> CreateSort<TDestination>(string filedName)
        {
            var parameterExpression = Expression.Parameter(typeof(TDestination), "dstParameter");

            var expression = Expression.Field(parameterExpression, filedName);

            return Expression.Lambda<Func<TDestination, object>>(expression, parameterExpression);
        }
    }
}
