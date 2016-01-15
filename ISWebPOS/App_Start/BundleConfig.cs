using System.Web;
using System.Web.Optimization;

namespace ISWebPOS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // =============
            // Template CSS
            // =============
            bundles.Add(new StyleBundle("~/Template/Css").Include(
                "~/bootstrap/css/bootstrap.min.css",
                "~/font-awesome/css/font-awesome.css",
                "~/font-awesome/css/font-awesome.min.css",
                "~/Content/ionicons.min.css",
                "~/dist/css/AdminLTE.min.css",
                "~/dist/css/skins/_all-skins.min.css",
                "~/wijmo/styles/wijmo.min.css",
                "~/Content/style.css"));

            // ============
            // Template JS
            // ============
            bundles.Add(new ScriptBundle("~/Template/Js").Include(
                "~/plugins/jQuery/jQuery-2.1.4.min.js",
                "~/bootstrap/js/bootstrap.min.js",
                "~/plugins/slimScroll/jquery.slimscroll.min.js",
                "~/plugins/fastclick/fastclick.min.js",
                "~/plugins/iCheck/icheck.min.js",
                "~/dist/js/demo.js",
                "~/Scripts/respond.js",
                "~/Scripts/respond.min.js",
                "~/Scripts/html5shiv.min.js",
                "~/Scripts/toastr.js",
                "~/Scripts/toastr.min.js",
                "~/dist/js/app.min.js",
                "~/dist/js/dashboard.js",
                "~/dist/js/demo.js"
                ));

            // ============
            // Software JS
            // ============
            bundles.Add(new ScriptBundle("~/Software/Js").Include(
            
                
                ));


            // =========
            // Wijmo JS
            // =========
            bundles.Add(new ScriptBundle("~/Wijmo/Js").Include(
                "~/wijmo/controls/wijmo.min.js",
                "~/wijmo/controls/wijmo.input.min.js",
                "~/wijmo/controls/wijmo.grid.min.js",
                "~/wijmo/controls/wijmo.chart.min.js"));
        }
    }
}
