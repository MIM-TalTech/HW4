﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HW4.Aids;
using HW4.Facade.Quantity;
using HW4.Pages.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForHtmlExtensionTests : BaseTests
    {

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(EditControlsForHtmlExtension);
        }

        [TestMethod]
        public void EditControlsForTest()
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