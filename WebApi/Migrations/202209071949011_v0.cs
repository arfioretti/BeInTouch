namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                        CEP = c.String(),
                        Telefone = c.String(),
                        Celular = c.String(),
                        Bairro = c.String(),
                        Cidade = c.String(),
                        Pais = c.String(),
                        DataInclusao = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clientes");
        }
    }
}
