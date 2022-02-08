using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
	public class Book
	{
		// ID книги
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }
		// название книги
		[Display(Name = "Название")]
		[Required(ErrorMessage = "Поле должно быть установлено")]
		public string Name { get; set; }
		// автор книги
		[Display(Name = "Автор")]
		[Required(ErrorMessage = "Поле должно быть установлено")]
		public string Author { get; set; }
		// цена
		[DisplayFormat(DataFormatString = "{0:#.## Руб}")]
		[Required(ErrorMessage = "Поле должно быть установлено")]
		public int Price { get; set; }
	}

	public class Author
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Book> Books { get; set; }
	}
}