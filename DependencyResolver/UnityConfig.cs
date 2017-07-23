using MAGUS.AspIdentityMongoDB;
using MAGUS.Domain.Models;
using MAGUS.Infrastructure;
using MAGUS.Infrastructure.Interfaces;
using MAGUS.Infrastructure.Repositories;
using MAGUS.Model;
using MAGUS.Services;
using MAGUS.Services.Interfaces;
using MAGUS.Services.WeaponService;
using MAGUS.Web.Facade;
using MAGUS.Web.Facade.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MAGUS.DependencyResolver
{
    public class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<IMongoDbContext, MongoDbContext>(new ContainerControlledLifetimeManager());

            container.RegisterType<MongoDbContext>(new InjectionConstructor());

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            container.RegisterType<IWeaponService, WeaponService>();
            container.RegisterType<IWeaponFacade, WeaponFacade>();

            container.RegisterType<MongoDbContext, ApplicationDbContext>();
            container.RegisterType<UserManager<IdentityUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<ApplicationUserManager>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<IdentityUser>, UserStore>(new HierarchicalLifetimeManager());
            container.RegisterType<IIdentityFacade, IdentityFacade>();
        }
    }
}
