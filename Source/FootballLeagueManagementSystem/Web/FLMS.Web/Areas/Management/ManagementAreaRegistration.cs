using System.Web.Mvc;

namespace FLMS.Web.Areas.Management
{
    public class ManagementAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Management";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Management_default",
                "Management/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                //namespaces: new[] { "FLMS.Web.Areas.Management.Controllers" }
            );
        }
    }
}