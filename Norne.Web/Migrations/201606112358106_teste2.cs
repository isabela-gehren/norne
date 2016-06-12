namespace Norne.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lancamentoes", "Momento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Lancamentoes", "Valor", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Lancamentoes", "ValorLancamento");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lancamentoes", "ValorLancamento", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Lancamentoes", "Valor");
            DropColumn("dbo.Lancamentoes", "Momento");
        }
    }
}
