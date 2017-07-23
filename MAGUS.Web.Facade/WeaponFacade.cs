using MAGUS.Domain;
using MAGUS.Services.Interfaces;
using MAGUS.Web.Facade.FilterMap;
using MAGUS.Web.Facade.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MAGUS.Web.Facade
{
    public class WeaponFacade : IWeaponFacade
    {

        private IWeaponService _weaponService;
        //*********************************************************************
        public WeaponFacade(IWeaponService weaponService)
        {
            this._weaponService = weaponService;
        }
        //*********************************************************************
        public IList<WeaponDTO> FindWeaponsByFilter(IWeaponFilter filter)
        {
            var mapFactory = new ServiceFilterFactory();

            var serviceFilter = mapFactory.Map<IWeaponFilter, WeaponDTO>(filter);

            var result = this._weaponService.FindWeapon(serviceFilter);
            return result?.ToList();
        }
        //*********************************************************************
        public WeaponDTO CreateWeapon(WeaponDTO weapon)
        {
           return this._weaponService.CreateWeapon(weapon);
        }
        //*********************************************************************
    }
}
