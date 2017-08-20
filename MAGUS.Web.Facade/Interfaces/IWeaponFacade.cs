using System.Collections.Generic;
using MAGUS.Domain;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Domain.Models;

namespace MAGUS.Web.Facade.Interfaces
{
    public interface IWeaponFacade
    {
        IList<WeaponDTO> FindWeaponsByFilter(IWeaponFilter filter);
        WeaponDTO GetWeapon(string id);
        WeaponDTO CreateRangedWeapon(RangedWeaponDTO weapon);
        WeaponDTO CreateMeleeWeapon(MeleeWeaponDTO weapon);
        bool UpdateRangedWeapon(RangedWeaponDTO weapon);
        bool UpdateMeleeWeapon(MeleeWeaponDTO weapon);
    }
}