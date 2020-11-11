using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using TeamComeback_V2.Data;
using TeamComeback_V2.Models;
using TeamComeback_V2.ViewModels;

namespace TeamComeback_V2.Controllers
{
    [Authorize]
    public class RegistarsController : Controller
    {
        private TeamComeback_V2Context db = new TeamComeback_V2Context();

        // GET: Registars
        public ActionResult Index(string attendance, string search, int? page)
        {
            EnrollmentIndexViewModel viewModel = new EnrollmentIndexViewModel();
            var registars = db.Registars.Include(r => r.Course).Include(r => r.Member);

            if (!String.IsNullOrEmpty(search))
            {
                registars = registars.Where(r => r.Course.Name.Contains(search) || r.Course.Session.Name.Contains(search) ||
                r.Member.LastName.Contains(search) || r.Member.FirstName.Contains(search)
                || r.Course.Time.Contains(search) || r.Course.Session.DateStart.ToString().Contains(search) || r.Course.Session.DateEnd.ToString().Contains(search)
                );
                ViewBag.Search = search;
            }
            if (!String.IsNullOrEmpty(attendance))
            {
                registars = registars.Where(r => r.Attendance.ToString() == attendance);
            }
            var attendances = registars.Select(r =>r.Attendance.ToString()).Distinct();
            ViewBag.Attendance = new SelectList(attendances);

            registars = registars.OrderBy(p => p.Course.Name);
            const int PageItems = 10;
            int currentPage = (page ?? 1);
            viewModel.Registars = registars.ToPagedList(currentPage, PageItems);
            return View(viewModel);
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
        public ActionResult Create([Bind(Include = "RegistarID,MemberID,CourseID,Attendance,EnrollmentDate")] Registar registar)
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
        public ActionResult Edit([Bind(Include = "RegistarID,MemberID,CourseID,Attendance,EnrollmentDate")] Registar registar)
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

        public void ExportToCSV()
        {
            List<Registar> registarList = db.Registars.ToList<Registar>();
            StringWriter sw = new StringWriter();
            sw.WriteLine("\"Session\",\"Name\",\"Day\",\"Time\",\"FirstName\",\"LastName\",\"DateStart\",\"DateEnd\",\"EnrollmentDate\",\"InstructorName\",\"Attendance\",\"Cost\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ExportedEnrollmentList.csv");
            Response.ContentType = "text/csv";

            foreach (var item in registarList)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\"",
                    item.Course.Session.Name,
                    item.Course.Name,
                    item.Course.Day,
                    item.Course.Time,
                    item.Member.FirstName,
                    item.Member.LastName,
                    item.Course.Session.DateStart,
                    item.Course.Session.DateEnd,
                    item.EnrollmentDate,
                    item.Course.InstructorName,
                    item.Attendance,
                    item.Course.Cost)
                    );
            }
            Response.Write(sw.ToString());
            Response.End();
        }
        public void ExportToExcel()
        {
            List<Registar> registarList = db.Registars.ToList<Registar>();
            var grid = new GridView();
            grid.DataSource = from item in registarList
                              select new
                              {
                                Session = item.Course.Session.Name,
                                Name = item.Course.Name,
                                Day = item.Course.Day,
                                Time = item.Course.Time,
                                FirstName = item.Member.FirstName,
                                LastName = item.Member.LastName,
                                DateStart = item.Course.Session.DateStart,
                                DateEnd = item.Course.Session.DateEnd,
                                EnrollmentDate = item.EnrollmentDate,
                                InstructorName = item.Course.InstructorName,
                                Attendance = item.Attendance,
                                Cost = item.Course.Cost
                              };
            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=ExportedEnrollmentList.xls");
            Response.ContentType = "application/excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(sw);

            grid.RenderControl(htmlTextWriter);
            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
