
using System.Collections.Generic;

namespace Norne.Models
{
    public class Conta
    {
        public Conta()
        {
            this.ContaCorrentistaDependentes = new List<ContaCorrentistaDependente>();
        }

        public int Codigo { get; set; }

        public Agencia Agencia { get; set; }
        public Correntista CorrentistaTitular { get; set; }
        public virtual ICollection<ContaCorrentistaDependente> ContaCorrentistaDependentes { get; set; }
    }
}
