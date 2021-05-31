namespace Loja.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InclusaoClientePedido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pedidoes", "NomeCliente", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pedidoes", "NomeCliente");
        }
    }
}
