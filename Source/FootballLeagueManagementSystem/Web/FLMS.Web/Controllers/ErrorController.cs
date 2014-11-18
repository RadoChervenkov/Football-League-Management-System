namespace FLMS.Web.Controllers
{
    using System.Web.Mvc;
    using FLMS.Data;
    
    public class ErrorController : BaseController
    {
        public ErrorController(IFlmsData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View("Error");
        }
    }
}