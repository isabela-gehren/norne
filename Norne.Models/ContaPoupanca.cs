
namespace Norne.Models
{
    public class ContaPoupanca : Conta
    {
        public int StatusConta_Codigo { get; set; }

        public virtual StatusConta Status { get; set; }
    }
}
