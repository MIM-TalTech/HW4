using System;
using System.Collections.Generic;
using System.Text;
using Facade;
using HW4.Data;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitViewFactoryTest : BaseTests

    {
    [TestInitialize]
    public virtual void TestInitialize()
    {
        type = typeof(UnitViewFactory);
    }

    [TestMethod]
    public void CreateTest()
    {
        var view = GetRandom.Object<UnitView>();
        var data = UnitViewFactory.Create(view).Data;
        testArePropertyValuesEqual(view, data);
    }

    [TestMethod]
    public void CreateObjectTest()
    {
        var view = GetRandom.Object<UnitView>();
        var data = UnitViewFactory.Create(view).Data;
        testArePropertyValuesEqual(view, data);
    }

    [TestMethod]
    public void CreateViewTest()
    {
        var data = GetRandom.Object<MeasureData>();
        var view = MeasureViewFactory.Create(new Measure(data));
        testArePropertyValuesEqual(view, data);
    }
    }
}
