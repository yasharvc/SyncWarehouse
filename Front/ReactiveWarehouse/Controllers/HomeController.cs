using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReactiveWarehouse.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var x = IoC.IoC.GetIoC().Resolve<IProductRepository>();
			x.Insert(new Models.Product
			{
				Id = 1
			});
			return View();
		}
	}
}