namespace Norne.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContaCorrentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Saldo = c.Double(nullable: false),
                        Numero = c.String(),
                        Status = c.Int(nullable: false),
                        Correntista_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Correntistas", t => t.Correntista_Id)
                .Index(t => t.Correntista_Id);
            
            CreateTable(
                "dbo.Lancamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContaCorrente_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContaCorrentes", t => t.ContaCorrente_Id)
                .Index(t => t.ContaCorrente_Id);
            
            AddColumn("dbo.Correntistas", "ContaCorrente_Id", c => c.Int());
            CreateIndex("dbo.Correntistas", "ContaCorrente_Id");
            AddForeignKey("dbo.Correntistas", "ContaCorrente_Id", "dbo.ContaCorrentes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lancamentoes", "ContaCorrente_Id", "dbo.ContaCorrentes");
            DropForeignKey("dbo.Correntistas", "ContaCorrente_Id", "dbo.ContaCorrentes");
            DropForeignKey("dbo.ContaCorrentes", "Correntista_Id", "dbo.Correntistas");
            DropIndex("dbo.Lancamentoes", new[] { "ContaCorrente_Id" });
            DropIndex("dbo.Correntistas", new[] { "ContaCorrente_Id" });
            DropIndex("dbo.ContaCorrentes", new[] { "Correntista_Id" });
            DropColumn("dbo.Correntistas", "ContaCorrente_Id");
            DropTable("dbo.Lancamentoes");
            DropTable("dbo.ContaCorrentes");
        }
    }
}
