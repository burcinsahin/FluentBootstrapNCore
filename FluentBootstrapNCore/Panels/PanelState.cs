﻿using System.ComponentModel;

namespace FluentBootstrapNCore.Panels
{
    public enum PanelState
    {
        [Description(Css.PanelDefault)]
        Default,
        [Description(Css.PanelPrimary)]
        Primary,
        [Description(Css.PanelSuccess)]
        Success,
        [Description(Css.PanelInfo)]
        Info,
        [Description(Css.PanelWarning)]
        Warning,
        [Description(Css.PanelDanger)]
        Danger
    }
}
