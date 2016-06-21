using System;
using Norne.Models;
using Norne.DAL;
using System.Linq;
using System.Collections.Generic;

namespace Norne.Business
{
    public class CorrentistaBusiness : ICorrentistaBusiness
    {
        private ICorrentistaDal dal;

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

        public void Update(Correntista correntista)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new CorrentistaDal(uow);
                dal.Update(correntista);
                uow.Commit();
            }
        }
    }
}
