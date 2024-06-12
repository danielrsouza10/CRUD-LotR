using Infra;
using Microsoft.Extensions.DependencyInjection;

namespace Testes.TesteServicos;

public class teste_conexao : TesteBase
{
    private DbOSenhorDosAneis _contextoConexao;
    public teste_conexao()
    {
        _contextoConexao = _serviceProvider.GetRequiredService<DbOSenhorDosAneis>();
    }
    [Fact]
    public void DeveConectarNoBancoDeDadosComExito()
    {
        // Arrange
        bool statusDaConexao;
           
        // Act
        statusDaConexao = _contextoConexao.Connection.State == System.Data.ConnectionState.Open;
 
        // Assert
        Assert.True(statusDaConexao, $"A conexão com o banco de dados deve estar aberta.");
    }
}