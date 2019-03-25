using Autofac;
using Autofac.Integration.Mvc;
using BRC.Derya.Business.Abstract;
using BRC.Derya.Business.Concrete;
using BRC.Derya.DataAccsess.Abstract;
using BRC.Derya.DataAccsess.Concrete;
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
            
            builder.RegisterType<IletisimManager>().As<IIletisimService>();
            builder.RegisterType<EfIletisimDal>().As<IIletisimDal>();
            builder.RegisterType<GaleriManager>().As<IGaleriService>();
            builder.RegisterType<EfGaleriDal>().As<IGaleriDal>();
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<EfKullaniciDal>().As<IKUllaniciDal>();
            builder.RegisterType<MedyaManager>().As<IMedyaService>();
            builder.RegisterType<EfMedyaDal>().As<IMedyaDal>();
            builder.RegisterType<SliderManager>().As<ISliderService>();
            builder.RegisterType<EfSliderDal>().As<ISliderDal>();
            builder.RegisterType<UrunlerManager>().As<IUrunlerService>();
            builder.RegisterType<EfUrunlerDal>().As<IUrunlerDal>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

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
