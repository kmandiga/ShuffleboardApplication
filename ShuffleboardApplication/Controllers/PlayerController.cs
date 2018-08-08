using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShuffleboardApplication.Models;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace ShuffleboardApplication.Controllers
{
    public class PlayerController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.gamesWon = string.IsNullOrEmpty(sortOrder) ? "gamesWon_asc" : "";
            ViewBag.UsernameSortParm = sortOrder == "user_des" ? "user_asc" : "user_des";
            ViewBag.gamesPlayed = sortOrder == "numplayed_des" ? "numplayed_asc" : "numplayed_des";
            

            var players = from p in db.Players
                          select p;

            switch(sortOrder)
            {
                case "user_asc":
                    players = players.OrderBy(p => p.Username);
                    break;
                case "user_des":
                    players = players.OrderByDescending(p => p.Username);
                    break;
                case "numplayed_asc":
                    players = players.OrderBy(p => p.gamesPlayed);
                    break;
                case "numplayed_des":
                    players = players.OrderByDescending(p => p.gamesPlayed);
                    break;
                case "gamesWon_asc":
                    players = players.OrderBy(p => p.gamesWon);
                    break;
                default:
                    players = players.OrderByDescending(p => p.gamesWon);
                    break;
            }

            return View(players.ToList());
        }
        public ActionResult Create()
        {
            return View(new Player { });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName, LastName, Username, gamesWon, CummalativePoints")] Player p)
        {
            Trace.WriteLine("POST /Player/Create");
            if (ModelState.IsValid)
            {
                db.Players.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(p);
        }
        [HttpPost]
        public JsonResult UsernameAvailable(string Username)
        {
            var player1 = (from p in db.Players
                           where p.Username == Username
                           select p).FirstOrDefault();
            return Json(player1 == null);
        }

        public ActionResult Details(int? playerID)
        {

            var player1 = (from p in db.Players
                           where p.PlayerID == playerID
                           select p).FirstOrDefault();

            
            if (player1.gamesPlayed > 0)
            {
                ViewBag.ppg = (int)((double)player1.CummulativePoints / (double)player1.gamesPlayed);
                ViewBag.win = (int)(((double)player1.gamesWon / (double)player1.gamesPlayed) * 100);
            }
            {
                ViewBag.ppg = 0;
                ViewBag.win = 0;
            }

            
            var gameList = (from g in db.Games
                        where g.P1 == player1.Username || g.P2 == player1.Username
                        select g).ToList();

            ViewBag.ListGames = gameList;
            return View(player1);
        }
    }
}