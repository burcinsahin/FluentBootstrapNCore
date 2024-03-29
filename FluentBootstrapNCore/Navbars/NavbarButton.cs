﻿using FluentBootstrapNCore.Buttons;
using FluentBootstrapNCore.Icons;
using FluentBootstrapNCore.Interfaces;
using System.IO;

namespace FluentBootstrapNCore.Navbars
{
    public class NavbarButton : Tag, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions,
        IHasDisabledAttribute, IHasTextContent, IHasValueAttribute, INavbarComponent
    {
        internal NavbarButton(BootstrapHelper helper)
            : base(helper, "button", Css.Btn, Css.BtnDefault, Css.NavbarBtn, Css.NavbarLeft)
        {
            MergeAttribute("type", "button");
        }

        protected override void OnStart(TextWriter writer)
        {
            // See if we're in a navbar
            if (GetComponent<Navbar>() != null)
            {
                // Make sure we're not in a NavbarNav (close it if we are)
                Pop<NavbarNav>(writer);

                // Make sure we're in a collapse
                if (GetComponent<NavbarCollapse>() == null)
                    GetHelper().NavbarCollapse().Component.Start(writer);
            }

            base.OnStart(writer);
        }
    }
}
