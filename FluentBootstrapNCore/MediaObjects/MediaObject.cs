﻿using FluentBootstrapNCore.Html;
using FluentBootstrapNCore.Images;
using FluentBootstrapNCore.Links;
using System.IO;
using System.Linq;

namespace FluentBootstrapNCore.MediaObjects
{
    public class MediaObject : Tag, IHasLinkExtensions
    {
        private Element _wrapper;
        private Image _image;

        public string Src { get; set; }
        public string Alt { get; set; }

        internal MediaObject(BootstrapHelper helper)
            : base(helper, "a", Css.MediaLeft)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            // Change to a div if no link was provided, otherwise wrap in a div
            var href = GetAttribute("href");
            if (string.IsNullOrWhiteSpace(href))
                TagName = "div";
            else
            {
                // Copy media CSS classes to the wrapping div
                _wrapper = GetHelper().Div().Component;
                foreach (var mediaClass in CssClasses.Where(x => x.StartsWith("media-")).ToList())
                {
                    _wrapper.AddCss(mediaClass);
                    CssClasses.Remove(mediaClass);
                }
                _wrapper.Start(writer);
            }

            base.OnStart(writer);

            _image = GetHelper().Image(Src, Alt).AddCss(Css.MediaObject).Component;
            _image.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            _image.Finish(writer);

            base.OnFinish(writer);

            if (_wrapper != null)
                _wrapper.Finish(writer);
        }
    }
}
