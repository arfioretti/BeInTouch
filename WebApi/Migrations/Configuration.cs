namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Context.BeInTouchContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Context.BeInTouchContext context)
        {
            Cliente cliente = new Cliente()
            {
                Nome = "Meu Pilibim",
                Sobrenome = "fioretti",
                Email = "arfioretti@gmail.com"
            };
            context.Clientes.Add(cliente);
            context.SaveChanges();
        }
    }
}
