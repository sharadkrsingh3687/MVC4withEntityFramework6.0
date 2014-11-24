using MVCTrainningSample.DAL.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTrainningSample.Controllers
{
    //[CustomAuthorize(RolesConfigKey = "RolesConfigKey")]
    // [CustomAuthorize(UsersConfigKey = "UsersConfigKey")]
    [CustomAuthorize(Roles = "Admin")]
    // [CustomAuthorize(Users = "1")]
    public class AdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
