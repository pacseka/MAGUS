using System;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.FilterMap;

namespace MAGUS.Web.Facade.Models
{
    public class WeaponFilter : BaseFilter, IWeaponFilter
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public string Damage { get; set; }

        public MinMaxFilter<int?> Initiate { get; set; }

        public string Type { get; set; }

        public MinMaxFilter<int?> Cost { get; set; }
    }
}
