using MAGUS.Domain;
using MAGUS.Services.Interfaces;
using MAGUS.Services.Model;
using MAGUS.Web.Facade.ExpressionBuilder;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MAGUS.Web.ExpressionBuilder
{

    public class ExpressionBuilder
    {
        //public Expression<Func<U, bool>> CreateExpression<T, U>(T filter) where T : class where U : class
        //{

        //    Expression<Func<U, bool>> expressionFromFilter;

        //    var parameterExpression = Expression.Parameter(typeof(U));
        //    Expression expression = null;

        //    PropertyInfo[] propertyInfoArr = typeof(T).GetProperties();

        //    foreach (var item in propertyInfoArr)
        //    {
        //        var propertyValue = item.GetValue(filter);
        //        var operationAttribute = item.GetCustomAttribute(typeof(OperationAttribute));

        //        if (propertyValue == null || operationAttribute == null) continue;

        //        var builderItem = new ExpressionBuilderItem();
        //        builderItem.ConstantValue = propertyValue;

        //        builderItem.Operation = (operationAttribute as OperationAttribute).Operation;
        //        builderItem.ParameterExpression = parameterExpression;
        //        builderItem.PropertyName = item.Name;

        //        Expression expressionItem = ExpressionFromFilterProperty(builderItem);
                
        //        expression = expression == null ? expressionItem : Expression.AndAlso(expression, expressionItem);
        //    }

        //    expressionFromFilter = Expression.Lambda<Func<U, bool>>(expression, parameterExpression);

        //    return expressionFromFilter;
        //}

        //public static Expression<Func<U, bool>> Build<T, U>(T filter) where T: class where U: class
        //{
        //    //Expression<Func<U, bool>> rval;
        //    TypePair typePair = new TypePair(typeof(T), typeof(U));

        //    Delegate func; 
        //    _expressionMap.TryGetValue(typePair, out func);

        //    var funcV = (func as Func<T, Func<U, bool>>).Invoke(filter);

        //    return rval  => mc => funcV(mc);
        //}
    }

}
