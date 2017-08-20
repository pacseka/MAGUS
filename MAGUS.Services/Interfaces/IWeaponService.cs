using System.Collections.Generic;
using MAGUS.Services.WeaponService;
using System.Linq.Expressions;
using System;
using MAGUS.Domain;
using MAGUS.Model;
using MAGUS.Infrastructure.Interfaces;
using MAGUS.Domain.Models;

namespace MAGUS.Services.Interfaces
{
    public interface IWeaponService
    {
        IEnumerable<WeaponDTO> FindWeapons(IServiceFilter<WeaponDTO> dtoFilter);
        WeaponDTO FindWeapon(IServiceFilter<WeaponDTO> dtoFilter);
        WeaponDTO CreateRangedWeapon(RangedWeaponDTO weapon);
        WeaponDTO CreateMeleeWeapon(MeleeWeaponDTO weapon);
        bool UpdateRangedWeapon(RangedWeaponDTO weapon);
        bool UpdateMeleeWeapon(MeleeWeaponDTO weapon);
        IEnumerable<WeaponDTO> Weapons(string category);
    }
}