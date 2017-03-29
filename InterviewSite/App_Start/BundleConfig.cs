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
                "~/Content/interview_tags_plugin/css/textext.core.css",
                "~/Content/interview_tags_plugin/css/textext.plugin.tags.css",
                "~/Content/interview_tags_plugin/css/textext.plugin.autocomplete.css",
                "~/Content/interview_tags_plugin/css/textext.plugin.focus.css",
                "~/Content/interview_tags_plugin/css/textext.plugin.prompt.css",
                "~/Content/interview_tags_plugin/css/textext.plugin.arrow.css",
                "~/Content/Site.css",
                "~/Content/create_question.css"
                ));
            bundles.Add(new StyleBundle("~/css/tags")
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
                "~/Content/interview_tags_plugin/js/textext.core.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.tags.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.autocomplete.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.suggestions.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.filter.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.focus.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.prompt.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.ajax.js",
                "~/Content/interview_tags_plugin/js/textext.plugin.arrow.js",
                "~/Scripts/create_question.js"));

            bundles.Add(new ScriptBundle("~/js/tags")
                .Include(
                "~/Scripts/jquery-1.10.2.js",
                "~/Scripts/common.js",
                "~/Scripts/tags.js"));
        }

    }
}