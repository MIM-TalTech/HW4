using HW4.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages.Extensions
{
    [TestClass]
    public class TableRowForHtmlExtensionTests : BaseTests
    {

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TableRowForHtmlExtension);
        }

        [TestMethod]
        public void TableRowForTest()
        {
            Assert.Inconclusive();
        }
    }
}