﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace HW4.Tests
{
    internal class htmlContentMock : IHtmlContent
    {
        private readonly string content;

        public htmlContentMock(string s)
        {
            content = s;
        }
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            writer.WriteLine(content);
        }

        public override string ToString()
        {
            return content;
        }
    }
}
