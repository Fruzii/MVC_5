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
		public ActionResult Detail(int id)
		{
			Book b = db.Books.Find(id);
			if (b == null)
			{
				return HttpNotFound();
			}
			return View(b);
		}


		[HttpGet]
		public ActionResult EditBook(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Book book = db.Books.Find(id);
			if (book != null)
			{
				return View(book);
			}
			return HttpNotFound();
		}
		[HttpPost]
		public ActionResult EditBook(Book book)
		{
			db.Entry(book).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}



		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Book book)
		{
			db.Books.Add(book);
			db.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}