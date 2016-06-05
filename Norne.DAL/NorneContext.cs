using System.Data.Entity;
using Norne.DAL.Models.Mapping;
using Norne.Models;

namespace Norne.DAL
{
    public partial class NorneContext : DbContext
    {
        static NorneContext()
        {
            Database.SetInitializer<NorneContext>(null);
        }

        public NorneContext()
            : base("Name=NorneContext")
        {
        }

        //public DbSet<Correntista> Correntistas { get; set; }
        //public DbSet<Funcionario> Funcionarios { get; set; }
        //public DbSet<Papel> Papeis { get; set; }
        //public DbSet<PapelFuncionario> PapelFuncionarios { get; set; }
        //public DbSet<StatusConta> StatusContas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CorrentistaMap());
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new PapelMap());
            modelBuilder.Configurations.Add(new StatusContaMap());

            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.UseDatabaseNullSemantics = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = true;
            this.Configuration.UseDatabaseNullSemantics = false;
            this.Configuration.EnsureTransactionsForFunctionsAndCommands = false;
        }
    }
}
