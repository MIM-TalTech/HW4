using HW4.Data.Quantity;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade.Quantity
{
    [TestClass]
    public class MeasureTermViewFactoryTests : BaseTests
    {
    [TestInitialize]
    public virtual void TestInitialize()
    {
        type = typeof(MeasureTermViewFactory);
    }
        [TestMethod]
        public void CreateTest() { }
  
    [TestMethod]
    public void CreateObjectTest()
    {
        var view = GetRandom.Object<MeasureView>();
        var data = MeasureViewFactory.Create(view).Data;
        testArePropertyValuesEqual(view, data);
    }
    [TestMethod]
    public void CreateViewTest()
    {
        var data = GetRandom.Object<MeasureTermData>();
        var view = MeasureTermViewFactory.Create(new MeasureTerm(data));
        testArePropertyValuesEqual(view, data);
    }

    
    }
}
