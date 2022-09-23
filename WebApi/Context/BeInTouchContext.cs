using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApi.Models.Entity;

namespace WebApi.Context
{
    public class BeInTouchContext : DbContext
    {
        public BeInTouchContext() : base("name=BeInTouchConn")
        {
            //Database.SetInitializer(new BeInTouchInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BeInTouchContext, Migrations.Configuration>());
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}