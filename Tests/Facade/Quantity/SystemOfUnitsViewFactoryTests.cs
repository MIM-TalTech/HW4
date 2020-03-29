using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade.Quantity
{
    [TestClass] 
    public class SystemOfUnitsViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(SystemOfUnitsViewFactory);
        }
        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<SystemOfUnitsView>();
            var data = SystemOfUnitsViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<SystemOfUnitsData>();
            var view = SystemOfUnitsViewFactory.Create(new SystemOfUnits(data));
            testArePropertyValuesEqual(view, data);
        }

    
    }
}
