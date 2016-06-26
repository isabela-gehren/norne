using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class StatusContaMap : EntityTypeConfiguration<StatusConta>
    {
        public StatusContaMap()
        {
            this.HasKey(t => t.Codigo);
            this.Property(t => t.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descricao).IsRequired().HasMaxLength(25);

            this.Property(t => t.Codigo).HasColumnName("Codigo");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            this.HasOptional(t => t.ContasCorrente);
            this.HasOptional(t => t.ContasPoupanca);


            this.ToTable("StatusConta");
        }
    }
}
