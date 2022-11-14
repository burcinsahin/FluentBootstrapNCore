﻿using FluentBootstrapCore.Mvc;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.IO;
using System.Reflection.Metadata;
using System.Text.Encodings.Web;

namespace FluentBootstrapCore
{
    public static class HtmlHelperExtensions
    {
        public static MvcBootstrapHelper<TModel> Bootstrap<TModel>(this IHtmlHelper<TModel> htmlHelper)
        {
            return new MvcBootstrapHelper<TModel>(htmlHelper);
        }

        // This allows getting a BootstrapHelper given a weakly-typed HtmlHelper (you must specify a model, even if it's just a new object)
        // It can also be used to get a BootstrapHelper for a type that's different than the model (I.e., extra forms on the page)
        // Adapted from an answer to http://stackoverflow.com/questions/1321254/asp-net-mvc-typesafe-html-textboxfor-with-different-outpuTHelper
        [Obsolete("Not supported for now. Maybe in the future", true)]
        public static MvcBootstrapHelper<TModel> Bootstrap<TModel>(this IHtmlHelper htmlHelper, TModel model)
        {
            //// Create a dummy controller context if we need one (this might happen with RazorGenerator/RazorDatabase)
            //ControllerContext controllerContext = htmlHelper.ViewContext.Controller.ControllerContext
            //    ?? new ControllerContext(htmlHelper.ViewContext.HttpContext, htmlHelper.ViewContext.RouteData, htmlHelper.ViewContext.Controller);

            //ViewContext newViewContext = new ViewContext(
            //    controllerContext,
            //    htmlHelper.ViewContext.View,
            //    new ViewDataDictionary(htmlHelper.ViewDataContainer.ViewData) { Model = model },
            //    htmlHelper.ViewContext.TempData,
            //    htmlHelper.ViewContext.Writer);
            //ProxyViewDataContainer viewDataContainer = new ProxyViewDataContainer(htmlHelper.ViewDataContainer, newViewContext.ViewData);
            //return new MvcBootstrapHelper<TModel>(new HtmlHelper<TModel>(newViewContext, viewDataContainer, htmlHelper.RouteCollection));
            throw new NotSupportedException();
        }
        internal static ModelExpressionProvider GetModelExpressionProvider(this IHtmlHelper htmlHelper)
        {
            var modelExpressionProvider = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(ModelExpressionProvider)) as ModelExpressionProvider;
            if (modelExpressionProvider == null)
                throw new InvalidOperationException($"{nameof(ModelExpressionProvider)} must be registered!");
            return modelExpressionProvider;
        }

        internal static IUrlHelper? GetUrlHelper(this IHtmlHelper htmlHelper)
        {
            var urlHelperFactory = htmlHelper.ViewContext.HttpContext.RequestServices.GetService(typeof(IUrlHelperFactory)) as IUrlHelperFactory;
            if (urlHelperFactory == null)
                throw new InvalidOperationException($"{nameof(IUrlHelperFactory)} must be registered!");
            var urlHelper = urlHelperFactory.GetUrlHelper(htmlHelper.ViewContext);
            return urlHelper;
        }

        //internal class ProxyViewDataContainer : IViewDataContainer
        //{
        //    public IViewDataContainer ViewDataContainer { get; private set; }
        //    public ViewDataDictionary ViewData { get; set; }

        //    public ProxyViewDataContainer(IViewDataContainer viewDataContainer, ViewDataDictionary viewData)
        //    {
        //        ViewDataContainer = viewDataContainer;
        //        ViewData = viewData;
        //    }
        //}
    }
}
