using Norne.DAL;
using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public class ContaCorrenteBusiness : IContaCorrenteBusiness
    {
        string[] paramsListar = new string[] { "Agencia", "StatusConta", "CorrentistaTitular", "ContaCorrentistaDependentes" };
        public IList<ContaCorrente> Listar()
        {
            IList<ContaCorrente> lista = new List<ContaCorrente>();
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var dal = new ContaCorrenteDal(uow);

                lista = dal.GetAll(paramsListar);
            }
            return lista;
        }

        public void Excluir(ContaCorrente Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var dal = new ContaCorrenteDal(uow);
                dal.Delete(Conta);
                uow.Commit();
            }
        }

        public int Incluir(ContaCorrente Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var statusDal = new StatusContaDal(uow);
                statusDal.Attach(Conta.StatusConta);

                var correntistaDal = new CorrentistaDal(uow);
                correntistaDal.Attach(Conta.CorrentistaTitular);

                var agenciaDal = new AgenciaDal(uow);
                agenciaDal.Attach(Conta.Agencia);

                var dal = new ContaCorrenteDal(uow);
                Conta = dal.Add(Conta);
                uow.Commit();
            }

            return Conta.Codigo;
        }

        public void Alterar(ContaCorrente Conta)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var statusDal = new StatusContaDal(uow);
                statusDal.Attach(Conta.StatusConta);

                var correntistaDal = new CorrentistaDal(uow);
                correntistaDal.Attach(Conta.CorrentistaTitular);

                var agenciaDal = new AgenciaDal(uow);
                agenciaDal.Attach(Conta.Agencia);

                var dal = new ContaCorrenteDal(uow);
                dal.Update(Conta);
                uow.Commit();
            }
        }
    }
}
