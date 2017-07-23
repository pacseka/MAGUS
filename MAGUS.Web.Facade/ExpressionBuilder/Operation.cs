using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Web.Facade.ExpressionBuilder
{
    public enum Operation
    {
        Equal,
        NotEqual,
        GreaterThan,
        GreateherThanOrEqual,
        LessThan,
        LeassThanOrEqual,
        StartsWith,
        Contains
    }

    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class OperationAttribute : Attribute
    {
        readonly Operation _operation;

        // This is a positional argument
        public OperationAttribute(Operation Operation)
        {
            this._operation = Operation;


        }

        public Operation Operation
        {
            get { return this._operation; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}
