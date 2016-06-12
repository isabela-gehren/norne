namespace Norne.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teste3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContaPoupancas",
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
                "dbo.AniversarioPoupancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        ContaPoupanca_Id = c.Int(),
                        Poupanca_Id = c.Int(),
                        ContaPoupanca_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ContaPoupancas", t => t.ContaPoupanca_Id)
                .ForeignKey("dbo.ContaPoupancas", t => t.Poupanca_Id)
                .ForeignKey("dbo.ContaPoupancas", t => t.ContaPoupanca_Id1)
                .Index(t => t.ContaPoupanca_Id)
                .Index(t => t.Poupanca_Id)
                .Index(t => t.ContaPoupanca_Id1);
            
            AddColumn("dbo.Correntistas", "ContaPoupanca_Id", c => c.Int());
            AddColumn("dbo.Lancamentoes", "AniversarioPoupanca_Id", c => c.Int());
            AddColumn("dbo.Lancamentoes", "ContaPoupanca_Id", c => c.Int());
            CreateIndex("dbo.Correntistas", "ContaPoupanca_Id");
            CreateIndex("dbo.Lancamentoes", "AniversarioPoupanca_Id");
            CreateIndex("dbo.Lancamentoes", "ContaPoupanca_Id");
            AddForeignKey("dbo.Lancamentoes", "AniversarioPoupanca_Id", "dbo.AniversarioPoupancas", "Id");
            AddForeignKey("dbo.Correntistas", "ContaPoupanca_Id", "dbo.ContaPoupancas", "Id");
            AddForeignKey("dbo.Lancamentoes", "ContaPoupanca_Id", "dbo.ContaPoupancas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lancamentoes", "ContaPoupanca_Id", "dbo.ContaPoupancas");
            DropForeignKey("dbo.Correntistas", "ContaPoupanca_Id", "dbo.ContaPoupancas");
            DropForeignKey("dbo.ContaPoupancas", "Correntista_Id", "dbo.Correntistas");
            DropForeignKey("dbo.AniversarioPoupancas", "ContaPoupanca_Id1", "dbo.ContaPoupancas");
            DropForeignKey("dbo.AniversarioPoupancas", "Poupanca_Id", "dbo.ContaPoupancas");
            DropForeignKey("dbo.Lancamentoes", "AniversarioPoupanca_Id", "dbo.AniversarioPoupancas");
            DropForeignKey("dbo.AniversarioPoupancas", "ContaPoupanca_Id", "dbo.ContaPoupancas");
            DropIndex("dbo.AniversarioPoupancas", new[] { "ContaPoupanca_Id1" });
            DropIndex("dbo.AniversarioPoupancas", new[] { "Poupanca_Id" });
            DropIndex("dbo.AniversarioPoupancas", new[] { "ContaPoupanca_Id" });
            DropIndex("dbo.ContaPoupancas", new[] { "Correntista_Id" });
            DropIndex("dbo.Lancamentoes", new[] { "ContaPoupanca_Id" });
            DropIndex("dbo.Lancamentoes", new[] { "AniversarioPoupanca_Id" });
            DropIndex("dbo.Correntistas", new[] { "ContaPoupanca_Id" });
            DropColumn("dbo.Lancamentoes", "ContaPoupanca_Id");
            DropColumn("dbo.Lancamentoes", "AniversarioPoupanca_Id");
            DropColumn("dbo.Correntistas", "ContaPoupanca_Id");
            DropTable("dbo.AniversarioPoupancas");
            DropTable("dbo.ContaPoupancas");
        }
    }
}
