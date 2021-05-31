namespace Loja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaoBebida : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bebidas",
                c => new
                    {
                        BebidaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.BebidaId);
            
            AddColumn("dbo.Pedidoes", "Bebidas_BebidaId", c => c.Int());
            CreateIndex("dbo.Pedidoes", "Bebidas_BebidaId");
            AddForeignKey("dbo.Pedidoes", "Bebidas_BebidaId", "dbo.Bebidas", "BebidaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedidoes", "Bebidas_BebidaId", "dbo.Bebidas");
            DropIndex("dbo.Pedidoes", new[] { "Bebidas_BebidaId" });
            DropColumn("dbo.Pedidoes", "Bebidas_BebidaId");
            DropTable("dbo.Bebidas");
        }
    }
}
