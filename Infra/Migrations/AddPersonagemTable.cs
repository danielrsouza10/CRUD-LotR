using Dominio.ENUMS;
using FluentMigrator;


namespace Infra.Migrations
{
    [Migration(20240607124011)]
    public class AddPersonagemTable : Migration
    {
        public override void Up()
        {
            Create.Table("Personagem")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("IdRaca").AsInt32().NotNullable()
                .WithColumn("Profissao").AsInt32().NotNullable()
                .WithColumn("Idade").AsInt32()
                .WithColumn("Altura").AsFloat()
                .WithColumn("DataDoCadastro").AsDateTime();
        }
        public override void Down()
        {
            Delete.Table("Personagem");
        }
    }
}
