using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(AdvancedTechniques.Web.App_Start.BundleConfig), "RegisterBundles")]

namespace AdvancedTechniques.Web.App_Start
{
	public class BundleConfig
	{
        public static void RegisterBundles()
		{
            StyleBundle cssStyleBundle = new StyleBundle("~/Content/css");

            ScriptBundle scriptBundle = new ScriptBundle("~/Scripts/js");

            ScriptBundle signalRBundle = new ScriptBundle("~/Scripts/signalRJs");

            ScriptBundle scriptBookingValidation = new ScriptBundle("~/Scripts/bookingValidation");

            signalRBundle.Include("~/Scripts/jquery.signalR-2.2.0.js");

            scriptBookingValidation.Include(
                "~/Scripts/validateBooking.js",
                "~/Scripts/jquery.validate.js",
                "~/Scripts/jquery.validate.unobtrusive.js",
                "~/Scripts/jquery.validate.date.js"
                );

            scriptBundle.Include(
                "~/Scripts/jquery-1.11.2.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/moment.js",
                "~/Scripts/bootstrap-datetimepicker.js",
                "~/Scripts/jquery-migrate-1.1.1.js",
                "~/Scripts/script.js",
                "~/Scripts/superfish.js",
                "~/Scripts/jquery.equalheights.js",
                "~/Scripts/jquery.mobilemenu.js",
                "~/Scripts/jquery.easing.1.3.js",
                "~/Scripts/tmStickUp.js",
                "~/Scripts/jquery.ui.totop.js",
                "~/Scripts/touchTouch.jquery.js");

            cssStyleBundle.Include(
               "~/Content/css/bootstrap.css",
               "~/Content/css/bootstrap-datetimepicker.css",
               "~/Content/css/form.css",
               "~/Content/css/booking.css",
               "~/Content/css/stuck.css",
               "~/Content/css/style.css",
               "~/Content/css/touchTouch.css")
               .Include("~/Content/css/font-awesome.css", new CssRewriteUrlTransform());

            BundleTable.Bundles.Add(cssStyleBundle);
            BundleTable.Bundles.Add(scriptBundle);
            BundleTable.Bundles.Add(scriptBookingValidation);
            BundleTable.Bundles.Add(signalRBundle);
		}
	}
}
