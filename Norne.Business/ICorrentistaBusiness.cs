
using Norne.Models;

namespace Norne.Business
{
    public interface ICorrentistaBusiness
    {
        int Incluir(Correntista correntista);
        void Excluir(Correntista correntista);
        void Update(Correntista correntista);
        Correntista Obter(int codigo);
        Correntista Obter(string cpf);
    }
}
