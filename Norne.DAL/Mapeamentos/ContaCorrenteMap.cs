using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class ContaCorrenteMap : EntityTypeConfiguration<ContaCorrente>
    {
        public ContaCorrenteMap()
        {
            this.HasRequired(t => t.StatusConta)
                .WithMany(t => t.ContasCorrente)
                .Map(t => t.MapKey("StatusConta_Codigo"));

            this.ToTable("ContaCorrente");
        }
    }
}