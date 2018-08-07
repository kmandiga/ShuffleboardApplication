using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShuffleboardApplication.Models;
using System.Diagnostics;
using System.Linq;

namespace ShuffleboardApplication.Controllers
{
    public class PlayerController : Controller
    {
        private MyDBContext db = new MyDBContext();

        public ActionResult Index()
        {
            return View(db.Players.ToList());
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

            ViewBag.ppg = (int)((double)player1.CummulativePoints / (double)player1.gamesPlayed);
            ViewBag.win = (int)(((double)player1.gamesWon / (double)player1.gamesPlayed )* 100);

            return View(player1);
        }
    }
}