using Norne.DAL;
using Norne.Models;
using System.Collections.Generic;
using System.Linq;

namespace Norne.Business
{
    public class FuncionarioBusiness : IFuncionarioBusiness
    {
        public IList<Funcionario> Listar()
        {
            IList<Funcionario> lista = new List<Funcionario>();
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);

                lista = funcionarioDal.GetAll("Papeis");
            }
            return lista;
        }

        public IList<Funcionario> ListarPorPapel(Papel p)
        {
            IList<Funcionario> lista = new List<Funcionario>();
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);

                lista = funcionarioDal.Find(i => i.Papeis.Contains(p, new Comparable.PapelComparable())).ToList();
            }
            return lista;
        }

        public Funcionario ValidarFuncionario(string login, string senha)
        {
            Funcionario func;
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);
                func = funcionarioDal.Find(i => i.Login.Equals(login) && i.Senha.Equals(senha), "Papeis").FirstOrDefault();
            }
            return func;
        }

        public void Excluir(Funcionario funcionario)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);
                funcionarioDal.Delete(funcionario);
            }
        }

        public int Incluir(Funcionario funcionario)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);
                funcionario = funcionarioDal.Add(funcionario);
            }

            return funcionario.Codigo;
        }

        public void Alterar(Funcionario funcionario)
        {
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);
                funcionarioDal.Update(funcionario);
            }
        }
    }
}
