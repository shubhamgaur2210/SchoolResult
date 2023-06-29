using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Optimization;

namespace SchoolResultProject2
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/bootstrap.css", 
                "~/Content/CustomCSS/StyleSheet1.css"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/bootstrap").Include(
                "~/Scripts/bootstrap.bundle.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
                "~/Scripts/jquery-3.6.1.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/student").Include(
                "~/Scripts/CustomJS/Student.js"
                ));

            bundles.Add(new ScriptBundle("~/Scripts/admin").Include(
                "~/Scripts/CustomJS/Admin.js"
                ));
        }
    }
}