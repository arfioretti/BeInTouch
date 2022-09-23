using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models.Entity;

namespace WebApi.Context
{
    public class BeInTouchInitializer : CreateDatabaseIfNotExists<BeInTouchContext>
    {
        protected override void Seed(BeInTouchContext context)
        {
            Cliente cliente = new Cliente()
            {
                Nome = "aristides ricardo",
                Sobrenome = "fioretti",
                Email = "arfioretti@gmail.com"
            };
            context.Clientes.Add(cliente);
            context.SaveChanges();

            base.Seed(context);

        }
    }
}