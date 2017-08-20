using AutoMapper;
using MAGUS.Domain;
using MAGUS.Domain.Models;
using MAGUS.Infrastructure.Interfaces;
using MAGUS.Model;
using MAGUS.Services.Interfaces;
using System;

namespace MAGUS.Services
{
    public class InitMapConfig
    {
        public static void CreateObjectMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Weapon, WeaponDTO>()
                    .Include<RangedWeapon, RangedWeaponDTO>()
                    .Include<MeleeWeapon, MeleeWeaponDTO>().ReverseMap();
                cfg.CreateMap<RangedWeapon, RangedWeaponDTO>().ReverseMap();
                cfg.CreateMap<MeleeWeapon, MeleeWeaponDTO>().ReverseMap();

                cfg.CreateMap(typeof(IServiceFilter<>), typeof(IRepoFilter<>)).ConvertUsing(typeof(Converter<,>));

                cfg.CreateMap<IdentityUser, ApplicationUser>().ReverseMap();
            });

        }
    }

}
