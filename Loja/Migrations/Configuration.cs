namespace Loja.Migrations
{
    using Loja.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Loja.Data.LojaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Loja.Data.LojaContext context)
        {
            context.Bebidas.AddOrUpdate(x => x.BebidaId,
            new Bebida (){BebidaId = 20 , Nome = "Kuat"},
            new Bebida() { BebidaId=34, Nome = "Pepsi"}

            );
           context.Lanches.AddOrUpdate(x => x.LancheId,
           new Lanche() { LancheId = 327, NomeLanche = "BigMac"},
           new Lanche() { LancheId = 230, NomeLanche = "Xtudones"}

           );



        }
    }
}
