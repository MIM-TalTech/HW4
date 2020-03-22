using System;
using System.Collections.Generic;
using System.Text;
using HW4.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages.Extensions
{
    [TestClass]
    public class DetailsTableForHtmlExtensionTests : BaseTests
    {

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(DetailsTableForHtmlExtension);
        }

        [TestMethod]
        public void DetailsTableForTest()
        {
            Assert.Inconclusive();
        }
    }
}
