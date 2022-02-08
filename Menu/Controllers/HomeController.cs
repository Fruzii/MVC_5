using Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Menu.Controllers
{
	public class HomeController : Controller
	{
		ApplicationContext db = new ApplicationContext();

		public ActionResult Menu()
		{
			List<MenuItem> menuItems = db.MenuItems.ToList();

			return PartialView(menuItems);
		}
		// остальные методы
	}
}