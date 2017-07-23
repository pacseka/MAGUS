using MAGUS.Web.Facade.FilterMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.Interfaces
{

    public interface IMinMaxFilter
    {
        OperationType Operation();
        object MinValue();
        object MaxValue();
    }

    public class MinMaxFilter<T> : IMinMaxFilter
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public OperationType Operation()
        {

            var operationType = Min == null ? OperationType.LessThanOrEqual : OperationType.Equal;
            operationType = Max == null ? OperationType.GreaterThanOrEqual : OperationType.Equal;

            if (Min == null || Max == null) return operationType;

            operationType = (Min as IComparable).CompareTo(Max) == 0 ? OperationType.Equal : OperationType.MinMax;

            return operationType;

        }

        public object MinValue()
        {
            return Min;
        }

        public object MaxValue()
        {
            return Max;
        }
    }
}
