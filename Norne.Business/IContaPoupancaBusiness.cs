
using Norne.Models;

namespace Norne.Business
{
    public interface IContaPoupancaBusiness : IContaBusiness<ContaPoupanca> {
        double ObterAporteInicialMinimo();
    }
}
