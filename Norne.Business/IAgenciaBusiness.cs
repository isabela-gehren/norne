using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public interface IAgenciaBusiness
    {
        IList<Agencia> Listar();
        int Incluir(Agencia Agencia);
        void Excluir(int codigo);
        void Excluir(Agencia Agencia);
        void Update(Agencia Agencia);
        Agencia Obter(int codigo);
        Agencia Obter(string nome);
    }
}
