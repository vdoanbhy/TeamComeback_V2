using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamComeback_V2.Data;

namespace TeamComeback_V2.Models
{
    public class RegistarsController : Controller
    {
        private TeamComeback_V2Context db = new TeamComeback_V2Context();

        // GET: Registars
        public ActionResult Index()
        {
            var registars = db.Registars.Include(r => r.Course).Include(r => r.Member);
            return View(registars.ToList());
        }

        // GET: Registars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registar registar = db.Registars.Find(id);
            if (registar == null)
            {
                return HttpNotFound();
            }
            return View(registar);
        }

        // GET: Registars/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName");
            return View();
        }

        // POST: Registars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegistarID,MemberID,CourseID")] Registar registar)
        {
            if (ModelState.IsValid)
            {
                db.Registars.Add(registar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", registar.CourseID);
            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName", registar.MemberID);
            return View(registar);
        }

        // GET: Registars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registar registar = db.Registars.Find(id);
            if (registar == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", registar.CourseID);
            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName", registar.MemberID);
            return View(registar);
        }

        // POST: Registars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegistarID,MemberID,CourseID")] Registar registar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", registar.CourseID);
            ViewBag.MemberID = new SelectList(db.Members, "ID", "LastName", registar.MemberID);
            return View(registar);
        }

        // GET: Registars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registar registar = db.Registars.Find(id);
            if (registar == null)
            {
                return HttpNotFound();
            }
            return View(registar);
        }

        // POST: Registars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registar registar = db.Registars.Find(id);
            db.Registars.Remove(registar);
            db.SaveChanges();
            return RedirectToAction("Index");
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
