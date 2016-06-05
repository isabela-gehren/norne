using Norne.Models;

namespace Norne.DAL
{
    public class FuncionarioDal : GenericDal<Funcionario>, IFuncionarioDal
    {
        public FuncionarioDal(IUnitOfWork uow) : base(uow) { }
    }
}
