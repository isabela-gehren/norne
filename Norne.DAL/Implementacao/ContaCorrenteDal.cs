using Norne.Models;

namespace Norne.DAL
{
    public class ContaCorrenteDal : GenericDal<ContaCorrente>, IContaCorrenteDal
    {
        public ContaCorrenteDal(IUnitOfWork uow) : base(uow) { }
    }
}
