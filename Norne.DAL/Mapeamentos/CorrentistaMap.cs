using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class CorrentistaMap : EntityTypeConfiguration<Correntista>
    {
        public CorrentistaMap()
        {
            this.HasKey(t => t.Codigo);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.Email);

            this.Property(t => t.Nacionalidade).IsRequired();

            this.Property(t => t.Naturalidade).IsRequired();

            // até 14 caracteres e pode incluir letras, variando de estado para estado
            this.Property(t => t.Rg).IsRequired().HasMaxLength(14);

            this.Property(t => t.Senha).IsRequired().HasMaxLength(10);

            this.ToTable("Correntista");
        }
    }
}
