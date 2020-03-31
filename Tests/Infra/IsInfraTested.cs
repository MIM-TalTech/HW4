using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string assembly = "HW4.Infra";

        protected override string Namespace(string name)
        {
            return $"{assembly}.{name}";

        }

        [TestMethod]
        public void isQuantityTested()
        {
            isAllTested(assembly, Namespace("Quantity"));
        }

        [TestMethod]
        public void isTested()
        {
            isAllTested(assembly, base.Namespace("Infra"));
        }
    }
}
