using System;
using System.Collections.Generic;

namespace Norne.Models
{
    public partial class Correntista
    {
        public Correntista()
        {
            this.Contas = new List<Conta>();
            this.ContaCorrentistaDependentes = new List<ContaCorrentistaDependente>();
        }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Senha { get; set; }
        public virtual string Email { get; set; }
        public virtual string Rg { get; set; }
        public virtual string Naturalidade { get; set; }
        public virtual string Nacionalidade { get; set; }

        public virtual ICollection<Conta> Contas { get; set; }
        public virtual ICollection<ContaCorrentistaDependente> ContaCorrentistaDependentes { get; set; }

    }
}
