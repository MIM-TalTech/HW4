﻿using Facade;
using HW4.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Common
{
    [TestClass]
    public class PeriodViewTests : AbstractClassTests<PeriodView, object>
    {
        private class testClass : PeriodView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod] public void ValidFromTest()
        {
            //var d = DateTime.Now;
            //obj.ValidFrom = d;
            //Assert.AreNotEqual(d, obj.ValidFrom);
            //obj.ValidFrom = d;
            //Assert.AreEqual(d, obj.ValidFrom);
            isNullableProperty(() => obj.ValidFrom, x=> obj.ValidFrom = x);
        }
        [TestMethod]
        public void ValidToTest()
        {
            //var d = DateTime.Now;
            //obj.ValidFrom = d;
            //Assert.AreNotEqual(d, obj.ValidTo);
            //obj.ValidTo = d;
            //Assert.AreEqual(d, obj.ValidTo);
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x);
        }

       
    }

}   


