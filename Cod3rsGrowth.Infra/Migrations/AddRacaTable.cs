using FluentMigrator;


namespace Infra.Migrations
{
    [Migration(20240607124012)]
    public class AddRacaTable : Migration
    {
        public override void Up()
        {
            Create.Table("Raca")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("LocalizacaoGeografica").AsString().Nullable()
                .WithColumn("HabilidadeRacial").AsString().Nullable()
                .WithColumn("EstaExtinta").AsBoolean().NotNullable();
        }
        public override void Down()
        {
            Delete.Table("Raca");
        }
    }
}
