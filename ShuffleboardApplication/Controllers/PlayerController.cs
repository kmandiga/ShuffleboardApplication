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
    }
}