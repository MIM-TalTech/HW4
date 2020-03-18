using System;
using System.Collections.Generic;
using System.Text;
using Facade;
using HW4.Data;
using HW4.Domain.Quantity;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace HW4.Tests.Facade.Quantity
{
    [TestClass]
    public class MeasureViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(MeasureViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
            var view = GetRandom.Object<MeasureView>();
            var data = MeasureViewFactory.Create(view).Data;
            testArePropertyValuesEqual(view, data);
        }
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
            var data = GetRandom.Object<MeasureData>();
            var view = MeasureViewFactory.Create(new Measure(data));
            testArePropertyValuesEqual(view, data);
        }


    }
}
