namespace Norne.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Correntistas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Senha = c.String(),
                        Nome = c.String(),
                        Email = c.String(),
                        CPF = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Correntistas");
        }
    }
}
