using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HW4.Tests
{
    public static class TestHtml
    {
        public static void testHtmlString(IReadOnlyList<object> actual, IReadOnlyList<string> expected)
        {
            Assert.IsInstanceOfType(actual, typeof(List<object>));
            Assert.AreEqual(expected.Count, actual.Count);
            for (var i = 0; i < actual.Count; i++)
            {
                var a = actual[i].ToString();
                var e = expected[i];
                Assert.IsTrue(a.Contains((e)), $"{e} != {a}");
            }
        }
    }
}
