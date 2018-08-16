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

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.PlayerList = new SelectList(db.Players, "Username", "Username");
            return View();
        }

        
    }
}