﻿using HW4.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class NamedViewTests : AbstractClassTests<NamedEntityData, UniqueEntityData>
    {
        private class testClass : NamedEntityData { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }


        [TestMethod]
        public void NameTest()
        {
            isNullableProperty(() => obj.Name, x => obj.Name = x);
        }

        [TestMethod]
        public void CodeTest()
        {
            isNullableProperty(() => obj.Code, x => obj.Code = x);
        }
    }

}   


