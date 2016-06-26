using Norne.DAL;
using Norne.Models;
using Norne.Utils;
using System.Collections.Generic;
using System.Linq;

namespace Norne.Business
{
    public class FuncionarioBusiness : IFuncionarioBusiness
    {
        ICriptografia criptografia;
        public FuncionarioBusiness(ICriptografia cripto)
        {
            criptografia = cripto;
        }

        public IList<Funcionario> Listar()
        {
            IList<Funcionario> lista = new List<Funcionario>();
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);

                lista = funcionarioDal.GetAll("Papeis");
            }
            return lista;
        }

        public IList<Funcionario> ListarPorPapel(Papel p)
        {
            IList<Funcionario> lista = new List<Funcionario>();
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);

                lista = funcionarioDal.Find(i => i.Papeis.Contains(p, new Comparable.PapelComparable())).ToList();
            }
            return lista;
        }

        public Funcionario ValidarFuncionario(string login, string senha)
        {
            Funcionario func;
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);
                func = funcionarioDal.Find(i => i.Login.Equals(login) && i.Senha.Equals(criptografia.Criptografa(senha)), "Papeis").FirstOrDefault();
            }
            return func;
        }

        public void Excluir(Funcionario funcionario)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);
                funcionarioDal.Delete(funcionario);
                uow.Commit();
            }
        }

        public int Incluir(Funcionario funcionario)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);
                funcionario.Senha = criptografia.Criptografa(funcionario.Senha);
                funcionario = funcionarioDal.Add(funcionario);
                uow.Commit();
            }

            return funcionario.Codigo;
        }

        public void Alterar(Funcionario funcionario)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(uow);
                funcionario.Senha = criptografia.Criptografa(funcionario.Senha);
                funcionarioDal.Update(funcionario);
                uow.Commit();
            }
        }
    }
}
