using System.ComponentModel;

namespace Dominio.ENUMS
{
    public enum ProfissaoEnum
    {
        [Description("Nenhum")]
        Nenhum = 0,
        [Description("Guerreiro")]
        Guerreiro = 1,
        [Description("Arqueiro")]
        Arqueiro = 2,
        [Description("Mago")]
        Mago = 3,
        [Description("Ladrao")]
        Ladrao = 4,
        [Description("Jardineiro")]
        Jardineiro = 5,
        [Description("Aventureiro")]
        Aventureiro = 6,
        [Description("Rei")]
        Rei = 7,
        [Description("Senhor de Lothlorien")]
        SenhoraDeLothlorien = 8,
        [Description("Senhor de Valfenda")]
        SenhorDeValfenda = 9,
        [Description("Escudeira")]
        Escudeira = 10,
        [Description("Capitao")]
        Capitao = 11,
        [Description("Princesa")]
        Princesa = 12,
        [Description("Ent")]
        Ent = 13,
        [Description("Knight")]
        Cavaleiro = 14,
        [Description("Ex-hobbit")]
        ExHobbit = 15
    }
}
