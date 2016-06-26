using System.Net;
using System.Web.Mvc;
using Norne.Business;
using Norne.Models;
using System.Linq;

namespace Norne.Web.Controllers
{
    public class CorrentistasController : Controller
    {
        private ICorrentistaBusiness business { get; set; }

        // injeção de dependência por construtor
        public CorrentistasController(ICorrentistaBusiness correntistaBusiness)
        {   
            business = correntistaBusiness;
        }

        // GET: Correntistas
        public ActionResult Index()
        {
            //ContaCorrenteBusiness cc = new ContaCorrenteBusiness();
            //var conta = new ContaCorrente();
            //conta.Agencia = new Agencia() { Codigo = 9 };
            //var statatusbusiness = new StatusContaBusiness();
            //conta.StatusConta = statatusbusiness.Listar().FirstOrDefault();
            //conta.CorrentistaTitular = business.Listar().FirstOrDefault();
            //cc.Incluir(conta);

            //ContaPoupancaBusiness cp = new ContaPoupancaBusiness();
            //var conta2 = new ContaPoupanca();
            //conta2.Agencia = new Agencia() { Codigo = 9 };
            //conta2.Codigo = 12;
            //conta2.Status = statatusbusiness.Listar().FirstOrDefault();
            //conta2.CorrentistaTitular = business.Listar().FirstOrDefault();
            //cp.Incluir(conta2);

            return View(business.Listar());
        }

        // GET: Correntistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Correntista correntista = business.Obter(id.Value);
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
        public ActionResult Create(Correntista correntista)
        {//[Bind(Include = "Id,Senha,Nome,Email,CPF")] 
            if (ModelState.IsValid)
            {
                business.Incluir(correntista);
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
            Correntista correntista = business.Obter(id.Value);
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
                business.Alterar(correntista);
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
            Correntista correntista = business.Obter(id.Value);
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
            business.Excluir(id);
            return RedirectToAction("Index");
        }
        
        public ActionResult Login()
        {
            return View();
        }
    }
}
