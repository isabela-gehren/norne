using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Norne.Web.Models;

namespace Norne.Web.Controllers
{
    public class CorrentistasController : Controller
    {
        private BancoContext db = new BancoContext();

        // GET: Correntistas
        public ActionResult Index()
        {
            return View(db.Correntistas.ToList());
        }

        // GET: Correntistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correntista correntista = db.Correntistas.Find(id);
            if (correntista == null)
            {
                return HttpNotFound();
            }
            return View(correntista);
        }

        // GET: Correntistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Correntistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Senha,Nome,Email,CPF")] Correntista correntista)
        {
            if (ModelState.IsValid)
            {
                db.Correntistas.Add(correntista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(correntista);
        }

        // GET: Correntistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correntista correntista = db.Correntistas.Find(id);
            if (correntista == null)
            {
                return HttpNotFound();
            }
            return View(correntista);
        }

        // POST: Correntistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Senha,Nome,Email,CPF")] Correntista correntista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correntista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(correntista);
        }

        // GET: Correntistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correntista correntista = db.Correntistas.Find(id);
            if (correntista == null)
            {
                return HttpNotFound();
            }
            return View(correntista);
        }

        // POST: Correntistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Correntista correntista = db.Correntistas.Find(id);
            db.Correntistas.Remove(correntista);
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
