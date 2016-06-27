using System;
using Norne.Models;
using Norne.DAL;
using System.Linq;
using System.Collections.Generic;

namespace Norne.Business
{
    public class AgenciaBusiness : IAgenciaBusiness
    {
        private IAgenciaDal dal;

        public IList<Agencia> Listar()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                return dal.GetAll();
            }
        }

        public void Excluir(Agencia Agencia)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                dal.Delete(Agencia);
                uow.Commit();
            }
        }

        public void Excluir(int codigo)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                var Agencia = dal.Find(i => i.Codigo.Equals(codigo)).FirstOrDefault();
                if (Agencia != null)
                {
                    dal.Delete(Agencia);
                    uow.Commit();
                }
            }
        }

        public int Incluir(Agencia Agencia)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                Agencia = dal.Add(Agencia);

                uow.Commit();
            }
            return Agencia.Codigo;
        }

        public Agencia Obter(string nome)
        {
            return dal.Find(i => i.Nome.Contains(nome)).FirstOrDefault();
        }

        public Agencia Obter(int codigo)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                return dal.Find(i => i.Codigo.Equals(codigo)).FirstOrDefault();
            }
        }

        public void Update(Agencia Agencia)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                dal = new AgenciaDal(uow);
                dal.Update(Agencia);
                uow.Commit();
            }
        }
    }
}
