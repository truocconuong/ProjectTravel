using System.Web.Mvc;

namespace TravelTester.Areas.Main
{
    public class MainAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Main";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Main_default",
                "Main/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
            context.MapRoute(
             name: "CheckOut",
              url: "Main/Tours/CheckOut/{id}",
            defaults: new { controller = "Tours", action = "AddOrder", id = UrlParameter.Optional }
);
        }
    }
}