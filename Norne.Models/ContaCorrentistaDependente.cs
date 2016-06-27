namespace Norne.Models
{
    public class ContaCorrentistaDependente
    {
        public int Codigo { get; set; }
        public int Conta_Codigo { get; set; }
        public int Correntista_Codigo { get; set; }
        public virtual Conta Conta { get; set; }
        public virtual Correntista Correntista { get; set; }
    }
}