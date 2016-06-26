using Norne.Models;
using Norne.DAL;
using System.Linq;
using System.Collections.Generic;
using Norne.Utils;

namespace Norne.Business
{
    public class CorrentistaBusiness : ICorrentistaBusiness
    {
        ICriptografia criptografia;
        public CorrentistaBusiness(ICriptografia cripto)
        {
            criptografia = cripto;
        }

        private ICorrentistaDal dal;
        private Funcionario func;

        public IList<Correntista> Listar()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                return dal.GetAll();
            }
        }

        public void Excluir(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                dal.Delete(correntista);
                uow.Commit();
            }
        }

        public void Excluir(int codigo)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                var correntista = dal.Find(i => i.Codigo.Equals(codigo)).FirstOrDefault();
                if (correntista != null)
                {
                    dal.Delete(correntista);
                    uow.Commit();
                }
            }
        }

        public int Incluir(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                correntista.Senha = criptografia.Criptografa(correntista.Senha);
                correntista = dal.Add(correntista);

                uow.Commit();
            }
            return correntista.Codigo;
        }

        public Correntista Obter(string cpf)
        {
            return dal.Find(i => i.Cpf.Equals(cpf)).FirstOrDefault();
        }

        public Correntista Obter(int codigo)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                return dal.Find(i => i.Codigo.Equals(codigo)).FirstOrDefault();
            }
        }

        public void Alterar(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                correntista.Senha = criptografia.Criptografa(correntista.Senha);
                dal.Update(correntista);
                uow.Commit();
            }
        }
    }
}
