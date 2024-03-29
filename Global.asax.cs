using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BRC.Derya.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //test
           
        }
        protected void Session_Start(object sender,EventArgs e)
        {
            int onlineUye = Convert.ToInt32(Application["OnlineVisitor"]);
            onlineUye = onlineUye + 1;
            Application["OnlineVisitor"] = onlineUye;
        }
        protected void Session_End(object sender, EventArgs e)
        {

            int onlineUye = Convert.ToInt32(Application["onuye"]);
            onlineUye = onlineUye - 1;
            Application["OnlineVisitor"] = onlineUye;
        }
    }
}
