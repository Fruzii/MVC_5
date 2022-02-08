using Soccer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Soccer.Controllers
{
	public class HomeController : Controller
	{
		SoccerContext db = new SoccerContext();

		// Выводим всех футболистов
		public ActionResult Index(int? team, string position)
		{
			IQueryable<Player> players = db.Players.Include(p => p.Team);
			if (team != null && team != 0)
			{
				players = players.Where(p => p.TeamId == team);
			}
			if (!String.IsNullOrEmpty(position) && !position.Equals("Все"))
			{
				players = players.Where(p => p.Position == position);
			}

			List<Team> teams = db.Teams.ToList();
			// устанавливаем начальный элемент, который позволит выбрать всех
			teams.Insert(0, new Team { Name = "Все", Id = 0 });

			PlayersListViewModel plvm = new PlayersListViewModel
			{
				Players = players.ToList(),
				Teams = new SelectList(teams, "Id", "Name"),
				Positions = new SelectList(new List<string>()
						{
								"Все",
								"Нападающий",
								"Полузащитник",
								"Защитник",
								"Вратарь"
						})
			};
			return View(plvm);
		}



		public ActionResult TeamDetails(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			Team team = db.Teams.Include(t => t.Players).FirstOrDefault(t => t.Id == id);
			if (team == null)
			{
				return HttpNotFound();
			}
			return View(team);
		}



		[HttpGet]
		public ActionResult Create()
		{
			// Формируем список команд для передачи в представление
			SelectList teams = new SelectList(db.Teams, "Id", "Name");
			ViewBag.Teams = teams;
			return View();
		}

		[HttpPost]
		public ActionResult Create(Player player)
		{
			//Добавляем игрока в таблицу
			db.Players.Add(player);
			db.SaveChanges();
			// перенаправляем на главную страницу
			return RedirectToAction("Index");
		}



		[HttpGet]
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return HttpNotFound();
			}
			// Находим в бд футболиста
			Player player = db.Players.Find(id);
			if (player != null)
			{
				// Создаем список команд для передачи в представление
				SelectList teams = new SelectList(db.Teams, "Id", "Name", player.TeamId);
				ViewBag.Teams = teams;
				return View(player);
			}
			return RedirectToAction("Index");
		}

		[HttpPost]
		public ActionResult Edit(Player player)
		{
			db.Entry(player).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}