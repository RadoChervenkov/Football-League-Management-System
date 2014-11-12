namespace FLMS.Web.Controllers
{
    using System.Web.Mvc;
    using System.Data.Entity;
    using FLMS.Data.Models;
    using FLMS.Data;

    public abstract class BaseController : Controller
    {
        public BaseController(IFlmsData data)
        {
            this.Data = data;
        }

        protected IFlmsData Data { get; set; }

        protected ApplicationUser CurrentUser { get; set; }
    }
}