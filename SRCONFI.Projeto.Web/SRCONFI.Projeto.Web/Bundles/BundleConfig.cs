using System.Web.Optimization;

namespace SRCONFI.Projeto.Web.Bundles
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Content/jquery-ui.css",
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap.mim.css",
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/parsley").Include(
                  "~/Content/parsley.css",
                  "~/Scripts/parsley-2.6.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquerymask").Include(
                "~/Scripts/jquery.mask-1.14.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content").Include(
              "~/Content/jquery.validate.bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/css/Layout").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css/Layout/index").Include("~/Content/Css/Layout/index.css"));
       
        }
    }
}