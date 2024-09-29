using FluentMigrator;


namespace Infra.Migrations
{
    [Migration(202407221051)]
    public class AddRacaTable : Migration
    {
        public override void Up()
        {
            Create.Table("Raca")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
                .WithColumn("Nome").AsString().NotNullable().Unique()
                .WithColumn("LocalizacaoGeografica").AsString().Nullable()
                .WithColumn("HabilidadeRacial").AsString().Nullable()
                .WithColumn("EstaExtinta").AsBoolean().NotNullable();
            Execute.Sql(@"
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Humano', 'Gondor', 'Versatilidade', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Elfo', 'Floresta de Lothlórien', 'Visão Noturna', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Anão', 'Montanhas da Terra-média', 'Força e Resiliência', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Hobbit', 'Condado', 'Discrição e Agilidade', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Orc', 'Mordor', 'Ferocidade e Resistência', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Uruk-hai', 'Isengard', 'Força Bruta', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Troll', 'Montanhas da Sombra', 'Força Descomunal', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Ent', 'Floresta de Fangorn', 'Controle da Natureza', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Maiar', 'Valinor', 'Poder Mágico', 0);
                INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) VALUES ('Dragão', 'Erebor', 'Fogo e Voo', 1);
            ");
        }
        public override void Down()
        {
            Delete.Table("Raca");
        }
    }
}
