using LinqToDB;
using Microsoft.Extensions.DependencyInjection;
using LinqToDB.AspNet;

namespace Infra;

public class ModuloDeInjecaoInfra
{
    public static void BindServices(IServiceCollection services)
    {
       //coloca a string em variavel de ambiente do sistema e pega ela para usar abaixo 
        var connectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");
        services.AddLinqToDBContext<DbOSenhorDosAneis>((provider, options) => options.UseSqlServer(connectionString));
    }
}