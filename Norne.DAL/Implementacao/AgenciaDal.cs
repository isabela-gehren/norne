using Norne.Models;

namespace Norne.DAL
{
    public class AgenciaDal : GenericDal<Agencia>, IAgenciaDal
    {
        public AgenciaDal(IUnitOfWork uow) : base(uow) { }
    }
}
