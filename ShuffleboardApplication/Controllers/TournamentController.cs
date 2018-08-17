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
    public class TournamentController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Details(int? id)
        {
            Tournament tourney = db.Tournaments.Find(id);
            return View(tourney);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.PlayerList = new SelectList(db.Players, "Username", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numPlayers,TournamentName,DateCreated")] Tournament tournament)
        {
            tournament.DateCreated = DateTime.Now;
            Trace.WriteLine("POST /Tournament/Create");

            List<Player> pListy = new List<Player>();
            string s;
            string userName;
            db.Configuration.LazyLoadingEnabled = false;

            for(int i = 1; i <= tournament.numPlayers; i++)
            {
                s = "P" + i;
               
                userName = Request.Form[s];
                var player = (from p in db.Players
                               where p.Username == userName
                               select p).FirstOrDefault();
                pListy.Add(player);
            }

            tournament.Players = pListy;

            //tournament.Players = pListy;

            db.Tournaments.Add(tournament);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = tournament.TournamentID});
        }

        [HttpPost]
        public JsonResult duplicateUsername(List<string> pList, int numPlayers)
        {
            for(int i = 0; i< pList.Count; i++)
            {
                for(int j = 0; j < i; j++)
                {
                    if (pList[i] == pList[j])
                    {
                        return Json(false);
                    }
                }
            }
            return Json(true);

        }

    }
}