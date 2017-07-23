using MAGUS.Infrastructure.Interfaces;
using MAGUS.Model;
using MAGUS.Services.WeaponService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace MAGUS.ServicesTest
{
    [TestClass]
    public class WeaponServiceTest
    {
        private List<RangedWeapon> _rangedWeapons;

        [TestInitialize]
        public void Setup()
        {
            _rangedWeapons = new List<RangedWeapon>(GetTesRangedtWeapons());
        }

        //[TestMethod]
        //public void TestWeaponGetByName()
        //{
        //    var mockRepo = new Mock<IGenericRepository<Weapon>>();
        //    mockRepo.Setup(repo => repo.FindAll<Weapon>(It.IsAny<Expression<Func<Weapon, bool>>>()))
        //        .Returns(_rangedWeapons);

        //    var mockUoW = new Mock<IUnitOfWork>();
        //    mockUoW.Setup(m => m.GetRepository<Weapon>()).Returns(mockRepo.Object);

        //    var weaponService = new WeaponService(mockUoW.Object);

        //    //Act
        //    var result = weaponService.GetByName("Fegvyer");

        //    //Assert

        //    Assert.Equals(100, result.Count);
        //}

        //[TestMethod]
        //public void TestGetWeapons()
        //{
        //    var mockRepo = new Mock<IGenericRepository<Weapon>>();
        //    mockRepo.Setup(repo => repo.GetAll<RangedWeapon>()).Returns(_rangedWeapons);

        //    var mockUoW = new Mock<IUnitOfWork>();
        //    mockUoW.Setup(m => m.GetRepository<Weapon>()).Returns(mockRepo.Object);

        //    var weaponService = new WeaponService(mockUoW.Object);

        //    //Act
        //    var result = weaponService.Weapons("ranged").ToList();

        //    //Assert
        //    Assert.AreEqual(100, result.Count);
        //}

        private IList<RangedWeapon> GetTesRangedtWeapons()
        {
            var rval = new List<RangedWeapon>();

            for (int i = 0; i < 100; i++)
            {
                var rangedWeapons = new Mock<RangedWeapon>().SetupAllProperties(); 
                rval.Add(rangedWeapons.Object);
            }

            return rval;

        }
    }
}
