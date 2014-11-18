﻿namespace FLMS.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using FLMS.Data;
    using FLMS.Web.Controllers;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IFlmsData data) : base(data)
        {
        }
    }
}