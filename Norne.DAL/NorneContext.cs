using System.Data.Entity;
using Norne.DAL.Models.Mapping;
using Norne.Models;

namespace Norne.DAL
{
    public partial class NorneContext : DbContext
    {
        static NorneContext()
        {
            Database.SetInitializer<NorneContext>(new CustomDatabaseIniatilizer<NorneContext>());
        }

        public NorneContext()
            : base("Name=NorneContext")
        {
        }

        public DbSet<Papel> Papeis { get; set; }
        public DbSet<StatusConta> StatusContas { get; set; }

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

    internal class CustomDatabaseIniatilizer<T> : CreateDatabaseIfNotExists<NorneContext>
    {
        protected override void Seed(NorneContext context)
        {
            base.Seed(context);

            context.StatusContas.Add(new StatusConta() { Codigo = 1, Status = "Ativa" });
            context.StatusContas.Add(new StatusConta() { Codigo = 2, Status = "Inativa" });
            context.StatusContas.Add(new StatusConta() { Codigo = 3, Status = "Esperando Aprovação" });
            context.StatusContas.Add(new StatusConta() { Codigo = 4, Status = "Bloqueada Crédito" });
            context.StatusContas.Add(new StatusConta() { Codigo = 5, Status = "Bloqueada Débito" });

            context.Papeis.Add(new Papel() { Codigo = 1, Nome = "Gerente" });

            context.SaveChanges();
        }
    }
}
