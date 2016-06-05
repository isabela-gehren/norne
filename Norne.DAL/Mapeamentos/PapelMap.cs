using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class PapelMap : EntityTypeConfiguration<Papel>
    {
        public PapelMap()
        {
            this.HasKey(t => t.Codigo);

            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(15);
            
            this.ToTable("Papel");
        }
    }
}
