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

        public ActionResult Index()
        {
            return View(db.Games.ToList());
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
    }
}