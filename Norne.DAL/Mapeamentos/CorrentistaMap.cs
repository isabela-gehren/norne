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
            
            this.ToTable("Correntista");
        }
    }
}
