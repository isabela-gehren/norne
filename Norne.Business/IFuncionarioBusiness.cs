using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public interface IFuncionarioBusiness
    {
        IList<Funcionario> Listar();
        IList<Funcionario> ListarPorPapel(Papel p);
        void Alterar(Funcionario funcionario);
        int Incluir(Funcionario funcionario);
        void Excluir(Funcionario funcionario);

        Funcionario ValidarFuncionario(string login, string senha);
    }
}
