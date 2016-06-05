using Norne.DAL;
using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
    public class FuncionarioBusiness : IFuncionarioBusiness
    {
        public IList<Funcionario> ListarFuncionarios()
        {
            IList<Funcionario> funcs = new List<Funcionario>();
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var funcionarioDal = new FuncionarioDal(unit);

                funcs = funcionarioDal.GetAll();
            }
            return funcs;
        }


    }
}
