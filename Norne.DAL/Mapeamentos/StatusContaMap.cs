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

            this.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(15);
            
            this.ToTable("StatusConta");
        }
    }
}
