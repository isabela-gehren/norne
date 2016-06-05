using System;
using System.Collections.Generic;

namespace Norne.Models
{
    public partial class Papel
    {
        public Papel()
        {
            this.Funcionarios = new List<Funcionario>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
