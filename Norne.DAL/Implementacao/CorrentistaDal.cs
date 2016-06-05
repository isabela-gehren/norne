using Norne.Models;

namespace Norne.DAL
{
    public class CorrentistaDal : GenericDal<Correntista>, ICorrentistaDal
    {
        public CorrentistaDal(IUnitOfWork uow) : base(uow) { }
    }
}
