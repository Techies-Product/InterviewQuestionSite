using System;
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
            bundles.Add(new StyleBundle("~/css/login")
                .Include(
                "~/Content/Site.css"));
            bundles.Add(new StyleBundle("~/css/home")
                .Include(
                "~/Content/Site.css",
                "~/Content/home_page.css"));
            bundles.Add(new StyleBundle("~/css/create_question")
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

            bundles.Add(new ScriptBundle("~/js/login")
                .Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/common.js",
                "~/Scripts/login.js"));

            bundles.Add(new ScriptBundle("~/js/home")
                .Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/common.js"));

            bundles.Add(new ScriptBundle("~/js/create_question")
                .Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/common.js",
                "~/Scripts/tinymce/jquery.tinymce.js",
                "~/Scripts/create_question.js"));

        }
        
    }
}