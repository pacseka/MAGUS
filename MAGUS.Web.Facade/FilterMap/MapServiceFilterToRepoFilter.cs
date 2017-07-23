using MAGUS.Services.Interfaces;
using MAGUS.Services.Model;
using MAGUS.Web.Facade.Interfaces;

namespace MAGUS.Web.Facade.FilterMap
{
    public class ServiceFilterFactory
    {
        public IServiceFilter<TDestination> Map<TSource, TDestination>(TSource filter) where TDestination : class where TSource : class, IBaseFilter
        {
            var expressionBuilder = new ExpressionBuilder();
            var sortBuilder = new SortBulider();

            ServiceFilter<TDestination> serviceFilter = new ServiceFilter<TDestination>();
            serviceFilter.Descending = filter.Desc;
            serviceFilter.Limit = filter.Limit;
            serviceFilter.Position = filter.Position;
            serviceFilter.Filter = expressionBuilder.CreateExpression<TDestination, TSource>(filter);
            serviceFilter.Sort = string.IsNullOrEmpty(filter.OrderBy) ? null : sortBuilder.CreateSort<TDestination>(filter.OrderBy);

            return serviceFilter;
        }
    }
}
