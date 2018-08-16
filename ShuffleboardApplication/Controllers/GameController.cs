using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShuffleboardApplication.Models;
using System.Diagnostics;
using System.Net;
namespace ShuffleboardApplication.Controllers
{
    public class GameController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_asc" : "";
            ViewBag.P1SortParm = sortOrder == "P1_des" ? "P1_asc" : "P1_des";
            ViewBag.P2SortParm = sortOrder == "P2_des" ? "P2_asc" : "P2_des";
            ViewBag.MOVSortParm = sortOrder == "mov_des" ? "mov_asc" : "mov_des";
            var games = from g in db.Games
                          select g;
            switch (sortOrder)
            {
                case "date_asc":
                    games = games.OrderBy(g => g.Date);
                    break;
                case "P1_des":
                    games = games.OrderByDescending(g => g.P1);
                    break;
                case "P1_asc":
                    games = games.OrderBy(g => g.P1);
                    break;
                case "P2_des":
                    games = games.OrderByDescending(g => g.P2);
                    break;
                case "P2_asc":
                    games = games.OrderBy(g => g.P2);
                    break;
                case "mov_des":
                    games = games.OrderByDescending(g => g.margin);
                    break;
                case "mov_asc":
                    games = games.OrderBy(g => g.margin);
                    break;
                default:
                    games = games.OrderByDescending(g => g.Date);
                    break;
            }
            return View(games.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.PlayersList = new SelectList(db.Players, "Username", "Username");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "P1, P1Score, P2, P2Score")] Game game)
        {
            
            game.margin = Math.Abs(game.P1Score - game.P2Score);
            game.Date = DateTime.Now;
            Trace.WriteLine("POST /Game/Create");
            
            
            if (ModelState.IsValid)
            {
                db.Games.Add(game);

                var player1 = (from p in db.Players
                               where p.Username == game.P1
                               select p).FirstOrDefault();

                var player2 = (from p in db.Players
                               where p.Username == game.P2
                               select p).FirstOrDefault();

                //here is where you figure out winner 
                
                player1.gamesPlayed++;
                player2.gamesPlayed++;
                player1.CummulativePoints += game.P1Score;
                player2.CummulativePoints += game.P2Score;

                if (game.P1Score > game.P2Score)
                {
                    player1.gamesWon++;
                }
                else
                {
                    player2.gamesWon++;
                }
                db.Entry(player1).State = EntityState.Modified;
                db.Entry(player2).State = EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index");


            }
            return View(game);
        }

        // POST: Games/Delete/5
        public ActionResult Delete(int id)
        {
            Game game = db.Games.Find(id);
            

            var player1 = (from p in db.Players
                           where p.Username == game.P1
                           select p).FirstOrDefault();

            var player2 = (from p in db.Players
                           where p.Username == game.P2
                           select p).FirstOrDefault();

            //here is where you figure out winner 
            player1.gamesPlayed--;
            player2.gamesPlayed--;
            player1.CummulativePoints -= game.P1Score;
            player2.CummulativePoints -= game.P2Score;

            if (game.P1Score > game.P2Score)
            {
                player1.gamesWon--;
            }
            else
            {
                player2.gamesWon--;
            }
            db.Entry(player1).State = EntityState.Modified;
            db.Entry(player2).State = EntityState.Modified;
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult duplicateUsername(string P2, string P1)
        {
            bool something = P2.Equals(P1);
            something = !something;
            return Json(something);
            
        }

       


    }

}