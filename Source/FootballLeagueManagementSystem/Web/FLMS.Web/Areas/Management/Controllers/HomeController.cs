namespace FLMS.Web.Areas.Management.Controllers
{
    using System.Web.Mvc;

    using FLMS.Data;
    using FLMS.Web.Areas.Management.Controllers.Base;

    public class HomeController : ManagementController
    {
        public HomeController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }
    }
}