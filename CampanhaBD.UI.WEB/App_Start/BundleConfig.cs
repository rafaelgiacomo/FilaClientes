using System.Web;
using System.Web.Optimization;

namespace CampanhaBD.UI.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Content/CreditSurvey/lucy-master/js/bootstrap.min.js",
                      "~/Content/CreditSurvey/lucy-master/js/classie.js",
                      "~/Content/CreditSurvey/lucy-master/js/jquery-1.11.2.min.js",
                      "~/Content/CreditSurvey/lucy-master/js/modernizr.custom.js",
                      "~/Content/CreditSurvey/lucy-master/js/nivo-lightbox.min.js",
                      "~/Content/CreditSurvey/lucy-master/js/owl-carousel.js",
                      "~/Content/CreditSurvey/lucy-master/js/script.js",
                      "~/Content/CreditSurvey/lucy-master/js/smoothscroll.js",
                      "~/Content/CreditSurvey/lucy-master/js/wow.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/CreditSurvey/estilo.css",
                      "~/Content/CreditSurvey/lucy-master/css/animate.css",
                      "~/Content/CreditSurvey/lucy-master/css/bootstrap.min.css",
                      "~/Content/CreditSurvey/lucy-master/css/font-awesome.css",
                      "~/Content/CreditSurvey/lucy-master/css/font-awesome-min.css",
                      "~/Content/CreditSurvey/lucy-master/css/owl.carousel.css",
                      "~/Content/CreditSurvey/lucy-master/css/owl.theme.css",
                      "~/Content/CreditSurvey/lucy-master/css/style.css",
                      "~/Content/CreditSurvey/lucy-master/css/nivo-lightbox/nivolightbox.css",
                      "~/Content/CreditSurvey/lucy-master/css/nivo-lightbox/nivo-lightbox-theme.css"));


        }
    }
}
