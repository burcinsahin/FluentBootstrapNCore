﻿using FluentBootstrapNCore.Forms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace FluentBootstrapNCore.Mvc.Forms
{
    public class ValidationSummary<TModel> : FormControl
    {
        public bool IncludePropertyErrors { get; set; }

        internal ValidationSummary(BootstrapHelper helper)
            : base(helper, "div", Css.FormControlStatic, Css.TextDanger)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            // Output the summary
            var validationSummary = this.GetHtmlHelper<TModel>().ValidationSummary(!IncludePropertyErrors);
            if (validationSummary != null)
                writer.Write(validationSummary.ToHtmlString());

            // Indicate to the form that it's been written
            var form = GetComponent<Form>();
            if (form != null)
                form.GetOverride<FormOverride<TModel>>().HideValidationSummary = true;
        }
    }
}
