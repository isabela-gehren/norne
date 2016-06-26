using Norne.Models;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class ContaMap : EntityTypeConfiguration<Conta>
    {
        public ContaMap()
        {
            this.HasKey(t => t.Codigo);

            // Relationships
            this.HasRequired(t => t.Agencia)
            .WithMany(t => t.Contas)
            .Map(d => d.MapKey("Agencia_Codigo"));

            this.HasRequired(t => t.CorrentistaTitular)
                .WithMany(t => t.Contas)
                .Map(d => d.MapKey("CorrentistaTitular_Codigo"));

            this.ToTable("Conta");

        }
    }
}