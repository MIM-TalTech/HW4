using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade.Quantity
{
    public class UnitTermViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(UnitTermViewFactory);
        }
        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<UnitTermView>();
            var data = UnitTermViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<UnitTermData>();
            var view = UnitTermViewFactory.Create(new UnitTerm(data));
            testArePropertyValuesEqual(view, data);
        }

    
    }
}
