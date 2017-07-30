﻿using System.Web;
using System.Web.Optimization;

namespace MAGUS.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/lib/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/lib/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/vue").Include(
                "~/Scripts/lib/vue/vue.js"));

            bundles.Add(new ScriptBundle("~/app").Include(
                    "~/Scripts/app/app.datamodel.js",
                    "~/Scripts/app/app.viewmodel.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/lib/bootstrap/css/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
