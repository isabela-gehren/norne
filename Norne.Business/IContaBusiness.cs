using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public interface IContaBusiness<T>
    {
        IList<T> Listar();
        void Alterar(T conta);
        int Incluir(T conta);
        void Excluir(T conta);
    }
}
