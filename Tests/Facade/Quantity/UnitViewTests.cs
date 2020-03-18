using System;
using System.Collections.Generic;
using System.Text;
using Facade;
using HW4.Facade.Quantity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace HW4.Tests.Facade.Quantity
{
        [TestClass]
    public class UnitViewTests : SealedClassTests<UnitView, DefinedView>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            isNullableProperty(() => obj.MeasureId, x=> obj.MeasureId =x);
        }
    }
}
