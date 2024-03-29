﻿using FluentBootstrapNCore.Html;
using FluentBootstrapNCore.Interfaces;
using FluentBootstrapNCore.Typography;
using System.IO;

namespace FluentBootstrapNCore.Alerts
{
    public class Alert : Tag, IHasTextContent
    {
        public bool Dismissible { set; get; }
        public string Heading { set; get; }

        internal Alert(BootstrapHelper helper)
            : base(helper, "div", Css.Alert, Css.AlertInfo)
        {
            MergeAttribute("role", "alert");
        }

        protected override void OnStart(TextWriter writer)
        {
            if (Dismissible)
                AddCss(Css.AlertDismissible);

            base.OnStart(writer);

            if (Dismissible)
            {
                GetHelper().Element("button").AddAttribute("type", "button").AddCss(Css.Close).AddAttribute("data-dismiss", "alert")
                    .AddChild(_ => GetHelper().Span().AddAttribute("aria-hidden", "true").SetText("\u00D7"))
                    .AddChild(_ => GetHelper().Span().AddCss(Css.SrOnly).SetText("Close"))
                    .Component.StartAndFinish(writer);
            }

            if (!string.IsNullOrWhiteSpace(Heading))
                GetHelper().Strong(Heading + " ").Component.StartAndFinish(writer);
        }
    }
}
