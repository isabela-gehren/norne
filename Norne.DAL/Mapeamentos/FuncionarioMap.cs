using Norne.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Norne.DAL.Models.Mapping
{
    public class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.Codigo);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.Matricula)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.Senha)
                .IsRequired()
                .HasMaxLength(20);

            this.HasMany(t => t.Papeis)
                .WithMany(t => t.Funcionarios)
                .Map(m =>
                {
                    m.ToTable("PapelFuncionario");
                    m.MapLeftKey("Funcionario_Codigo");
                    m.MapRightKey("Papel_Codigo");
                });

            this.ToTable("Funcionario");
            
        }
    }
}
