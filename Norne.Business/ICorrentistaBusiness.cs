
using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public interface ICorrentistaBusiness
    {
        IList<Correntista> Listar();
        int Incluir(Correntista correntista);
        void Excluir(int codigo);
        void Excluir(Correntista correntista);
        void Update(Correntista correntista);
        Correntista Obter(int codigo);
        Correntista Obter(string cpf);
    }
}
