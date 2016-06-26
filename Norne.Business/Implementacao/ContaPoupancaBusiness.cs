using Norne.DAL;
using Norne.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Norne.Business
{
    public class ContaPoupancaBusiness : IContaPoupancaBusiness
    {
        string[] paramsListar = new string[] { "Agencia", "StatusConta", "CorrentistaTitular", "ContaCorrentistaDependentes" };

        public IList<ContaPoupanca> Listar()
        {
            IList<ContaPoupanca> lista = new List<ContaPoupanca>();
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var dal = new ContaPoupancaDal(uow);

                lista = dal.GetAll(paramsListar);
            }
            return lista;
        }
        
        public void Excluir(ContaPoupanca Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var dal = new ContaPoupancaDal(uow);
                dal.Delete(Conta);
                uow.Commit();
            }
        }


        public int Incluir(ContaPoupanca Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var statusDal = new StatusContaDal(uow);
                statusDal.Attach(Conta.Status);

                var correntistaDal = new CorrentistaDal(uow);
                correntistaDal.Attach(Conta.CorrentistaTitular);

                var agenciaDal = new AgenciaDal(uow);
                agenciaDal.Attach(Conta.Agencia);

                var dal = new ContaPoupancaDal(uow);
                Conta = dal.Add(Conta);
                uow.Commit();
            }

            return Conta.Codigo;
        }

        public void Alterar(ContaPoupanca Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var statusDal = new StatusContaDal(uow);
                statusDal.Attach(Conta.Status);

                var correntistaDal = new CorrentistaDal(uow);
                correntistaDal.Attach(Conta.CorrentistaTitular);

                var agenciaDal = new AgenciaDal(uow);
                agenciaDal.Attach(Conta.Agencia);

                var dal = new ContaPoupancaDal(uow);
                dal.Update(Conta);
                uow.Commit();
            }
        }

        public double ObterAporteInicialMinimo()
        {
            // TO DO: Pegar esse valor de uma tabela de configuração no banco
            return 100.00;
        }
    }
}
