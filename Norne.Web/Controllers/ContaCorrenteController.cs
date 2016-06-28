using Norne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Norne.Web.Controllers
{
    public class ContaCorrenteController : Controller
    {
        // GET: ContaCorrente
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(ContaCorrente conta)
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

            //ContaCorrenteBusiness cc = new ContaCorrenteBusiness();
            //var contascorrentes = cc.Listar();

        }
    }
}