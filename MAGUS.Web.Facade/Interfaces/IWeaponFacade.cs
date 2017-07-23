using System.Collections.Generic;
using MAGUS.Domain;
using MAGUS.Web.Facade.Interfaces;

namespace MAGUS.Web.Facade.Interfaces
{
    public interface IWeaponFacade
    {
        IList<WeaponDTO> FindWeaponsByFilter(IWeaponFilter filter);
        WeaponDTO CreateWeapon(WeaponDTO weapon);
    }
}