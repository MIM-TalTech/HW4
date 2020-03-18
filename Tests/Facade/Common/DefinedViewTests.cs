using HW4.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Facade;

namespace Tests.Facade.Common
{
    [TestClass]

    public class DefinedViewTests : AbstractClassTests<DefinedView, NamedView>
    {
        private class testClass : DefinedView { }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }


        [TestMethod]
        public void DefinitionTest()
        {
            isNullableProperty(() => obj.Definition, x => obj.Definition = x);
        }
    }

}   


