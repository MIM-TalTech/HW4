using System;
using System.Collections.Generic;
using System.Text;
using HW4.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages.Extensions
{
    public class DisplayControlsForHtmlExtensionTests
    {
        [TestClass]
        public class DisplayControlsForTests : BaseTests
        {

            [TestInitialize]
            public virtual void TestInitialize()
            {
                type = typeof(DisplayControlsForHtmlExtension);
            }

            [TestMethod]
            public void DisplayControlsForTest()
            {
                Assert.Inconclusive();
            }
        }
    }
}
