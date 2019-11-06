using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GithubPractice01.Models;

namespace GithubPractice01.Controllers
{
    public class BulletinBoardsController : Controller
    {
        private DbContextGitPractice db = new DbContextGitPractice();

        // GET: BulletinBoards
        public ActionResult Index()
        {
            return View(db.BulletinBoards.ToList());
        }

        // GET: BulletinBoards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Create
        public ActionResult Create()
        {
            ViewBag.Typelist = new List<BulletinBoard>();
            foreach (var item in db.BulletinBoards)
            {
                ViewBag.Typelist.Add(item);
            }
            return View();
        }

        // POST: BulletinBoards/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,comment")] BulletinBoard bulletinBoard)
        {
            if (ModelState.IsValid)
            {
                db.BulletinBoards.Add(bulletinBoard);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        // POST: BulletinBoards/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,comment")] BulletinBoard bulletinBoard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bulletinBoard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bulletinBoard);
        }

        // GET: BulletinBoards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        // POST: BulletinBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BulletinBoard bulletinBoard = db.BulletinBoards.Find(id);
            db.BulletinBoards.Remove(bulletinBoard);
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
