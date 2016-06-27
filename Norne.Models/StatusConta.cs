using System;
using System.Collections.Generic;

namespace Norne.Models
{
    public partial class StatusConta
    {
        public StatusConta()
        {
            ContasCorrente = new List<ContaCorrente>();
            ContasPoupanca = new List<ContaPoupanca>();
        }
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<ContaCorrente> ContasCorrente { get; set; }
        public virtual ICollection<ContaPoupanca> ContasPoupanca { get; set; }

    }
}
