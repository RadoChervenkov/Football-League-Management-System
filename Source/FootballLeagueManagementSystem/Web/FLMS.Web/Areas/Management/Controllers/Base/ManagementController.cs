namespace FLMS.Web.Areas.Management.Controllers.Base
{
    using System.Web.Mvc;

    using FLMS.Data;
    using FLMS.Web.Controllers;

    [Authorize(Roles = "Manager")]
    public abstract class ManagementController : BaseController
    {
        public ManagementController(IFlmsData data)
            : base(data)
        {
        }
    }
}