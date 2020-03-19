using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Domain
{
    [TestClass]
    public class isDomainTested : AssemblyTests
    {
        private const string assembly = "HW4.Domain";
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
            isAllTested(assembly, base.Namespace("Domain"));
        }
    }
}
