using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Data
{
    [TestClass]
   public class IsDataTested : AssemblyTests
    {
        private const string assembly = "HW4.Data";
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
        public void isMoneyTested()
        {
            isAllTested(assembly, Namespace("Money"));
        }
        [TestMethod]
        public void isQuantityTested()
        {
            isAllTested(assembly, Namespace("Quantity"));
        }
        [TestMethod]
        public void isTested()
        {
            isAllTested(assembly, base.Namespace("Data"));
        }

    }
}
