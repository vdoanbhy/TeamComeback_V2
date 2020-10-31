using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamComeback_V2.Data;
using TeamComeback_V2.Models;
using TeamComeback_V2.ViewModels;

namespace TeamComeback_V2.Controllers
{
    [Authorize]
    public class SessionsController : Controller
    {
        private TeamComeback_V2Context db = new TeamComeback_V2Context();

        // GET: Sessions
        public ActionResult Index(string search, int? page)
        {
            SessionsIndexViewModel viewModel = new SessionsIndexViewModel();
            var sessions = from s in db.Sessions
                          select s;
            if (!String.IsNullOrEmpty(search))
            {
                sessions = sessions.Where(s => s.Name.Contains(search) ||
                s.DateStart.ToString().Contains(search) ||
                s.DateEnd.ToString().Contains(search));
                viewModel.Search = search;
            }
            sessions = sessions.OrderBy(p => p.Name);
            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Sessions = sessions.ToPagedList(currentPage, PageItems);
            return View(viewModel);
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sessions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,DateStart,DateEnd")] Session session)
        {
            Session matchingSession = db.Sessions.Where(s => string.Compare(s.Name, session.Name, true) == 0).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (session == null)
                {
                    return HttpNotFound();
                }
                if (matchingSession != null)
                {
                    ModelState.AddModelError("Name", "Session must have unique name.");
                    return View(session);
                }
                db.Sessions.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(session);
        }

        // GET: Sessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: Sessions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,DateStart,DateEnd")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(session);
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.Sessions.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.Sessions.Find(id);
            db.Sessions.Remove(session);
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
