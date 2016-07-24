using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCEvidencijadodatnogobrazovanja.Models;

namespace MVCEvidencijadodatnogobrazovanja.Controllers
{
    public class UstanovaController : Controller
    {
        private EvidencijaDbContext db = new EvidencijaDbContext();

        // GET: Ustanova
        public ActionResult Index()
        {
            return View(db.Ustanovas.ToList());
        }

        // GET: Ustanova/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ustanova ustanova = db.Ustanovas.Find(id);
            if (ustanova == null)
            {
                return HttpNotFound();
            }
            return View(ustanova);
        }

        // GET: Ustanova/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ustanova/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OIB,PodrucjeRada,Vrsta")] Ustanova ustanova)
        {
            if (ModelState.IsValid)
            {
                db.Ustanovas.Add(ustanova);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ustanova);
        }

        // GET: Ustanova/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ustanova ustanova = db.Ustanovas.Find(id);
            if (ustanova == null)
            {
                return HttpNotFound();
            }
            return View(ustanova);
        }

        // POST: Ustanova/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OIB,PodrucjeRada,Vrsta")] Ustanova ustanova)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ustanova).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ustanova);
        }

        // GET: Ustanova/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ustanova ustanova = db.Ustanovas.Find(id);
            if (ustanova == null)
            {
                return HttpNotFound();
            }
            return View(ustanova);
        }

        // POST: Ustanova/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ustanova ustanova = db.Ustanovas.Find(id);
            db.Ustanovas.Remove(ustanova);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult SearchIndex(string ustanovaVrsta, string searchString)
        {
            var vrstaLst = new List<string>();

            var VrstaQry = from d in db.Ustanovas
                           orderby d.Vrsta
                           select d.Vrsta;
            vrstaLst.AddRange(VrstaQry.Distinct());
            ViewBag.ustanovaVrsta = new SelectList(vrstaLst);

            var movies = from m in db.Ustanovas
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.PodrucjeRada.Contains(searchString));
            }

            if (string.IsNullOrEmpty(ustanovaVrsta))
                return View(movies);
            else
            {
                return View(movies.Where(x => x.Vrsta == ustanovaVrsta));
            }

        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
