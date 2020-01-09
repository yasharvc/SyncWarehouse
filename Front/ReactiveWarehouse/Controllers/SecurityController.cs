using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactiveWarehouse.Controllers
{
    public class SecurityController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
		[HttpPost]
		public JsonResult Login(string username,string password)
		{
			if()
		}
    }
}