using Norne.Models;
using System.Collections.Generic;

namespace Norne.Business.Comparable
{
    public class PapelComparable : IEqualityComparer<Papel>
    {
        public bool Equals(Papel x, Papel y)
        {
            if (x == null || y == null)
                return false;
            if (x.Codigo == y.Codigo)
                return true;
            else
                return false;
        }

        public int GetHashCode(Papel obj)
        {
            return obj.Codigo.GetHashCode();
        }
    }
}
