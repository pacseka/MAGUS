using System.Collections.Generic;
using MAGUS.Services.WeaponService;
using System.Linq.Expressions;
using System;
using MAGUS.Domain;
using MAGUS.Model;
using MAGUS.Infrastructure.Interfaces;

namespace MAGUS.Services.Interfaces
{
    public interface IWeaponService
    {
        IEnumerable<WeaponDTO> FindWeapon(IServiceFilter<WeaponDTO> dtoFilter);
        WeaponDTO CreateWeapon(WeaponDTO weapon);
        bool Update(WeaponDTO weapon);
        IEnumerable<WeaponDTO> Weapons (string category);
    }
}