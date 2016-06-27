using Norne.Models;

namespace Norne.DAL
{
    public class ContaPoupancaDal : GenericDal<ContaPoupanca>, IContaPoupancaDal
    {
        public ContaPoupancaDal(IUnitOfWork uow) : base(uow) { }
    }
}
