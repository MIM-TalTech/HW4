using HW4.Facade.Common;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitFactorViewTests : SealedClassTests<UnitFactorView, PeriodView>
    {
        [TestMethod]
        public void UnitIdTest() => isNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        [TestMethod]
        public void SystemOfUnitsIdTest() => isNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);
        [TestMethod]
        public void FactorTest() => isProperty(() => obj.Factor, x => obj.Factor = x);

    }
}
