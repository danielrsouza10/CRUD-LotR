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
                .WithColumn("IdRaca").AsInt32().ForeignKey()
                .WithColumn("Profissao").AsInt32().NotNullable()
                .WithColumn("Idade").AsInt32().Nullable()
                .WithColumn("Altura").AsFloat().Nullable()
                .WithColumn("EstaVivo").AsBoolean().NotNullable()
                .WithColumn("DataDoCadastro").AsDateTime();
            Create.ForeignKey()
                .FromTable("Personagem").ForeignColumn("IdRaca")
                .ToTable("Raca").PrimaryColumn("Id");      
        }
        public override void Down()
        {
            Delete.Table("Personagem");
        }
    }
}
