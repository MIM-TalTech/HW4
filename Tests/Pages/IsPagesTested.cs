using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages
{   
    [TestClass]
    public class IsPagesTested
    {
        [TestClass]
        public class isFacadeTested : AssemblyTests
        {
            private const string assembly = "HW4.Pages";
            protected override string Namespace(string name)
            {
                return $"{assembly}.{name}";

            }
            [TestMethod]
            public void isExtensionsTested()
            {
                isAllTested(assembly, Namespace("Extensions"));
            }

            [TestMethod]
            public void isQuantityTested()
            {
                isAllTested(assembly, Namespace("Quantity"));
            }
            [TestMethod]
            public void isTested()
            {
                isAllTested(assembly, base.Namespace("Pages"));
            }
        }
    }
}
