﻿using Microsoft.AspNetCore.Html;
using System.IO;
using System.Web;

namespace FluentBootstrapNCore
{
    public class Content : Component
    {
        private readonly object _content;

        internal Content(BootstrapHelper helper, object content)
            : base(helper)
        {
            _content = content;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);
            var htmlContent = _content as IHtmlContent;
            writer.Write(htmlContent != null ? htmlContent.ToHtmlString() : HttpUtility.HtmlEncode(_content));
        }
    }
}
