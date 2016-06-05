using System;
using System.Collections.Generic;

namespace Norne.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            this.Papeis = new List<Papel>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Matricula { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<Papel> Papeis { get; set; }
    }
}
