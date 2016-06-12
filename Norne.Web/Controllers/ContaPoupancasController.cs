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
    public class ContaPoupancasController : Controller
    {
        private BancoContext db = new BancoContext();

        // GET: ContaPoupancas
        public ActionResult Index()
        {
            return View(db.ContaPoupancas.ToList());
        }

        // GET: ContaPoupancas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaPoupanca contaPoupanca = db.ContaPoupancas.Find(id);
            if (contaPoupanca == null)
            {
                return HttpNotFound();
            }
            return View(contaPoupanca);
        }

        // GET: ContaPoupancas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContaPoupancas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Saldo,Numero,Status")] ContaPoupanca contaPoupanca)
        {
            if (ModelState.IsValid)
            {
                db.ContaPoupancas.Add(contaPoupanca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contaPoupanca);
        }

        // GET: ContaPoupancas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaPoupanca contaPoupanca = db.ContaPoupancas.Find(id);
            if (contaPoupanca == null)
            {
                return HttpNotFound();
            }
            return View(contaPoupanca);
        }

        // POST: ContaPoupancas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Saldo,Numero,Status")] ContaPoupanca contaPoupanca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contaPoupanca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contaPoupanca);
        }

        // GET: ContaPoupancas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContaPoupanca contaPoupanca = db.ContaPoupancas.Find(id);
            if (contaPoupanca == null)
            {
                return HttpNotFound();
            }
            return View(contaPoupanca);
        }

        // POST: ContaPoupancas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContaPoupanca contaPoupanca = db.ContaPoupancas.Find(id);
            db.ContaPoupancas.Remove(contaPoupanca);
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
