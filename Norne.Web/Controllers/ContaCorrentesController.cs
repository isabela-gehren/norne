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
    public class ContaCorrentesController : Controller
    {
        private BancoContext db = new BancoContext();

        // GET: ContaCorrentes
        public ActionResult Index()
        {
            return View(db.ContaCorrentes.ToList());
        }

        // GET: ContaCorrentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = db.ContaCorrentes.Find(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContaCorrentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Saldo,Numero,Status")] ContaCorrente contaCorrente)
        {
            if (ModelState.IsValid)
            {
                db.ContaCorrentes.Add(contaCorrente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = db.ContaCorrentes.Find(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            return View(contaCorrente);
        }

        // POST: ContaCorrentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Saldo,Numero,Status")] ContaCorrente contaCorrente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaCorrente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contaCorrente);
        }

        // GET: ContaCorrentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaCorrente contaCorrente = db.ContaCorrentes.Find(id);
            if (contaCorrente == null)
            {
                return HttpNotFound();
            }
            return View(contaCorrente);
        }

        // POST: ContaCorrentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContaCorrente contaCorrente = db.ContaCorrentes.Find(id);
            db.ContaCorrentes.Remove(contaCorrente);
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
