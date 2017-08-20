using AutoMapper;
using MAGUS.Domain;
using MAGUS.Domain.Models;
using MAGUS.Infrastructure.Interfaces;
using MAGUS.Infrastructure.Repositories;
using MAGUS.Model;
using MAGUS.Services.Interfaces;
using MAGUS.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MAGUS.Services.WeaponService
{
    public class WeaponService : IWeaponService
    {
        private readonly IUnitOfWork _uow;

        public WeaponService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        //*********************************************************************
        public IEnumerable<WeaponDTO> FindWeapons(IServiceFilter<WeaponDTO> dtoFilter)
        {
            var repoFilter = MapServiceFilterToRepoFilter<Weapon, WeaponDTO>(dtoFilter);

            IEnumerable<WeaponDTO> rval = _uow.GetRepository<Weapon>().FindAll<WeaponDTO>(repoFilter);
            return rval;
        }
        //*********************************************************************
        public WeaponDTO FindWeapon(IServiceFilter<WeaponDTO> dtoFilter)
        {
            var repoFilter = MapServiceFilterToRepoFilter<Weapon, WeaponDTO>(dtoFilter);
            var rval = _uow.GetRepository<Weapon>().Find<WeaponDTO>(repoFilter.Filter);

            return rval;
        }
        //*********************************************************************
        public IRepoFilter<T> MapServiceFilterToRepoFilter<T, U>(IServiceFilter<U> serviceFilter) where U : class where T : class
        {
            var repoFilter = new RepoFilter<T>();
            repoFilter.Descending = serviceFilter.Descending;
            repoFilter.Filter = Mapper.Map<Expression<Func<T, bool>>>(serviceFilter.Filter);
            repoFilter.Limit = serviceFilter.Limit ?? 100;
            repoFilter.Position = serviceFilter.Position ?? 0;
            repoFilter.Sort = Mapper.Map<Expression<Func<T, object>>>(serviceFilter.Sort);

            return repoFilter;
        }
        //*********************************************************************
        public WeaponDTO CreateRangedWeapon(RangedWeaponDTO weaponDTO)
        {
            Weapon weapon = Mapper.Map<Weapon>(weaponDTO);
            weapon = _uow.GetRepository<Weapon>().Add(weapon);
            weaponDTO = Mapper.Map<RangedWeaponDTO>(weapon);

            return weaponDTO;
        }
        //*********************************************************************
        public WeaponDTO CreateMeleeWeapon(MeleeWeaponDTO weaponDTO)
        {
            Weapon weapon = Mapper.Map<Weapon>(weaponDTO);
            weapon = _uow.GetRepository<Weapon>().Add(weapon);
            weaponDTO = Mapper.Map<MeleeWeaponDTO>(weapon);

            return weaponDTO;
        }
        //*********************************************************************
        public bool UpdateRangedWeapon(RangedWeaponDTO weaponDTO)
        {
            Weapon weapon = Mapper.Map<Weapon>(weaponDTO);
            return _uow.GetRepository<Weapon>().Update(x => x.ID == weapon.ID, weapon);
        }
        //*********************************************************************
        public bool UpdateMeleeWeapon(MeleeWeaponDTO weaponDTO)
        {
            Weapon weapon = Mapper.Map<Weapon>(weaponDTO);
            return _uow.GetRepository<Weapon>().Update(x => x.ID == weapon.ID, weapon);
        }
        //*********************************************************************
        IEnumerable<WeaponDTO> IWeaponService.Weapons(string category)
        {
            throw new NotImplementedException();
        }
        //*********************************************************************
    }
}
