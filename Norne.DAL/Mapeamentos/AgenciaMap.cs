using Norne.Models;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class AgenciaMap : EntityTypeConfiguration<Agencia>
    {
        public AgenciaMap()
        {
            this.HasKey(t => t.Codigo);

            this.Property(t => t.Nome).IsRequired().HasMaxLength(50);
            this.Property(t => t.Endereco).IsRequired().HasMaxLength(100);
            this.Property(t => t.Bairro).IsRequired().HasMaxLength(50);
            this.Property(t => t.Cep).IsRequired().HasMaxLength(8);
            this.Property(t => t.Cidade).IsRequired().HasMaxLength(50);
            this.Property(t => t.Estado).IsRequired().HasMaxLength(2);
            this.Property(t => t.Telefone).IsRequired().HasMaxLength(10);

            this.HasOptional(t => t.Contas);

            this.ToTable("Agencia");

        }
    }
}