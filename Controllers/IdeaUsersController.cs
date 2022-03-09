using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP1640_TEAM4.Models;

namespace COMP1640_TEAM4.Controllers
{
    public class IdeaUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IdeaUsers
        public ActionResult Index()
        {
            var ideaUsers = db.Idea.Include(i => i.Comment);
            return View(ideaUsers.ToList());
        }

        // GET: IdeaUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.Idea.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            return View(ideaUser);
        }

        // GET: IdeaUsers/Create
        public ActionResult Create()
        {
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description");
            return View();
        }

        // POST: IdeaUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdeaId,CommentId,IsThumbUp,IsThumbDown")] IdeaUser ideaUser)
        {
            if (ModelState.IsValid)
            {
                db.Idea.Add(ideaUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            return View(ideaUser);
        }

        // GET: IdeaUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.Idea.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            return View(ideaUser);
        }

        // POST: IdeaUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdeaId,CommentId,IsThumbUp,IsThumbDown")] IdeaUser ideaUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ideaUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommentId = new SelectList(db.Comments, "Id", "Description", ideaUser.CommentId);
            return View(ideaUser);
        }

        // GET: IdeaUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IdeaUser ideaUser = db.Idea.Find(id);
            if (ideaUser == null)
            {
                return HttpNotFound();
            }
            return View(ideaUser);
        }

        // POST: IdeaUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IdeaUser ideaUser = db.Idea.Find(id);
            db.Idea.Remove(ideaUser);
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
