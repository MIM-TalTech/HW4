using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Facade
{
        [TestClass]
        public class isFacadeTested : AssemblyTests
    {
        private const string assembly = "HW4.Facade";
        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";

        }
        [TestMethod]
        public void isCommonTested()
        {
            isAllTested(assembly, Namespace("Common"));
        }

        [TestMethod]
        public void isQuantityTested()
        {
            isAllTested(assembly, Namespace("Quantity"));
        }
        [TestMethod]
        public void isTested()
        {
            isAllTested(assembly, base.Namespace("Facade"));
        }
    }
}
