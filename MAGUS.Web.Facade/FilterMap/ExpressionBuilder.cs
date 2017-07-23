using MAGUS.Services.Model;
using MAGUS.Web.Facade.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace MAGUS.Web.Facade.FilterMap
{

    public class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        public Expression<Func<TParameter, bool>> CreateExpression<TParameter, TFilter>(TFilter filter) where TParameter : class where TFilter : class
        {
            ServiceFilter<TParameter> rval = new ServiceFilter<TParameter>();
            var parameterExpression = Expression.Parameter(typeof(TParameter));
            Expression expression = null;

            PropertyInfo[] propertyInfoArr = typeof(TFilter).GetProperties();

            foreach (var item in propertyInfoArr)
            {
                var propertyValue = item.GetValue(filter);
                var operationAttribute = item.GetCustomAttribute(typeof(OperationAttribute));

                if (propertyValue == null || operationAttribute == null) continue;
                OperationAttribute attribute = (OperationAttribute)operationAttribute;

                string filteredPropertyName = string.IsNullOrEmpty(attribute.FieldName) ? item.Name : attribute.FieldName;

                var builderItem = new ExpressionBuilderItem();
                builderItem.ParameterExpression = parameterExpression;
                builderItem.PropertyName = filteredPropertyName;


                if (attribute.Operation == OperationType.MinMax)
                {
                    var minMaxFilter = (IMinMaxFilter)propertyValue;

                    var operation = minMaxFilter.Operation();

                    switch (operation)
                    {
                        case OperationType.GreaterThanOrEqual:
                            builderItem.ConstantValue = minMaxFilter.MinValue();
                            builderItem.Operation = operation;
                            expression = AppendExpression(expression, builderItem);
                            break;
                        case OperationType.LessThanOrEqual:
                            builderItem.ConstantValue = minMaxFilter.MaxValue();
                            builderItem.Operation = operation;
                            expression = AppendExpression(expression, builderItem);
                            break;
                        case OperationType.Equal:
                            builderItem.ConstantValue = minMaxFilter.MaxValue();
                            builderItem.Operation = operation;
                            expression = AppendExpression(expression, builderItem);
                            break;
                        case OperationType.MinMax:
                            builderItem.ConstantValue = minMaxFilter.MinValue();
                            builderItem.Operation = OperationType.GreaterThanOrEqual;
                            expression = AppendExpression(expression, builderItem);
                            builderItem.ConstantValue = minMaxFilter.MaxValue();
                            builderItem.Operation = OperationType.LessThanOrEqual;
                            expression = AppendExpression(expression, builderItem);
                            break;
                    }
                }
                else
                {
                    builderItem.Operation = attribute.Operation;
                    builderItem.ConstantValue = propertyValue;
                    expression = AppendExpression(expression, builderItem);
                }
            }
            return Expression.Lambda<Func<TParameter, bool>>(expression, parameterExpression);
        }

        private Expression AppendExpression(Expression expression, ExpressionBuilderItem builderItem)
        {
            Expression expressionItem = ExpressionFromFilterProperty(builderItem);
            return expression == null ? expressionItem : Expression.AndAlso(expression, expressionItem);
        }

        private class ExpressionBuilderItem
        {
            public ParameterExpression ParameterExpression { get; set; }
            public string PropertyName { get; set; }
            public object ConstantValue { get; set; }
            public OperationType Operation { get; set; }
        }

        private Expression ExpressionFromFilterProperty(ExpressionBuilderItem builderItem)
        {
            MemberExpression member = Expression.Property(builderItem.ParameterExpression, builderItem.PropertyName);
            ConstantExpression constant = Expression.Constant(builderItem.ConstantValue);

            switch (builderItem.Operation)
            {
                case OperationType.Contains:
                    return Expression.Call(member, containsMethod, constant);
                case OperationType.Equal:
                    return Expression.Equal(member, constant);
                case OperationType.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);
                case OperationType.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);
                case OperationType.LessThan:
                    return Expression.LessThan(member, constant);
                case OperationType.GreaterThan:
                    return Expression.GreaterThan(member, constant);
                case OperationType.NotEqual:
                    return Expression.NotEqual(member, constant);
                case OperationType.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);
                case OperationType.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }
    }

}
