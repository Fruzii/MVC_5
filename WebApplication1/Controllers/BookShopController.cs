using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class BookShopController : Controller
	{
		BookContext db = new BookContext();

		// GET: BookShop
		public ActionResult Index()
		{
			return View();
		}


		[HttpGet]
		public ActionResult Array()
		{
			Book firstBook = db.Books.ToList<Book>().FirstOrDefault();
			return View(firstBook);
		}
		[HttpPost]
		public string Array(List<string> names)
		{
			string fin = "";
			for (int i = 0; i < names.Count; i++)
			{
				fin += names[i] + ";  ";
			}
			return fin;
		}



		[HttpGet]
		public ActionResult Add()
		{
			return View(db.Books.ToList());
		}
		[HttpPost]
		public string Add(List<Book> books)
		{
			string str = "";
			foreach (Book b in books)
			{
				str += $"{b.Name}\n\n";
			}
			return str;
		}



		[HttpGet]
		public ActionResult GetAuthor()
		{
			return View();
		}
		[HttpPost]
		public ActionResult GetAuthor(Author author)
		{
			return View();
		}
	}
}