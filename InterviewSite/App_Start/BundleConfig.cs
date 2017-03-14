﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
namespace InterviewSite.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            CssBundling(bundles);
            JsBundling(bundles);
        }
        public static void CssBundling(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/css/registration")
                .Include(
                "~/Content/Site.css"));
        }
        public static void JsBundling(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/registration")
                .Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/common.js",
                "~/Scripts/registration.js"));
        }
        
    }
}