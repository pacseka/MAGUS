using System;

namespace MAGUS.Web.Facade.FilterMap
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class OperationAttribute : Attribute
    {
        readonly OperationType _operation;

        public OperationAttribute(OperationType Operation)
        {
            this._operation = Operation;
        }

        public OperationType Operation
        {
            get { return this._operation; }
        }

        public string FieldName { get; set; }
    }
}
