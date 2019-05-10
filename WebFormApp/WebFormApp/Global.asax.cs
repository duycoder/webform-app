using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormApp
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //config
            if(Application["AppNumber"] == null)
            {
                Application["AppNumber"] = 0;
            }
            Application["AppNumber"] = Convert.ToInt32(Application["AppNumber"]) + 1;
        }

        void Session_Start(object sender, EventArgs e)
        {
            if(Application["SessionNumber"] == null)
            {
                Application["SessionNumber"] = 0;
            }
            Application["SessionNumber"] = Convert.ToInt32(Application["SessionNumber"]) + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["SessionNumber"] = Convert.ToInt32(Application["SessionNumber"]) - 1;
        }
    }
}