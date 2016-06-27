
using System.Collections.Generic;

namespace Norne.Models
{
    public class Agencia
    {
        public Agencia()
        {
            this.Contas = new List<Conta>();
        }

        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Telefone { get; set; }

        public virtual ICollection<Conta> Contas { get; set; }

    }
}
