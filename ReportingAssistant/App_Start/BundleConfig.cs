using System.Web.Optimization;

namespace ReportingAssistant
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/Bootstrap").Include("~/Scripts/jquery-3.4.1.min.js", "~/Scripts/umd/popper.min.js", "~/Scripts/bootstrap.min.js"));
            bundles.Add(new StyleBundle("~/Style/Bootstrap").Include("~/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Style/Site").Include("~/Content/StyleSheet.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}