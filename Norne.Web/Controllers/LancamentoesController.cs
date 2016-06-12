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
    public class LancamentoesController : Controller
    {
        private BancoContext db = new BancoContext();

        // GET: Lancamentoes
        public ActionResult Index()
        {
            return View(db.Lancamentoes.ToList());
        }

        // GET: Lancamentoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamentoes.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            return View(lancamento);
        }

        // GET: Lancamentoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lancamentoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MomentoLancamento,ValorLancamento")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                db.Lancamentoes.Add(lancamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lancamento);
        }

        // GET: Lancamentoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamentoes.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            return View(lancamento);
        }

        // POST: Lancamentoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MomentoLancamento,ValorLancamento")] Lancamento lancamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lancamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lancamento);
        }

        // GET: Lancamentoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lancamento lancamento = db.Lancamentoes.Find(id);
            if (lancamento == null)
            {
                return HttpNotFound();
            }
            return View(lancamento);
        }

        // POST: Lancamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lancamento lancamento = db.Lancamentoes.Find(id);
            db.Lancamentoes.Remove(lancamento);
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
