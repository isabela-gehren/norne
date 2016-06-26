

namespace Norne.Models
{
    public class ContaCorrente : Conta
    {
        //public int StatusConta_Codigo { get; set; }

        public virtual StatusConta StatusConta { get; set; }
    }
}
