using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Controllers
{
	public class MyController : Controller
	{
		//public void Execute(RequestContext requestContext)
		//{
		//	string ip = requestContext.HttpContext.Request.UserHostAddress;
		//	var response = requestContext.HttpContext.Response;
		//	response.Write("<h2>Ваш IP-адрес: " + ip + "</h2>");
		//}

		public string Index()
		{
			string browser = HttpContext.Request.Browser.Browser;
			string user_agent = HttpContext.Request.UserAgent;
			string url = HttpContext.Request.RawUrl;
			string ip = HttpContext.Request.UserHostAddress;
			string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
			return "<p>Browser: " + browser + "</p><p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
					"</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
		}

		public string Square(int a = 10, int h = 3)
		{
			double s = a * h / 2.0;
			return "<h2>Площадь треугольника с основанием " + a +
							" и высотой " + h + " равна " + s + "</h2>";
		}

		public RedirectResult Redirect()
		{
			return Redirect("/Home/Index");
		}

		public ActionResult Test()
		{
			//return new HttpStatusCodeResult(404);
			return new HttpUnauthorizedResult();
			//return HttpNotFound();
			//return Content("<h2>aaaaaaaaaaaaaa<h2>");
		}

		public FileResult GetFile()
		{
			// Путь к файлу
			string file_path = Server.MapPath("~/Files/PDFIcon.pdf");
			// Тип файла - content-type
			string file_type = "application/pdf";
			// Имя файла - необязательно
			string file_name = "PDFIcon.pdf";
			return File(file_path, file_type, file_name);
		}

		public string ContextData()
		{
			HttpContext.Response.Write("<h1>Hello World</h1>");

			string user_agent = HttpContext.Request.UserAgent;
			string url = HttpContext.Request.RawUrl;
			string ip = HttpContext.Request.UserHostAddress;
			string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;
			return "<p>User-Agent: " + user_agent + "</p><p>Url запроса: " + url +
					"</p><p>Реферер: " + referrer + "</p><p>IP-адрес: " + ip + "</p>";
		}
	}
}