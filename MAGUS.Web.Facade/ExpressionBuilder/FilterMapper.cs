using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.ExpressionBuilder
{
    public class FilterMapper
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        private ConcurrentDictionary<TypePair, Delegate> _filterMapCache = new ConcurrentDictionary<TypePair, Delegate>();


        public Expression<Func<TDestination, bool>> Map<TDestination, TSource>(TSource src) where TDestination : new()
        {
            if (src == null) return null;

            TypePair typePair = new TypePair(typeof(TSource), typeof(TDestination));
            
            TDestination dest = new TDestination();

            var map = (Func<TSource, TDestination, Expression<Func<TSource, TDestination, bool>>>)_filterMapCache.GetOrAdd(typePair, _ => MakeOperationMap<TSource, TDestination>());

            var rval = map(src, dest);

            Expression func = Expression.Property(rval.Body, "convertParam");

            Expression<Func<TDestination, bool>> lambda = Expression.Lambda<Func<TDestination, bool>>(func, rval.Parameters);

            return lambda;
        }

        private Func<TSource, TDestination, Expression<Func<TDestination, bool>>> MakeOperationMap<TSource, TDestination>()
        {
            var srcExpressionParameter = Expression.Parameter(typeof(TSource), "srcParam");
            var dstExpressionParameter = Expression.Parameter(typeof(TDestination), "dstParam");

            var expressionLambda = CreateExpression<TSource, TDestination>();

            return expressionLambda;
        }

        private Expression<Func<TDestination, bool>> CreateExpression<TSource, TDestination>()
        {
            Expression expression = null;

            var srcExpressionParameter = Expression.Parameter(typeof(TSource), "srcParam");
            var dstExpressionParameter = Expression.Parameter(typeof(TDestination), "dstParam");

            var srcProperties = typeof(TSource).GetProperties().ToDictionary(x => x.Name);
            var dstProperties = typeof(TDestination).GetProperties().ToDictionary(x => x.Name);
            foreach (var srcProperty in srcProperties)
            {
                var operationAttribute = srcProperty.Value.GetCustomAttribute(typeof(OperationAttribute));
                if (operationAttribute == null) continue;

                var dstProperty = dstProperties[srcProperty.Key];

                var srcMemberExpression = Expression.Property(srcExpressionParameter, srcProperty.Value.Name);
                var dstMemberExpression = Expression.Property(dstExpressionParameter, dstProperty.Name);

                var nullCheck = Expression.NotEqual(srcExpressionParameter, Expression.Constant(null, typeof(object)));

                Expression conditionExpression = ExpressionFromFilterProperty(srcMemberExpression, dstMemberExpression, (operationAttribute as OperationAttribute).Operation);

                conditionExpression = Expression.AndAlso(nullCheck, conditionExpression);

                expression = expression == null ? conditionExpression : Expression.AndAlso(expression, conditionExpression);
            }

            Expression Wapper = null;
            
            var expressionParameter = Expression.Parameter(expression.GetType()), "resultExpression" )

            
            var lambdaExpression = Expression.Lambda<Expression<Func<TDestination, bool>>>(expression, srcExpressionParameter, dstExpressionParameter);

            return lambdaExpression;
        }


        //private Expression ExpressionToProperties(PropertyInfo dstProperty, PropertyInfo srcProperty, Expression srcExpressionParameter, Expression dstExpressionParameter)
        //{
        //    var operationAttribute = srcProperty.GetCustomAttribute(typeof(OperationAttribute));

        //    //var srcMemberExpression = Expression.Property(srcExpressionParameter, srcProperty);
        //    //var dstMemberExpression = Expression.Property(dstExpressionParameter, dstProperty);

        //    Expression conditionExpression = ExpressionFromFilterProperty(srcExpressionParameter, dstExpressionParameter, (operationAttribute as OperationAttribute).Operation);

        //    var nullCheck = Expression.NotEqual(srcExpressionParameter, Expression.Constant(null, typeof(object)));

        //    conditionExpression = Expression.AndAlso(nullCheck, conditionExpression);

        //    return conditionExpression;
        //}

        private Expression ExpressionFromFilterProperty(Expression srcMemberExpression, Expression dstMemberExpression, Operation operation)
        {
            switch (operation)
            {
                case Operation.Contains:
                    return Expression.Call(dstMemberExpression, containsMethod, srcMemberExpression);

                case Operation.GreateherThanOrEqual:
                    return Expression.GreaterThanOrEqual(dstMemberExpression, srcMemberExpression);
            }

            return null;
        }
    }
}
