using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{

		BookContext db = new BookContext();

		public ActionResult Index(int page = 1)
		{
			List<Book> books = db.Books.ToList();
			int pageSize = 3; // количество объектов на страницу
			IEnumerable<Book> booksPerPages = books.Skip((page - 1) * pageSize).Take(pageSize);
			PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = books.Count };
			IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Books = booksPerPages };
			ViewBag.Message = "Это вызов частичного представления из обычного";
			return View(ivm);
			//return View(db.Books);
		}



		[HttpGet]
		public ActionResult Buy(int id)
		{
			ViewBag.BookId = id;
			return View();
		}
		[HttpPost]
		public string Buy(Purchase purchase)
		{
			purchase.Date = DateTime.Now;
			// добавляем информацию о покупке в базу данных
			db.Purchases.Add(purchase);
			// сохраняем в бд все изменения
			db.SaveChanges();
			return "Спасибо," + purchase.Person + ", за покупку!";
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
		//[HttpPost]
		//public ActionResult Create(Book book)
		//{
		//	db.Entry(book).State = EntityState.Added;
		//	db.SaveChanges();

		//	return RedirectToAction("Index");
		//}



		[HttpGet]
		public ActionResult Delete(int id)
		{
			Book b = db.Books.Find(id);
			if (b == null)
			{
				return HttpNotFound();
			}
			return View(b);
		}
		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{
			Book b = db.Books.Find(id);
			if (b == null)
			{
				return HttpNotFound();
			}
			db.Books.Remove(b);
			db.SaveChanges();
			return RedirectToAction("Index");
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
	}
}