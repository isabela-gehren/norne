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
            modelBuilder.Configurations.Add(new AgenciaMap());
            modelBuilder.Configurations.Add(new ContaMap());
            modelBuilder.Configurations.Add(new ContaCorrenteMap());
            modelBuilder.Configurations.Add(new ContaPoupancaMap());
            modelBuilder.Configurations.Add(new ContaCorrentistaDependenteMap());


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

            context.StatusContas.Add(new StatusConta() { Codigo = 1, Descricao = "Ativa" });
            context.StatusContas.Add(new StatusConta() { Codigo = 2, Descricao = "Inativa" });
            context.StatusContas.Add(new StatusConta() { Codigo = 3, Descricao = "Pendente Aprovação" });
            context.StatusContas.Add(new StatusConta() { Codigo = 4, Descricao = "Bloqueada Crédito" });
            context.StatusContas.Add(new StatusConta() { Codigo = 5, Descricao = "Bloqueada Débito" });

            context.Papeis.Add(new Papel() { Codigo = 1, Nome = "Gerente" });

            context.SaveChanges();
        }
    }
}
