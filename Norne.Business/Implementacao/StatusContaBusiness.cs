
using Norne.DAL;
using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business
{
   public  class StatusContaBusiness: IStatusContaBusiness
    {
        public IList<StatusConta> Listar()
        {
            IList<StatusConta> lista = new List<StatusConta>();
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var dal = new StatusContaDal(unit);

                lista = dal.GetAll();
            }
            return lista;
        }

    }
}
