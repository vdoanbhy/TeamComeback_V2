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
    public class MembersController : Controller
    {
        private TeamComeback_V2Context db = new TeamComeback_V2Context();

        // GET: Members
        public ActionResult Index(string search, string gender, int? page)
        {
            MemberIndexViewModel viewModel = new MemberIndexViewModel();
            var members = from m in db.Members
                           select m;
            if (!String.IsNullOrEmpty(search))
            {
                members = members.Where(m => m.FirstName.Contains(search) || m.LastName.Contains(search) || m.DoB.Contains(search) ||
                m.DateOfLastStroke.Contains(search) || m.Address.Contains(search) || m.City.Contains(search) || m.PhoneNumber.Contains(search) ||
                m.Zip.ToString().Contains(search) || m.State.ToString().Contains(search)
                );
                viewModel.Search = search;
            }
            if (!String.IsNullOrEmpty(gender))
            {
                members = members.Where(m => m.Gender.ToString() == gender);
            }
            var genders = members.Select(m => m.Gender.ToString()).Distinct();
            ViewBag.Gender = new SelectList(genders);
            members = members.OrderBy(p => p.LastName);
            const int PageItems = 3;
            int currentPage = (page ?? 1);
            viewModel.Members = members.ToPagedList(currentPage, PageItems); ;
            return View(viewModel);
        }

        // GET: Members/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Members/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LastName,FirstName,Gender,DoB,Address,City,State,Zip,PhoneNumber,DateOfLastStroke")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(member);
        }

        // GET: Members/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstName,Gender,DoB,Address,City,State,Zip,PhoneNumber,DateOfLastStroke")] Member member)
        {
            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Members/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
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
