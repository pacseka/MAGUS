using MAGUS.Domain;
using MAGUS.Domain.Models;
using MAGUS.Services.Interfaces;
using MAGUS.Services.Model;
using MAGUS.Web.Facade.FilterMap;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.Models;
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

            var result = this._weaponService.FindWeapons(serviceFilter);
            return result?.ToList();
        }
        //*********************************************************************
        public WeaponDTO GetWeapon(string id)
        {
            IWeaponFilter filter = new WeaponFilter() { ID = id };
            var mapFactory = new ServiceFilterFactory();

            var serviceFilter = mapFactory.Map<IWeaponFilter, WeaponDTO>(filter);

            var result = this._weaponService.FindWeapon(serviceFilter);
            return result;
        }
        //*********************************************************************
        public WeaponDTO CreateRangedWeapon(RangedWeaponDTO weapon)
        {
           return this._weaponService.CreateRangedWeapon(weapon);
        }
        //*********************************************************************
        public WeaponDTO CreateMeleeWeapon(MeleeWeaponDTO weapon)
        {
            return this._weaponService.CreateMeleeWeapon(weapon);
        }
        //*********************************************************************
        public bool UpdateRangedWeapon(RangedWeaponDTO weapon)
        {
            return this._weaponService.UpdateRangedWeapon(weapon);
        }
        //*********************************************************************
        public bool UpdateMeleeWeapon(MeleeWeaponDTO weapon)
        {
            return this._weaponService.UpdateMeleeWeapon(weapon);
        }
        //*********************************************************************
    }
}
