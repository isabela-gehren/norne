using System;
using Norne.Models;
using Norne.DAL;
using System.Linq;

namespace Norne.Business
{
    public class CorrentistaBusiness : ICorrentistaBusiness
    {
        private ICorrentistaDal dal;

        //public CorrentistaBusiness(ICorrentistaDal dal)
        //{
        //    this.dal = dal;
        //}

        public void Excluir(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                dal.Delete(correntista);
            }
        }

        public int Incluir(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                correntista = dal.Add(correntista);
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

        public void Update(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                dal.Update(correntista);
            }
        }
    }
}
