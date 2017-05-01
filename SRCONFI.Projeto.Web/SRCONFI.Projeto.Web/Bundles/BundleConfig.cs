using System.Web.Optimization;

namespace SRCONFI.Projeto.Web.Bundles
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts/required").Include(
                        "~/Scripts/jquery-1.12.4.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/jquery-ui-1.12.1.min.js"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(                        
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(                      
                      "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/parsley").Include(                  
                  "~/Scripts/parsley-2.6.0.js"));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
             "~/Scripts/jquery.inputmask/inputmask.js",
             "~/Scripts/jquery.inputmask/jquery.inputmask.js",
             "~/Scripts/jquery.inputmask/inputmask.extensions.js",
             "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
             //and other extensions you want to include
             "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css/required").Include(
              "~/Content/bootstrap.min.css",
              "~/Content/themes/base/jquery-ui.min.css"));
            //,
            //  "~/Content/jquery.validate.bootstrap.css"

            bundles.Add(new StyleBundle("~/Content/css/parsley").Include("~/Content/Css/Parsley/parsley.css"));

            bundles.Add(new StyleBundle("~/Content/css/Layout").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css/Layout/index").Include("~/Content/Css/Layout/index.css"));
       
        }
    }
}