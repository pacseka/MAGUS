using MAGUS.Web.Facade.FilterMap;

namespace MAGUS.Web.Facade.Interfaces
{
    public interface IWeaponFilter : IBaseFilter
    {
        [OperationAttribute(OperationType.Equal)]
        string ID { get; set; }

        [OperationAttribute(OperationType.Contains)]
        string Description { get; set; }

        [OperationAttribute(OperationType.MinMax)]
        MinMaxFilter<int?> Initiate { get; set; }

        [OperationAttribute(OperationType.Contains)]
        string Name { get; set; }

        [OperationAttribute(OperationType.Contains)]
        string Damage { get; set; }

        [OperationAttribute(OperationType.Equal)]
        string Type { get; set; }

        [OperationAttribute(OperationType.MinMax, FieldName = "Cost")]
        MinMaxFilter<int?> Cost { get; set; }
    }
}