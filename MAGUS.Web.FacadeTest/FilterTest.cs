using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MAGUS.Web.Facade.Interfaces;
using MAGUS.Web.Facade.FilterMap;
using MAGUS.Web.Facade.Models;
using MAGUS.Domain;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace MAGUS.Web.FacadeTest
{
    [TestClass]
    public class FilterTest
    {
        [TestMethod]
        public void AbstractMinMaxFilterTest()
        {
            var intFilter = new MinMaxFilter<int?> { Min = 12, Max = 12 };

            var operation = GetOperation(intFilter);

            Assert.AreEqual(OperationType.Equal, operation);
        }

        private OperationType GetOperation(IMinMaxFilter filter)
        {
            return filter.Operation();
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            IWeaponFilter weaponFilter = new WeaponFilter();
            weaponFilter.Cost = new MinMaxFilter<int?> { Min = 12, Max = 45 };
            weaponFilter.Name = "Kah";

            var expressionBuilder = new ExpressionBuilder();

            var resultExpression = expressionBuilder.CreateExpression<WeaponDTO, IWeaponFilter>(weaponFilter);

            List<WeaponDTO> testDTOList = new List<WeaponDTO>();
            testDTOList.Add(new WeaponDTO { Cost = 0, Name = "Kahrei" });
            testDTOList.Add(new WeaponDTO { Cost = 32 });
            testDTOList.Add(new WeaponDTO { Cost = 70 });


            Expression<Func<WeaponDTO, bool>> expectExpression = (x) => x.Cost >= 12 && x.Cost <= 45;

            Assert.AreEqual(expectExpression.Compile().Invoke(testDTOList[0]), resultExpression.Compile().Invoke(testDTOList[0]));

        }
    }
}
