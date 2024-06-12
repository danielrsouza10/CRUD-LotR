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
                .WithColumn("Id Raca").AsInt32().ForeignKey().NotNullable()
                .WithColumn("Profissao").AsInt32().NotNullable()
                .WithColumn("Idade").AsInt32()
                .WithColumn("Altura").AsFloat()
                .WithColumn("Esta Vivo?").AsBoolean().NotNullable()
                .WithColumn("Data do Cadastro").AsDateTime();
        }
        public override void Down()
        {
            Delete.Table("Personagem");
        }
    }
}
