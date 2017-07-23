using MAGUS.Web.Facade.FilterMap;

namespace MAGUS.Web.Facade.Interfaces
{
    public interface IWeaponFilter : IBaseFilter
    {
        string Description { get; set; }

        MinMaxFilter<int?> Initiate { get; set; }

        string Name { get; set; }

        string Damage { get; set; }

        string Type { get; set; }

        MinMaxFilter<int?> Cost { get; set; }
    }
}