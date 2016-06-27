using Norne.Models;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class ContaCorrentistaDependenteMap : EntityTypeConfiguration<ContaCorrentistaDependente>
    {
        public ContaCorrentistaDependenteMap()
        {
            this.HasKey(t => t.Codigo);

            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Conta_Codigo).HasColumnName("Conta_Codigo");
            this.Property(t => t.Correntista_Codigo).HasColumnName("Correntista_Codigo");

            // Relationships
            this.HasRequired(t => t.Conta)
                .WithMany(t => t.ContaCorrentistaDependentes)
                .HasForeignKey(d => d.Conta_Codigo);

            this.HasRequired(t => t.Correntista)
                .WithMany(t => t.ContaCorrentistaDependentes)
                .HasForeignKey(d => d.Correntista_Codigo);

            this.ToTable("ContaCorrentistaDependente");

        }
    }
}
