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
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MAGUS.Services
{
    public class InitMapConfig
    {
        public static void CreateObjectMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Weapon, WeaponDTO>()
                    .Include<RangedWeapon, RangedWeaponDTO>().ReverseMap();
                cfg.CreateMap<RangedWeapon, RangedWeaponDTO>().ReverseMap();

                cfg.CreateMap(typeof(IServiceFilter<>), typeof(IRepoFilter<>)).ConvertUsing(typeof(Converter<,>));

                cfg.CreateMap<IdentityUser, ApplicationUser>().ReverseMap();
            });

        }
    }

}
