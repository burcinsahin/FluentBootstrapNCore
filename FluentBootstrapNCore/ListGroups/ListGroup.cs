﻿using FluentBootstrapNCore.Interfaces;

namespace FluentBootstrapNCore.ListGroups
{
    public class ListGroup : Tag,
        ICanCreate<ListGroupItem>,
        ICanCreate<ListGroupButton>
    {
        internal ListGroup(BootstrapHelper helper)
            : base(helper, "div", Css.ListGroup)
        {
            //TODO:collapse
        }
    }
}
