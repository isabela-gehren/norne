using Norne.Models;

namespace Norne.DAL
{
    public class PapelDal : GenericDal<Papel>, IPapelDal
    {
        public PapelDal(IUnitOfWork uow) : base(uow) { }
    }
}
