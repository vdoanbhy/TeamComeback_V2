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
    public class CoursesController : Controller
    {
        private TeamComeback_V2Context db = new TeamComeback_V2Context();

        // GET: Courses
        public ActionResult Index(string session, string search, string sortBy, int? page)
        {
            CourseIndexViewModel viewModel = new CourseIndexViewModel();
            var courses = db.Courses.Include(c => c.Session);
            if (!String.IsNullOrEmpty(session))
            {
                courses = courses.Where(c => c.Session.Name == session);
            }
            if (!String.IsNullOrEmpty(search))
            {
                courses = courses.Where(c => c.Name.Contains(search) || c.InstructorName.Contains(search) || c.Time.Contains(search)||
                c.Session.Name.Contains(search) || c.Day.ToString().Contains(search));
                ViewBag.Search = search;
            }
            var sessions = courses.OrderBy(c => c.Session.Name).Select(c =>
                c.Session.Name).Distinct();

            if (!String.IsNullOrEmpty(session))
            {
                courses = courses.Where(p => p.Session.Name == session);
                viewModel.Session = session;
            }
            ViewBag.Session = new SelectList(sessions);

            switch (sortBy)
            {
                case "cost_lowest":
                    courses = courses.OrderBy(c => c.Cost);
                    break;
                case "cost_highest":
                    courses = courses.OrderByDescending(c => c.Cost);
                    break;
                default:
                    courses = courses.OrderBy(p => p.Name);
                    break;
            }

            const int PageItems = 10;
            int currentPage = (page ?? 1);
            viewModel.Courses = courses.ToPagedList(currentPage, PageItems);
            viewModel.SortBy = sortBy;
            viewModel.Sorts = new Dictionary<string, string>
            {
                {"Cost low to high", "cost_lowest" },
                {"Cost high to low", "cost_highest" }
            };

            return View(viewModel);
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.SessionID = new SelectList(db.Sessions, "ID", "Name");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Name,Day,Time,InstructorName,Cost,Description,SessionID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SessionID = new SelectList(db.Sessions, "ID", "Name", course.SessionID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "ID", "Name", course.SessionID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Name,Day,Time,InstructorName,Cost,Description,SessionID")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "ID", "Name", course.SessionID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
