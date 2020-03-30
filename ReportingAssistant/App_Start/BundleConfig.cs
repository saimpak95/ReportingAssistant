using System.Web.Optimization;

namespace ReportingAssistant
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include("~/Scripts/jquery-3.4.1.js", "~/Scripts/umd/popper.js", "~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Styles/Bootstrap").Include("~/Content/bootstrap.css"));
            bundles.Add(new StyleBundle("~/Styles/Site").Include("~/Content/StyleSheet.css"));
            BundleTable.EnableOptimizations = true;

        }
    }
}