using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class ContaPoupancaMap : EntityTypeConfiguration<ContaPoupanca>
    {
        public ContaPoupancaMap()
        {

            this.Property(t => t.StatusConta_Codigo).HasColumnName("StatusConta_Codigo");

            this.HasRequired(t => t.Status)
                .WithMany(t => t.ContasPoupanca)
                .HasForeignKey(t => t.StatusConta_Codigo);


            this.ToTable("ContaPoupanca");

        }
    }
}