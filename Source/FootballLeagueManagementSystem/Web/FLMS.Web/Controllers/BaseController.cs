namespace FLMS.Web.Controllers
{
    using System.Web.Mvc;
    using FLMS.Data;
    using FLMS.Data.Models;
    using System.Threading;
    using System.Globalization;

    [HandleError]
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