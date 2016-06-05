using Norne.Models;

namespace Norne.DAL
{
    public class StatusContaDal : GenericDal<StatusConta>, IStatusContaDal
    {
        public StatusContaDal(IUnitOfWork uow) : base(uow) { }
    }
}
