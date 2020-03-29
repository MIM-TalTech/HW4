using System.Collections.Generic;
using HW4.Facade.Quantity;
using HW4.Pages.Extensions;
using Microsoft.AspNetCore.Html;
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
                var obj = new htmlHelperMock<UnitView>().EditControlsFor(x => x.MeasureId);
                Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
            }
            [TestMethod]
            public void HtmlStringTest()
            {
                var expected = new List<string> { "<div", "LabelFor", "EditorFor", "ValidationMessageFor", "</div>" };
                var actual = EditControlsForHtmlExtension.htmlString(new htmlHelperMock<MeasureView>(), x => x.ValidFrom);
                TestHtml.testHtmlString(actual, expected);
            }
        }
    }
}
