
using System.Collections.Generic;
using Norne.Models;
using Norne.DAL;

namespace Norne.Business
{
    public class PapelBusiness : IPapelBusiness
    {
        public IList<Papel> Listar()
        {
            IList<Papel> lista = new List<Papel>();
            using (IUnitOfWork unit = new UnitOfWork())
            {
                var dal = new PapelDal(unit);

                lista = dal.GetAll();
            }
            return lista;

        }
    }
}
