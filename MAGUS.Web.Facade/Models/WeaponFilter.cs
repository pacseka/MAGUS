using System;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.FilterMap;

namespace MAGUS.Web.Facade.Models
{
    public class WeaponFilter : BaseFilter, IWeaponFilter
    {

        [OperationAttribute(OperationType.Contains)]
        public string Name { get; set; }

        [OperationAttribute(OperationType.Contains)]
        public string Description { get; set; }

        [OperationAttribute(OperationType.Contains)]
        public string Damage { get; set; }

        [OperationAttribute(OperationType.MinMax)]
        public MinMaxFilter<int?> Initiate { get; set; }

        [OperationAttribute(OperationType.Equal)]
        public string Type { get; set; }

        [OperationAttribute(OperationType.MinMax, FieldName = "Cost")]
        public MinMaxFilter<int?> Cost { get; set; }
    }
}
