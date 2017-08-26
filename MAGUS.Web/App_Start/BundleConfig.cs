using System.Web;
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
                      "~/Scripts/lib/bootstrap/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/vue").Include(
                "~/Scripts/lib/vue/vue.js",
                 "~/Scripts/lib/vue-infinite-loading/vue-infinite-loading.js",
                 "~/Scripts/lib/vee-validate/vee-validate.js",
                 "~/Scripts/lib/vee-validate/locale/hu.js"
                ));

            bundles.Add(new ScriptBundle("~/app").Include(
                    "~/Scripts/app/app.datamodel.js",
                    "~/Scripts/app/app.js"

                ));

            bundles.Add(new ScriptBundle("~/globals").Include(
                    "~/Scripts/lib/lodash/lodash.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/weapon-components")
                .Include("~/Scripts/app/weaponedit.component.js")
                .Include("~/Scripts/app/weaponlist.component.js")
                .Include("~/Scripts/app/weapon.viewmodel.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Scripts/lib/bootstrap/css/bootstrap.css",
                      "~/Content/site.css"));


        }
    }
}
