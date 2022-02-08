using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Menu.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext() : base("DefaultConnection")
		{

		}
		public DbSet<MenuItem> MenuItems { get; set; }
	}
}